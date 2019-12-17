#include <stddef.h>
#include <assert.h>
#define Assert assert

#include "IUnityInterface.h"

#define LUA_LIB
#include "lualib.h"
#include "lauxlib.h"

typedef lua_CFunction   (*del_lua_atpanic) (lua_State *L, lua_CFunction panicf);
typedef void            (*del_lua_call) (lua_State *L, int nargs, int nresults);
typedef int             (*del_lua_checkstack) (lua_State *L, int extra);
typedef void            (*del_lua_close) (lua_State *L);
typedef void            (*del_lua_concat) (lua_State *L, int n);
typedef int             (*del_lua_cpcall) (lua_State *L, lua_CFunction func, void *ud);
typedef void            (*del_lua_createtable) (lua_State *L, int narr, int nrec);
typedef int             (*del_lua_dump) (lua_State *L, lua_Writer writer, void *data);
typedef int             (*del_lua_equal) (lua_State *L, int index1, int index2);
typedef int             (*del_lua_error) (lua_State *L);
typedef int             (*del_lua_gc) (lua_State *L, int what, int data);
typedef lua_Alloc       (*del_lua_getallocf) (lua_State *L, void **ud);
typedef void            (*del_lua_getfenv) (lua_State *L, int index);
typedef void            (*del_lua_getfield) (lua_State *L, int index, const char *k);
typedef int             (*del_lua_getmetatable) (lua_State *L, int index);
typedef void            (*del_lua_gettable) (lua_State *L, int index);
typedef int             (*del_lua_gettop) (lua_State *L);
typedef void            (*del_lua_insert) (lua_State *L, int index);
typedef int             (*del_lua_iscfunction) (lua_State *L, int index);
typedef int             (*del_lua_isnumber) (lua_State *L, int index);
typedef int             (*del_lua_isstring) (lua_State *L, int index);
typedef int             (*del_lua_isuserdata) (lua_State *L, int index);
typedef int             (*del_lua_lessthan) (lua_State *L, int index1, int index2);
typedef int             (*del_lua_load) (lua_State *L, lua_Reader reader, void *data, const char *chunkname);
typedef lua_State *     (*del_lua_newstate) (lua_Alloc f, void *ud);
typedef lua_State *     (*del_lua_newthread) (lua_State *L);
typedef void *          (*del_lua_newuserdata) (lua_State *L, size_t size);
typedef int             (*del_lua_next) (lua_State *L, int index);
typedef size_t          (*del_lua_objlen) (lua_State *L, int index);
typedef int             (*del_lua_pcall) (lua_State *L, int nargs, int nresults, int errfunc);
typedef void            (*del_lua_pushboolean) (lua_State *L, int b);
typedef void            (*del_lua_pushcclosure) (lua_State *L, lua_CFunction fn, int n);
typedef const char *    (*del_lua_pushfstring) (lua_State *L, const char *fmt, ...);
typedef void            (*del_lua_pushinteger) (lua_State *L, lua_Integer n);
typedef void            (*del_lua_pushlightuserdata) (lua_State *L, void *p);
typedef void            (*del_lua_pushlstring) (lua_State *L, const char *s, size_t len);
typedef void            (*del_lua_pushnil) (lua_State *L);
typedef void            (*del_lua_pushnumber) (lua_State *L, lua_Number n);
typedef void            (*del_lua_pushstring) (lua_State *L, const char *s);
typedef int             (*del_lua_pushthread) (lua_State *L);
typedef void            (*del_lua_pushvalue) (lua_State *L, int index);
typedef const char *    (*del_lua_pushvfstring) (lua_State *L, const char *fmt, va_list argp);
typedef int             (*del_lua_rawequal) (lua_State *L, int index1, int index2);
typedef void            (*del_lua_rawget) (lua_State *L, int index);
typedef void            (*del_lua_rawgeti) (lua_State *L, int index, int n);
typedef void            (*del_lua_rawset) (lua_State *L, int index);
typedef void            (*del_lua_rawseti) (lua_State *L, int index, int n);
typedef void            (*del_lua_remove) (lua_State *L, int index);
typedef void            (*del_lua_replace) (lua_State *L, int index);
typedef int             (*del_lua_resume) (lua_State *L, int narg);
typedef void            (*del_lua_setallocf) (lua_State *L, lua_Alloc f, void *ud);
typedef int             (*del_lua_setfenv) (lua_State *L, int index);
typedef void            (*del_lua_setfield) (lua_State *L, int index, const char *k);
typedef int             (*del_lua_setmetatable) (lua_State *L, int index);
typedef void            (*del_lua_settable) (lua_State *L, int index);
typedef void            (*del_lua_settop) (lua_State *L, int index);
typedef int             (*del_lua_status) (lua_State *L);
typedef int             (*del_lua_toboolean) (lua_State *L, int index);
typedef lua_CFunction   (*del_lua_tocfunction) (lua_State *L, int index);
typedef lua_Integer     (*del_lua_tointeger) (lua_State *L, int index);
typedef const char *    (*del_lua_tolstring) (lua_State *L, int index, size_t *len);
typedef lua_Number      (*del_lua_tonumber) (lua_State *L, int index);
typedef const void *    (*del_lua_topointer) (lua_State *L, int index);
typedef lua_State *     (*del_lua_tothread) (lua_State *L, int index);
typedef void *          (*del_lua_touserdata) (lua_State *L, int index);
typedef int             (*del_lua_type) (lua_State *L, int index);
typedef const char *    (*del_lua_typename) (lua_State *L, int tp);
typedef void            (*del_lua_xmove) (lua_State *from, lua_State *to, int n);
typedef int             (*del_lua_yield)  (lua_State *L, int nresults);

