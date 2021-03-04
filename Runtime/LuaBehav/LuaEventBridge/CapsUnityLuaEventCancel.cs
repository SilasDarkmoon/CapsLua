using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventCancel : CapsUnityLuaBehavEx, ICancelHandler
    {
       
        public void OnCancel(BaseEventData eventData)
        {
            this.CallLuaFunc("onCancel", eventData);
        }
    }
}