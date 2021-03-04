using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventInitializePotentialDrag : CapsUnityLuaBehavEx, IInitializePotentialDragHandler
    {
        public void OnInitializePotentialDrag(PointerEventData eventData)
        {
            this.CallLuaFunc("onInitializePotentialDrag", eventData);
        }
    }
}