using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventEndDrag : CapsUnityLuaBehavEx, IEndDragHandler
    {
        public void OnEndDrag(PointerEventData eventData)
        {
            this.CallLuaFunc("onEndDrag", eventData);
        }
    }
}