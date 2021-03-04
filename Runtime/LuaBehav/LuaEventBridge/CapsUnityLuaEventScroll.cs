using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventScroll : CapsUnityLuaBehavEx, IScrollHandler
    {
        public void OnScroll(PointerEventData eventData)
        {
            this.CallLuaFunc("onScroll", eventData);
        }
    }
}