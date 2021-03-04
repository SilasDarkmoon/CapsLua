using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Capstones.LuaWrap.UI
{
    public class CapsUnityLuaEventDeselect : CapsUnityLuaBehavEx, IDeselectHandler
    {
        public void OnDeselect(BaseEventData eventData)
        {
            this.CallLuaFunc("onDeselect", eventData);
        }
    }
}