typedef lua_Hook        (*del_lua_gethook) (lua_State *L);
typedef int             (*del_lua_gethookcount) (lua_State *L);
typedef int             (*del_lua_gethookmask) (lua_State *L);
typedef int             (*del_lua_getinfo) (lua_State *L, const char *what, lua_Debug *ar);
typedef const char *    (*del_lua_getlocal) (lua_State *L, const lua_Debug *ar, int n);
typedef int             (*del_lua_getstack) (lua_State *L, int level, lua_Debug *ar);
typedef const char *    (*del_lua_getupvalue) (lua_State *L, int funcindex, int n);
typedef int             (*del_lua_sethook) (lua_State *L, lua_Hook f, int mask, int count);
typedef const char *    (*del_lua_setlocal) (lua_State *L, const lua_Debug *ar, int n);
typedef const char *    (*del_lua_setupvalue) (lua_State *L, int funcindex, int n);

typedef void            (*del_luaL_addlstring) (luaL_Buffer *B, const char *s, size_t l);
typedef void            (*del_luaL_addstring) (luaL_Buffer *B, const char *s);
typedef void            (*del_luaL_addvalue) (luaL_Buffer *B);
typedef int             (*del_luaL_argerror) (lua_State *L, int narg, const char *extramsg);
typedef void            (*del_luaL_buffinit) (lua_State *L, luaL_Buffer *B);
typedef int             (*del_luaL_callmeta) (lua_State *L, int obj, const char *e);
typedef void            (*del_luaL_checkany) (lua_State *L, int narg);
typedef lua_Integer     (*del_luaL_checkinteger) (lua_State *L, int narg);
typedef const char *    (*del_luaL_checklstring) (lua_State *L, int narg, size_t *l);
typedef lua_Number      (*del_luaL_checknumber) (lua_State *L, int narg);
typedef int             (*del_luaL_checkoption) (lua_State *L, int narg, const char *def, const char *const lst[]);
typedef void            (*del_luaL_checkstack) (lua_State *L, int sz, const char *msg);
typedef void            (*del_luaL_checktype) (lua_State *L, int narg, int t);
typedef void *          (*del_luaL_checkudata) (lua_State *L, int narg, const char *tname);
typedef int             (*del_luaL_error) (lua_State *L, const char *fmt, ...);
typedef int             (*del_luaL_getmetafield) (lua_State *L, int obj, const char *e);
typedef const char *    (*del_luaL_gsub) (lua_State *L, const char *s, const char *p, const char *r);
typedef int             (*del_luaL_loadbuffer) (lua_State *L, const char *buff, size_t sz, const char *name);
typedef int             (*del_luaL_loadfile) (lua_State *L, const char *filename);
typedef int             (*del_luaL_loadstring) (lua_State *L, const char *s);
typedef int             (*del_luaL_newmetatable) (lua_State *L, const char *tname);
typedef lua_State *     (*del_luaL_newstate) (void);
typedef void            (*del_luaL_openlibs) (lua_State *L);
typedef lua_Integer     (*del_luaL_optinteger) (lua_State *L, int narg, lua_Integer d);
typedef const char *    (*del_luaL_optlstring) (lua_State *L, int narg, const char *d, size_t *l);
typedef lua_Number      (*del_luaL_optnumber) (lua_State *L, int narg, lua_Number d);
typedef char *          (*del_luaL_prepbuffer) (luaL_Buffer *B);
typedef void            (*del_luaL_pushresult) (luaL_Buffer *B);
typedef int             (*del_luaL_ref) (lua_State *L, int t);
typedef void            (*del_luaL_register) (lua_State *L, const char *libname, const luaL_Reg *l);
typedef int             (*del_luaL_typerror) (lua_State *L, int narg, const char *tname);
typedef void            (*del_luaL_unref) (lua_State *L, int t, int ref);
typedef void            (*del_luaL_where) (lua_State *L, int lvl);

