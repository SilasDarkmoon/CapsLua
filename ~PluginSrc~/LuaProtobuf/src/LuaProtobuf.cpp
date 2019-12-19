// LuaProtobuf.cpp : 定义 DLL 应用程序的导出函数。
//

#include "LuaImport.h"

#if _WIN32
#define EXPORT_API __declspec(dllexport)
#else
#define EXPORT_API
#endif

extern "C"
{
    extern int luaopen_pb_io(lua_State *L);
    extern int luaopen_pb_conv(lua_State *L);
    extern int luaopen_pb_buffer(lua_State *L);
    extern int luaopen_pb_slice(lua_State *L);
    extern int luaopen_pb(lua_State *L);
    
    EXPORT_API void Init(void* l)
    {
        luaopen_pb(l);
        luaopen_pb_io(l);
        luaopen_pb_conv(l);
        luaopen_pb_buffer(l);
        luaopen_pb_slice(l);
    }
}
