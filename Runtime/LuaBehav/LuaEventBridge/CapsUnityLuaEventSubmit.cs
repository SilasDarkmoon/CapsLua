using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventSubmit : CapsUnityLuaBehavEx, ISubmitHandler
    {
        public void OnSubmit(BaseEventData eventData)
        {
            this.CallLuaFunc("onSubmit", eventData);
        }
    }
}