struct LuaPluginInterface
{
    del_lua_atpanic             func_lua_atpanic;
    del_lua_call                func_lua_call;
    del_lua_checkstack          func_lua_checkstack;
    del_lua_close               func_lua_close;
    del_lua_concat              func_lua_concat;
    del_lua_cpcall              func_lua_cpcall;
    del_lua_createtable         func_lua_createtable;
    del_lua_dump                func_lua_dump;
    del_lua_equal               func_lua_equal;
    del_lua_error               func_lua_error;
    del_lua_gc                  func_lua_gc;
    del_lua_getallocf           func_lua_getallocf;
    del_lua_getfenv             func_lua_getfenv;
    del_lua_getfield            func_lua_getfield;
    del_lua_getmetatable        func_lua_getmetatable;
    del_lua_gettable            func_lua_gettable;
    del_lua_gettop              func_lua_gettop;
    del_lua_insert              func_lua_insert;
    del_lua_iscfunction         func_lua_iscfunction;
    del_lua_isnumber            func_lua_isnumber;
    del_lua_isstring            func_lua_isstring;
    del_lua_isuserdata          func_lua_isuserdata;
    del_lua_lessthan            func_lua_lessthan;
    del_lua_load                func_lua_load;
    del_lua_newstate            func_lua_newstate;
    del_lua_newthread           func_lua_newthread;
    del_lua_newuserdata         func_lua_newuserdata;
    del_lua_next                func_lua_next;
    del_lua_objlen              func_lua_objlen;
    del_lua_pcall               func_lua_pcall;
    del_lua_pushboolean         func_lua_pushboolean;
    del_lua_pushcclosure        func_lua_pushcclosure;
    del_lua_pushfstring         func_lua_pushfstring;
    del_lua_pushinteger         func_lua_pushinteger;
    del_lua_pushlightuserdata   func_lua_pushlightuserdata;
    del_lua_pushlstring         func_lua_pushlstring;
    del_lua_pushnil             func_lua_pushnil;
    del_lua_pushnumber          func_lua_pushnumber;
    del_lua_pushstring          func_lua_pushstring;
    del_lua_pushthread          func_lua_pushthread;
    del_lua_pushvalue           func_lua_pushvalue;
    del_lua_pushvfstring        func_lua_pushvfstring;
    del_lua_rawequal            func_lua_rawequal;
    del_lua_rawget              func_lua_rawget;
    del_lua_rawgeti             func_lua_rawgeti;
    del_lua_rawset              func_lua_rawset;
    del_lua_rawseti             func_lua_rawseti;
    del_lua_remove              func_lua_remove;
    del_lua_replace             func_lua_replace;
    del_lua_resume              func_lua_resume;
    del_lua_setallocf           func_lua_setallocf;
    del_lua_setfenv             func_lua_setfenv;
    del_lua_setfield            func_lua_setfield;
    del_lua_setmetatable        func_lua_setmetatable;
    del_lua_settable            func_lua_settable;
    del_lua_settop              func_lua_settop;
    del_lua_status              func_lua_status;
    del_lua_toboolean           func_lua_toboolean;
    del_lua_tocfunction         func_lua_tocfunction;
    del_lua_tointeger           func_lua_tointeger;
    del_lua_tolstring           func_lua_tolstring;
    del_lua_tonumber            func_lua_tonumber;
    del_lua_topointer           func_lua_topointer;
    del_lua_tothread            func_lua_tothread;
    del_lua_touserdata          func_lua_touserdata;
    del_lua_type                func_lua_type;
    del_lua_typename            func_lua_typename;
    del_lua_xmove               func_lua_xmove;
    del_lua_yield               func_lua_yield;

