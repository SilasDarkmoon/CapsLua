using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventBeginDrag : CapsUnityLuaBehavEx, IBeginDragHandler
    {
        public void OnBeginDrag(PointerEventData eventData)
        {
            this.CallLuaFunc("onBeginDrag", eventData);
        }
    }
}
