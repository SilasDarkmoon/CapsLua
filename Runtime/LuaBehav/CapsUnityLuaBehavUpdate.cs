using UnityEngine;
using System.Collections;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;

public class CapsUnityLuaBehavUpdate : CapsUnityLuaBehavEx
{
    private void Update()
    {
        this.CallLuaFunc("update");
    }
}