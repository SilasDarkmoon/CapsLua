using UnityEngine;
using System.Collections;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;

public class CapsUnityLuaBehavLateUpdate : CapsUnityLuaBehavEx
{
    private void LateUpdate()
    {
        this.CallLuaFunc("lateUpdate");
    }
}