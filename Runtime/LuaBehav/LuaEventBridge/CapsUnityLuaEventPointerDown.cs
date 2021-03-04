using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventPointerDown : CapsUnityLuaBehavEx, IPointerDownHandler
    {
        public void OnPointerDown(PointerEventData eventData)
        {
            this.CallLuaFunc("onPointerDown", eventData);
        }
    }
}