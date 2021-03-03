namespace Capstones.LuaWrap
{
    public partial class CapsUnityLuaEventReceiver : CapsUnityLuaBehavEx
    {
        public string FuncName;
        protected virtual void Start()
        {
        }

        public void EventAction()
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName);
        }

        public void EventAction(object p0)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0);
        }

        public void EventAction(object p0, object p1)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1);
        }

        public void EventAction(object p0, object p1, object p2)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1, p2);
        }

        public void EventAction(object p0, object p1, object p2, object p3)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1, p2, p3);
        }

        public void EventAction(object p0, object p1, object p2, object p3, object p4)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1, p2, p3, p4);
        }

        public void EventAction(object p0, object p1, object p2, object p3, object p4, object p5)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1, p2, p3, p4, p5);
        }

        public void EventAction(object p0, object p1, object p2, object p3, object p4, object p5, object p6)
        {
            if (this.isActiveAndEnabled)
                this.CallLuaFunc(FuncName, p0, p1, p2, p3, p4, p5, p6);
        }
    }
}
