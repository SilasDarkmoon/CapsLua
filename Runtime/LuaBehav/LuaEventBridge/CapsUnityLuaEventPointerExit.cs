using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventPointerExit : CapsUnityLuaBehavEx, IPointerExitHandler
    {
        public void OnPointerExit(PointerEventData eventData)
        {
            this.CallLuaFunc("onPointerExit", eventData);
        }
    }
}