using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventMove : CapsUnityLuaBehavEx, IMoveHandler
    {
        public void OnMove(AxisEventData eventData)
        {
            this.CallLuaFunc("onMove", eventData);
        }
    }
}