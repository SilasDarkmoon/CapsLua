using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventDrag : CapsUnityLuaBehavEx, IDragHandler
    {
        public void OnDrag(PointerEventData eventData)
        {
            this.CallLuaFunc("onDrag", eventData);
        }
    }
}