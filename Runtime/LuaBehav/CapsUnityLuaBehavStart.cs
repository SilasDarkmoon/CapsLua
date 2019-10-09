using UnityEngine;
using System.Collections;
using Capstones.LuaWrap;
using Capstones.UnityEngineEx;

public class CapsUnityLuaBehavStart : CapsUnityLuaBehavEx
{
    private void Start()
    {
        this.CallLuaFunc("start");
    }
}