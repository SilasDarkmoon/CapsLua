using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventSelect : CapsUnityLuaBehavEx, ISelectHandler
    {
        public void OnSelect(BaseEventData eventData)
        {
             this.CallLuaFunc("onSelect", eventData);
        }
    }
}