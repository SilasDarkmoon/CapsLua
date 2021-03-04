using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventPointerUp : CapsUnityLuaBehavEx, IPointerUpHandler
    {
        public void OnPointerUp(PointerEventData eventData)
        {
            this.CallLuaFunc("onPointerUp", eventData);
        }
    }
}