using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventPointerClick : CapsUnityLuaBehavEx, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            this.CallLuaFunc("onPointerClick", eventData);
        }
    }
}