    del_lua_gethook             func_lua_gethook;
    del_lua_gethookcount        func_lua_gethookcount;
    del_lua_gethookmask         func_lua_gethookmask;
    del_lua_getinfo             func_lua_getinfo;
    del_lua_getlocal            func_lua_getlocal;
    del_lua_getstack            func_lua_getstack;
    del_lua_getupvalue          func_lua_getupvalue;
    del_lua_sethook             func_lua_sethook;
    del_lua_setlocal            func_lua_setlocal;
    del_lua_setupvalue          func_lua_setupvalue;

    del_luaL_addlstring         func_luaL_addlstring;
    del_luaL_addstring          func_luaL_addstring;
    del_luaL_addvalue           func_luaL_addvalue;
    del_luaL_argerror           func_luaL_argerror;
    del_luaL_buffinit           func_luaL_buffinit;
    del_luaL_callmeta           func_luaL_callmeta;
    del_luaL_checkany           func_luaL_checkany;
    del_luaL_checkinteger       func_luaL_checkinteger;
    del_luaL_checklstring       func_luaL_checklstring;
    del_luaL_checknumber        func_luaL_checknumber;
    del_luaL_checkoption        func_luaL_checkoption;
    del_luaL_checkstack         func_luaL_checkstack;
    del_luaL_checktype          func_luaL_checktype;
    del_luaL_checkudata         func_luaL_checkudata;
    del_luaL_error              func_luaL_error;
    del_luaL_getmetafield       func_luaL_getmetafield;
    del_luaL_gsub               func_luaL_gsub;
    del_luaL_loadbuffer         func_luaL_loadbuffer;
    del_luaL_loadfile           func_luaL_loadfile;
    del_luaL_loadstring         func_luaL_loadstring;
    del_luaL_newmetatable       func_luaL_newmetatable;
    del_luaL_newstate           func_luaL_newstate;
    del_luaL_openlibs           func_luaL_openlibs;
    del_luaL_optinteger         func_luaL_optinteger;
    del_luaL_optlstring         func_luaL_optlstring;
    del_luaL_optnumber          func_luaL_optnumber;
    del_luaL_prepbuffer         func_luaL_prepbuffer;
    del_luaL_pushresult         func_luaL_pushresult;
    del_luaL_ref                func_luaL_ref;
    del_luaL_register           func_luaL_register;
    del_luaL_typerror           func_luaL_typerror;
    del_luaL_unref              func_luaL_unref;
    del_luaL_where              func_luaL_where;

} g_LuaPluginInterface;

static IUnityInterfaces* l_pUnityInterfaces = 0;

IUnityInterfaces* UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API GetUnityInterfaces()
{
    return l_pUnityInterfaces;
}

