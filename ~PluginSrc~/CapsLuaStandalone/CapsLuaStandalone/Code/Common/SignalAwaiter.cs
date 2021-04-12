using System;
using System.Threading;
using System.Threading.Tasks;

public abstract class AsyncSignal
{
    protected internal class CallOnceAction
    {
        protected int CallCount = 0;
        protected Action Act;

        public CallOnceAction(Action act)
        {
            Act = act;
        }

        public bool TryCall()
        {
            if (System.Threading.Interlocked.Increment(ref CallCount) == 1)
            {
                if (Act != null)
                {
                    Act();
                }
                return true;
            }
            return false;
        }
        public bool Cancel()
        {
            return System.Threading.Interlocked.Increment(ref CallCount) == 1;
        }
    }
    protected System.Collections.Concurrent.ConcurrentQueue<CallOnceAction> _Continuations = new System.Collections.Concurrent.ConcurrentQueue<CallOnceAction>();

    protected internal void OnCompleted(CallOnceAction continuation)
    {
        if (continuation != null)
        {
            _Continuations.Enqueue(continuation);
            CheckCompleted();
        }
    }
    protected void CallContinuation(CallOnceAction continuation)
    {
        if (!continuation.TryCall())
        {
            CancelContinuation();
        }
    }

    public abstract void CheckCompleted();
    public abstract void CancelContinuation();
    public abstract void Set();
    public abstract void Reset();
    public abstract bool TryTake();

    protected volatile int _IsCompleted;
    public bool IsCompleted { get { return _IsCompleted != 0; } }

    public class Awaiter : System.Runtime.CompilerServices.INotifyCompletion
    {
        protected AsyncSignal _Signal;
        public Awaiter(AsyncSignal signal)
        {
            _Signal = signal;
        }

        internal CallOnceAction _Continuation;
        public bool IsCompleted { get { return _Signal.IsCompleted; } }
        public void GetResult() { }
        public void OnCompleted(Action continuation)
        {
            var wrapped = _Continuation = new CallOnceAction(continuation);
            _Signal.OnCompleted(wrapped);
        }
        public bool Cancel()
        {
            var wrapped = _Continuation;
            if (wrapped != null)
            {
                return wrapped.Cancel();
            }
            return true;
        }

        public Awaiter GetAwaiter() { return this; }

        public async Task<bool> Wait()
        {
            await this;
            return true;
        }
    }
    public Awaiter GetAwaiter() { return new Awaiter(this); }

    public async Task<bool> Wait()
    {
        await this;
        return true;
    }
    public async Task<bool> Wait(int timeout)
    {
        if (timeout == 0)
        {
            return TryTake();
        }
        else
        {
            var awaiter = GetAwaiter();
            var taskThis = awaiter.Wait();
            var taskWait = Task.Delay(timeout);
            await Task.WhenAny(taskThis, taskWait);
            if (taskThis.IsCompleted)
            {
                return true;
            }
            else
            {
                if (awaiter.Cancel())
                {
                    return false;
                }
                return true; // this means the awaiter finished while we are checking taskThis.IsCompleted.
            }
        }
    }
}

public class ManualResetSignal : AsyncSignal
{
    public override void Set()
    {
        if (System.Threading.Interlocked.Exchange(ref _IsCompleted, 1) == 0)
        {
            CheckCompleted();
        }
    }
    public override void Reset()
    {
        System.Threading.Interlocked.Exchange(ref _IsCompleted, 0);
    }
    public override bool TryTake()
    {
        return IsCompleted;
    }
    public override void CancelContinuation()
    {
    }
    public override void CheckCompleted()
    {
        while (IsCompleted)
        {
            CallOnceAction continuation;
            if (_Continuations.TryDequeue(out continuation))
            {
                CallContinuation(continuation);
            }
            else
            {
                break;
            }
        }
    }
}

public class AutoResetSignal : AsyncSignal
{
    public override void Set()
    {
        if (System.Threading.Interlocked.Exchange(ref _IsCompleted, 1) == 0)
        {
            CheckCompleted();
        }
    }
    public override void Reset()
    {
        System.Threading.Interlocked.Exchange(ref _IsCompleted, 0);
    }
    public override bool TryTake()
    {
        return System.Threading.Interlocked.Exchange(ref _IsCompleted, 0) == 1;
    }
    public override void CancelContinuation()
    {
        System.Threading.Interlocked.Exchange(ref _IsCompleted, 1);
    }
    public override void CheckCompleted()
    {
        while (System.Threading.Interlocked.Exchange(ref _IsCompleted, 0) == 1)
        {
            CallOnceAction continuation;
            if (_Continuations.TryDequeue(out continuation))
            {
                CallContinuation(continuation);
            }
            else
            {
                CancelContinuation();
                break;
            }
        }
    }
}

public class SemaphoreSignal : AsyncSignal
{
    public override void Set()
    {
        if (System.Threading.Interlocked.Increment(ref _IsCompleted) > 0)
        {
            CheckCompleted();
        }
    }
    public override void Reset()
    {
        if (System.Threading.Interlocked.Decrement(ref _IsCompleted) < 0)
        {
            System.Threading.Interlocked.Increment(ref _IsCompleted);
        }
    }
    public override bool TryTake()
    {
        if (System.Threading.Interlocked.Decrement(ref _IsCompleted) < 0)
        {
            System.Threading.Interlocked.Increment(ref _IsCompleted);
            return false;
        }
        else
        {
            return true;
        }
    }
    public override void CancelContinuation()
    {
        System.Threading.Interlocked.Increment(ref _IsCompleted);
    }
    public override void CheckCompleted()
    {
        while (System.Threading.Interlocked.Decrement(ref _IsCompleted) >= 0)
        {
            CallOnceAction continuation;
            if (_Continuations.TryDequeue(out continuation))
            {
                CallContinuation(continuation);
            }
            else
            {
                break;
            }
        }
        CancelContinuation();
    }
}