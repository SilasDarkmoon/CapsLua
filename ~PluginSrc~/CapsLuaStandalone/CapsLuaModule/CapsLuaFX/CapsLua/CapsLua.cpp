// CapsLua.cpp : 定义 DLL 的导出函数。
//

#include "framework.h"
#include "CapsLua.h"


extern "C" CAPSLUA_API int luaopen_CapsLua(void* l)
{
	Capstones::UnityEngineEx::GlobalLua::luaopen_CapsLua(System::IntPtr(l));
	return 0;
}