void UNITY_INTERFACE_EXPORT UNITY_INTERFACE_API UnityPluginLoad(IUnityInterfaces* unityInterfaces)
{
    // UnityInterfaceGUID guidlua;
    // guidlua.m_GUIDHigh = 0xE472D7060BA74533UL;
    // guidlua.m_GUIDLow  = 0x88F82C3A4ADD9BBFUL;

    g_LuaPluginInterface.func_lua_atpanic           = lua_atpanic;
    g_LuaPluginInterface.func_lua_call              = lua_call;
    g_LuaPluginInterface.func_lua_checkstack        = lua_checkstack;
    g_LuaPluginInterface.func_lua_close             = lua_close;
    g_LuaPluginInterface.func_lua_concat            = lua_concat;
    g_LuaPluginInterface.func_lua_cpcall            = lua_cpcall;
    g_LuaPluginInterface.func_lua_createtable       = lua_createtable;
    g_LuaPluginInterface.func_lua_dump              = lua_dump;
    g_LuaPluginInterface.func_lua_equal             = lua_equal;
    g_LuaPluginInterface.func_lua_error             = lua_error;
    g_LuaPluginInterface.func_lua_gc                = lua_gc;
    g_LuaPluginInterface.func_lua_getallocf         = lua_getallocf;
    g_LuaPluginInterface.func_lua_getfenv           = lua_getfenv;
    g_LuaPluginInterface.func_lua_getfield          = lua_getfield;
    g_LuaPluginInterface.func_lua_getmetatable      = lua_getmetatable;
    g_LuaPluginInterface.func_lua_gettable          = lua_gettable;
    g_LuaPluginInterface.func_lua_gettop            = lua_gettop;
    g_LuaPluginInterface.func_lua_insert            = lua_insert;
    g_LuaPluginInterface.func_lua_iscfunction       = lua_iscfunction;
    g_LuaPluginInterface.func_lua_isnumber          = lua_isnumber;
    g_LuaPluginInterface.func_lua_isstring          = lua_isstring;
    g_LuaPluginInterface.func_lua_isuserdata        = lua_isuserdata;
    g_LuaPluginInterface.func_lua_lessthan          = lua_lessthan;
    g_LuaPluginInterface.func_lua_load              = lua_load;
    g_LuaPluginInterface.func_lua_newstate          = lua_newstate;
    g_LuaPluginInterface.func_lua_newthread         = lua_newthread;
    g_LuaPluginInterface.func_lua_newuserdata       = lua_newuserdata;
    g_LuaPluginInterface.func_lua_next              = lua_next;
    g_LuaPluginInterface.func_lua_objlen            = lua_objlen;
    g_LuaPluginInterface.func_lua_pcall             = lua_pcall;
    g_LuaPluginInterface.func_lua_pushboolean       = lua_pushboolean;
    g_LuaPluginInterface.func_lua_pushcclosure      = lua_pushcclosure;
    g_LuaPluginInterface.func_lua_pushfstring       = lua_pushfstring;
    g_LuaPluginInterface.func_lua_pushinteger       = lua_pushinteger;
    g_LuaPluginInterface.func_lua_pushlightuserdata = lua_pushlightuserdata;
    g_LuaPluginInterface.func_lua_pushlstring       = lua_pushlstring;
    g_LuaPluginInterface.func_lua_pushnil           = lua_pushnil;
    g_LuaPluginInterface.func_lua_pushnumber        = lua_pushnumber;
    g_LuaPluginInterface.func_lua_pushstring        = lua_pushstring;
    g_LuaPluginInterface.func_lua_pushthread        = lua_pushthread;
    g_LuaPluginInterface.func_lua_pushvalue         = lua_pushvalue;
    g_LuaPluginInterface.func_lua_pushvfstring      = lua_pushvfstring;
    g_LuaPluginInterface.func_lua_rawequal          = lua_rawequal;
    g_LuaPluginInterface.func_lua_rawget            = lua_rawget;
    g_LuaPluginInterface.func_lua_rawgeti           = lua_rawgeti;
    g_LuaPluginInterface.func_lua_rawset            = lua_rawset;
    g_LuaPluginInterface.func_lua_rawseti           = lua_rawseti;
    g_LuaPluginInterface.func_lua_remove            = lua_remove;
    g_LuaPluginInterface.func_lua_replace           = lua_replace;
    g_LuaPluginInterface.func_lua_resume            = lua_resume;
    g_LuaPluginInterface.func_lua_setallocf         = lua_setallocf;
    g_LuaPluginInterface.func_lua_setfenv           = lua_setfenv;
    g_LuaPluginInterface.func_lua_setfield          = lua_setfield;
    g_LuaPluginInterface.func_lua_setmetatable      = lua_setmetatable;
    g_LuaPluginInterface.func_lua_settable          = lua_settable;
    g_LuaPluginInterface.func_lua_settop            = lua_settop;
    g_LuaPluginInterface.func_lua_status            = lua_status;
    g_LuaPluginInterface.func_lua_toboolean         = lua_toboolean;
    g_LuaPluginInterface.func_lua_tocfunction       = lua_tocfunction;
    g_LuaPluginInterface.func_lua_tointeger         = lua_tointeger;
    g_LuaPluginInterface.func_lua_tolstring         = lua_tolstring;
    g_LuaPluginInterface.func_lua_tonumber          = lua_tonumber;
    g_LuaPluginInterface.func_lua_topointer         = lua_topointer;
    g_LuaPluginInterface.func_lua_tothread          = lua_tothread;
    g_LuaPluginInterface.func_lua_touserdata        = lua_touserdata;
    g_LuaPluginInterface.func_lua_type              = lua_type;
    g_LuaPluginInterface.func_lua_typename          = lua_typename;
    g_LuaPluginInterface.func_lua_xmove             = lua_xmove;
    g_LuaPluginInterface.func_lua_yield             = lua_yield;

    g_LuaPluginInterface.func_lua_gethook           = lua_gethook;
    g_LuaPluginInterface.func_lua_gethookcount      = lua_gethookcount;
    g_LuaPluginInterface.func_lua_gethookmask       = lua_gethookmask;
    g_LuaPluginInterface.func_lua_getinfo           = lua_getinfo;
    g_LuaPluginInterface.func_lua_getlocal          = lua_getlocal;
    g_LuaPluginInterface.func_lua_getstack          = lua_getstack;
    g_LuaPluginInterface.func_lua_getupvalue        = lua_getupvalue;
    g_LuaPluginInterface.func_lua_sethook           = lua_sethook;
    g_LuaPluginInterface.func_lua_setlocal          = lua_setlocal;
    g_LuaPluginInterface.func_lua_setupvalue        = lua_setupvalue;

    g_LuaPluginInterface.func_luaL_addlstring       = luaL_addlstring;
    g_LuaPluginInterface.func_luaL_addstring        = luaL_addstring;
    g_LuaPluginInterface.func_luaL_addvalue         = luaL_addvalue;
    g_LuaPluginInterface.func_luaL_argerror         = luaL_argerror;
    g_LuaPluginInterface.func_luaL_buffinit         = luaL_buffinit;
    g_LuaPluginInterface.func_luaL_callmeta         = luaL_callmeta;
    g_LuaPluginInterface.func_luaL_checkany         = luaL_checkany;
    g_LuaPluginInterface.func_luaL_checkinteger     = luaL_checkinteger;
    g_LuaPluginInterface.func_luaL_checklstring     = luaL_checklstring;
    g_LuaPluginInterface.func_luaL_checknumber      = luaL_checknumber;
    g_LuaPluginInterface.func_luaL_checkoption      = luaL_checkoption;
    g_LuaPluginInterface.func_luaL_checkstack       = luaL_checkstack;
    g_LuaPluginInterface.func_luaL_checktype        = luaL_checktype;
    g_LuaPluginInterface.func_luaL_checkudata       = luaL_checkudata;
    g_LuaPluginInterface.func_luaL_error            = luaL_error;
    g_LuaPluginInterface.func_luaL_getmetafield     = luaL_getmetafield;
    g_LuaPluginInterface.func_luaL_gsub             = luaL_gsub;
    g_LuaPluginInterface.func_luaL_loadbuffer       = luaL_loadbuffer;
    g_LuaPluginInterface.func_luaL_loadfile         = luaL_loadfile;
    g_LuaPluginInterface.func_luaL_loadstring       = luaL_loadstring;
    g_LuaPluginInterface.func_luaL_newmetatable     = luaL_newmetatable;
    g_LuaPluginInterface.func_luaL_newstate         = luaL_newstate;
    g_LuaPluginInterface.func_luaL_openlibs         = luaL_openlibs;
    g_LuaPluginInterface.func_luaL_optinteger       = luaL_optinteger;
    g_LuaPluginInterface.func_luaL_optlstring       = luaL_optlstring;
    g_LuaPluginInterface.func_luaL_optnumber        = luaL_optnumber;
    g_LuaPluginInterface.func_luaL_prepbuffer       = luaL_prepbuffer;
    g_LuaPluginInterface.func_luaL_pushresult       = luaL_pushresult;
    g_LuaPluginInterface.func_luaL_ref              = luaL_ref;
    g_LuaPluginInterface.func_luaL_register         = luaL_register;
    g_LuaPluginInterface.func_luaL_typerror         = luaL_typerror;
    g_LuaPluginInterface.func_luaL_unref            = luaL_unref;
    g_LuaPluginInterface.func_luaL_where            = luaL_where;

    l_pUnityInterfaces = unityInterfaces;
    unityInterfaces->RegisterInterfaceSplit(0xE472D7060BA74533UL, 0x88F82C3A4ADD9BBFUL, &g_LuaPluginInterface);
}
