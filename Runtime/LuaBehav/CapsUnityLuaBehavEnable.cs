using UnityEngine;
using System.Collections;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;

public class CapsUnityLuaBehavEnable : CapsUnityLuaBehavEx
{
    private void OnEnable()
    {
        this.CallLuaFunc("onEnable");
    }
    private void OnDisable()
    {
        this.CallLuaFunc("onDisable");
    }
}