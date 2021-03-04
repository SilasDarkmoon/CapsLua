using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventDrop : CapsUnityLuaBehavEx, IDropHandler
    {
        public void OnDrop(PointerEventData eventData)
        {
            this.CallLuaFunc("onDrop", eventData);
        }
    }
}