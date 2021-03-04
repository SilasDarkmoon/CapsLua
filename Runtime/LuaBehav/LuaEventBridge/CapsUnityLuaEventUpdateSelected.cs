using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventUpdateSelected : CapsUnityLuaBehavEx, IUpdateSelectedHandler
    {
        public void OnUpdateSelected(BaseEventData eventData)
        {
            this.CallLuaFunc("onUpdateSelected", eventData);
        }
    }
}