using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventPointerEnter : CapsUnityLuaBehavEx, IPointerEnterHandler
    {
        public void OnPointerEnter(PointerEventData eventData)
        {
            this.CallLuaFunc("onPointerEnter", eventData);
        }
    }
}