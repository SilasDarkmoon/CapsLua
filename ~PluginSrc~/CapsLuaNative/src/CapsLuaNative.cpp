// CapsLuaNative.cpp : 定义 DLL 应用程序的导出函数。
//

#include "LuaImport.h"

#if _WIN32
#define EXPORT_API __declspec(dllexport)
#else
#define EXPORT_API
#endif

extern "C"
{
    typedef void(*Func_PushType)(lua_State *l, void* typeref);
    static Func_PushType capsluacs_pushType = 0;
    static lua_CFunction capsluacs_rawgc = 0;
    static lua_CFunction capsluacs_cachedgc = 0;
    static lua_CFunction capsluacs_rawtostr = 0;
    static lua_CFunction capsluacs_onError = 0;
    static lua_CFunction capsluacs_ggetter = 0;
    static lua_CFunction capsluacs_gsetter = 0;
    static lua_CFunction capsluacs_raweq = 0;
    
    // extend
    static void* capsluacs_exttrans = 0;
    static void MakeExtendObj(lua_State* l, int index);
    static void MakeExtendType(lua_State* l, int index);
    static void MakeExtendCallable(lua_State* l, int index, int targetIndex);
    EXPORT_API void MakeExtend(lua_State* l, int index);
    static void MakeExtendImp(lua_State* l, int index, int targetIndex);
    EXPORT_API void MakeUnextend(lua_State* l, int index);
    static void CreateExtendMeta(lua_State* l);
    static int IsExtended(lua_State* l, int index);
    static int LuaMetaExtCall(lua_State* l);
    static int LuaMetaExtIndex(lua_State* l);
    static int LuaMetaExtNewIndex(lua_State* l);
    static int LuaMetaExtBinOp(lua_State* l);
    static int LuaMetaExtUnaryOp(lua_State* l);
    
    EXPORT_API int capslua_checkVer(int ver)
    {
        #if !TARGET_OS_IPHONE
        if (g_pLuaPluginInterface == 0)
        {
            return 0;
        }
        #endif
        if (ver != 15)
        {
            return 0;
        }
        else
        {
            return 1;
        }
    }
    
    EXPORT_API void capslua_setCSFuncs(
    Func_PushType funcPushType
    , lua_CFunction func_Rawgc
    , lua_CFunction func_Cachedgc
    , lua_CFunction func_RawToStr
    , lua_CFunction func_OnError
    , lua_CFunction func_GGetter
    , lua_CFunction func_GSetter
    , lua_CFunction func_RawEq
    , void* extTrans
    )
    {
        capsluacs_pushType = funcPushType;
        capsluacs_rawgc = func_Rawgc;
        capsluacs_cachedgc = func_Cachedgc;
        capsluacs_rawtostr = func_RawToStr;
        capsluacs_onError = func_OnError;
        capsluacs_ggetter = func_GGetter;
        capsluacs_gsetter = func_GSetter;
        capsluacs_raweq = func_RawEq;
        capsluacs_exttrans = extTrans;
    }
    
    static int LuaMetaWrapCall(lua_State *l)
    {
        int oldtop = lua_gettop(l);
        lua_checkstack(l, oldtop + 2);
        lua_pushcfunction(l, capsluacs_onError); // err
        lua_pushvalue(l, lua_upvalueindex(1)); // err realfunc
        int argc = 0;
        int i;
        for (i = 2; i <= oldtop; ++i)
        {
            ++argc;
            lua_pushvalue(l, i);
        }
        // err realfunc args(*argc)
        lua_pcall(l, argc, LUA_MULTRET, oldtop + 1); // err rv(*n)
        lua_remove(l, oldtop + 1); // rv(*n)
        return lua_gettop(l) - oldtop;
    }
    
    EXPORT_API void capslua_wrapFunctionByTable(lua_State *l, void* methodmeta)
    {
        // rawfunc
        lua_checkstack(l, 5);
        lua_newtable(l); // rawfunc ftab
        lua_pushlightuserdata(l, (void*)2303); // rawfunc ftab #trans
        lua_pushlightuserdata(l, methodmeta); // rawfunc ftab #trans trans
        lua_rawset(l, -3); // rawfunc ftab
        lua_pushlightuserdata(l, (void*)2201); // rawfunc ftab #tar
        lua_pushvalue(l, -3); // rawfunc ftab #tar rawfunc
        lua_rawset(l, -3); // rawfunc ftab
        lua_newtable(l); // rawfunc ftab meta
        lua_pushstring(l, "__call"); // rawfunc ftab meta __call
        lua_pushvalue(l, -4); // rawfunc ftab meta __call rawfunc
        lua_pushcclosure(l, LuaMetaWrapCall, 1); // rawfunc ftab meta __call func
        lua_rawset(l, -3); // rawfunc ftab meta
        lua_pushlightuserdata(l, (void*)2401);
        lua_pushnumber(l, 3);
        lua_rawset(l, -3);
        lua_setmetatable(l, -2); // rawfunc ftab
        lua_remove(l, -2); // ftab
    }
    
    static int LuaMetaTypeIndex(lua_State *l)
    {
        lua_pushcfunction(l, capsluacs_onError); // err
        lua_pushvalue(l, 2); // err key
        lua_gettable(l, lua_upvalueindex(1)); // err getter
        if (!lua_isnoneornil(l, -1))
        {
            lua_pcall(l, 0, 1, -2); // err rv
            lua_remove(l, -2); // rv
            return 1;
        }
        lua_pop(l, 2); // X
        lua_pushvalue(l, 2); // key
        lua_gettable(l, lua_upvalueindex(2)); // rv
        if (!lua_isnoneornil(l, -1))
        {
            return 1;
        }
        lua_pop(l, 1); // X
        if (lua_istable(l, 2))
        {
            int rv = capsluacs_ggetter(l);
            if (rv > 0)
            {
                return rv;
            }
        }
        lua_pushvalue(l, 2); // key
        lua_gettable(l, lua_upvalueindex(4)); // rv;
        return 1;
    }
    
    EXPORT_API void capslua_pushTypeIndex(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaTypeIndex, n_upvalue);
    }
    
    static int LuaMetaTypeNewIndex(lua_State *l)
    {
        if (lua_istable(l, 2))
        {
            int rv = capsluacs_gsetter(l);
            if (rv > 0)
            {
                lua_pop(l, rv);
                return 0;
            }
        }
        lua_pushcfunction(l, capsluacs_onError); // err
        lua_pushvalue(l, 2); // err key
        lua_gettable(l, lua_upvalueindex(1)); // err setter
        if (!lua_isnoneornil(l, -1))
        {
            lua_pushvalue(l, 3); // err setter v
            lua_pcall(l, 1, 0, -3); // err
            lua_pop(l, 1); // X
            return 0;
        }
        lua_pop(l, 2); // X
        
        // try set properties on type-obj.
        if (lua_isnil(l, 3))
        {
            lua_pushvalue(l, 2); // k
            lua_pushvalue(l, 3); // k v
            lua_settable(l, lua_upvalueindex(2)); // X
            return 0;
        }
        else
        {
            lua_pushvalue(l, 2); // k
            lua_pushvalue(l, 3); // k v
            lua_settable(l, lua_upvalueindex(2)); // X
            lua_pushvalue(l, 2); // k
            lua_rawget(l, lua_upvalueindex(2)); // v'
            if (lua_isnoneornil(l, -1))
            {
                // set C# property
                lua_pop(l, 1); // X
                return 0;
            }
            else
            {
                // set type-obj's ex-fields
                lua_pop(l, 1);
                lua_pushvalue(l, 2); // k
                lua_pushnil(l); // k nil
                lua_rawset(l, lua_upvalueindex(2)); // X
                lua_pushvalue(l, 2); // k
                lua_pushvalue(l, 3); // k v
                lua_rawset(l, 1); // X
                return 0;
            }
        }
    }
    
    EXPORT_API void capslua_pushTypeNewIndex(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaTypeNewIndex, n_upvalue);
    }
    
    static int LuaMetaObjIndex(lua_State *l)
    {
        lua_pushvalue(l, 2); // k
        lua_gettable(l, lua_upvalueindex(1)); // rv
        if (!lua_isnoneornil(l, -1))
        {
            return 1;
        }
        lua_pop(l, 1); // X
        lua_pushcfunction(l, capsluacs_onError); // err
        lua_pushvalue(l, 2); // err k
        lua_gettable(l, lua_upvalueindex(2)); // err getter
        if (!lua_isnoneornil(l, -1))
        {
            lua_pushvalue(l, 1); // err getter tar
            lua_pcall(l, 1, 1, -3); // err rv
            lua_remove(l, -2); // rv
            return 1;
        }
        lua_pop(l, 2); // X
        
        if (!lua_isnoneornil(l, lua_upvalueindex(3)))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(3)); // err indexerkey
            lua_rawget(l, lua_upvalueindex(2)); // err indexer
            lua_pushvalue(l, 1); // err indexer tar
            lua_pushvalue(l, 2); // err indexer tar key
            lua_pcall(l, 2, 1, -4); // err rv
            lua_remove(l, -2); // rv
            return 1;
        }
        return 0;
    }
    
    EXPORT_API void capslua_pushObjIndex(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaObjIndex, n_upvalue);
    }
    
    static int LuaMetaObjNewIndex(lua_State *l)
    {
        lua_pushcfunction(l, capsluacs_onError); // err
        lua_pushvalue(l, 2); // err k
        lua_gettable(l, lua_upvalueindex(2)); // err setter
        if (!lua_isnoneornil(l, -1))
        {
            lua_pushvalue(l, 1); // err setter tar
            lua_pushvalue(l, 3); // err setter tar val
            lua_pcall(l, 2, 0, -4); // err
            lua_pop(l, 1); // X
            return 0;
        }
        lua_pop(l, 2); // X
        
        if (!lua_isnoneornil(l, lua_upvalueindex(3)))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(3)); // err indexerkey
            lua_rawget(l, lua_upvalueindex(2)); // err indexer
            lua_pushvalue(l, 1); // err indexer tar
            lua_pushvalue(l, 2); // err indexer tar key
            lua_pushvalue(l, 3); // err indexer tar key val
            lua_pcall(l, 3, 1, -5); // err failed
            int failed = lua_toboolean(l, -1);
            lua_pop(l, 2); // X
            if (!failed)
            {
                return 0;
            }
        }
        
        // raw set
        lua_pushvalue(l, 1);
        lua_pushvalue(l, 2);
        lua_pushvalue(l, 3);
        lua_rawset(l, -3);
        lua_pop(l, 1);
        return 0;
    }
    
    EXPORT_API void capslua_pushObjNewIndex(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaObjNewIndex, n_upvalue);
    }
    
    static int LuaMetaCommonBinaryOp(lua_State* l)
    {
        if (lua_type(l, 1) == LUA_TUSERDATA || lua_istable(l, 1))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(1)); // err "op"
            lua_gettable(l, 1); // err func1
            if (lua_isfunction(l, -1))
            {
                lua_pushvalue(l, 1); // err func1 op1
                lua_pushvalue(l, 2); // err func1 op1 op2
                lua_pcall(l, 2, 2, -4); // err rv failed
                if (!lua_toboolean(l, -1))
                {
                    lua_pop(l, 1); // err rv
                    lua_insert(l, 3); // rv err
                    lua_settop(l, 3); // rv
                    return 1;
                }
            }
            lua_settop(l, 2); // X
        }
        if (lua_type(l, 2) == LUA_TUSERDATA || lua_istable(l, 2))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(1)); // err "op"
            lua_gettable(l, 2); // err func2
            if (lua_isfunction(l, -1))
            {
                lua_pushvalue(l, 1); // err func2 op1
                lua_pushvalue(l, 2); // err func2 op1 op2
                lua_pcall(l, 2, 2, -4); // err rv failed
                if (!lua_toboolean(l, -1))
                {
                    lua_pop(l, 1); // err rv
                    lua_insert(l, 3); // rv err
                    lua_settop(l, 3); // rv
                    return 1;
                }
            }
            lua_settop(l, 2); // X
        }
        return 0;
    }
    
    EXPORT_API void capslua_pushCommonBinaryOp(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaCommonBinaryOp, n_upvalue);
    }
    
    static int LuaMetaCommonEq(lua_State* l)
    {
        int oldtop = lua_gettop(l);
        lua_pushvalue(l, lua_upvalueindex(1)); // binop
        lua_pushvalue(l, 1);
        lua_pushvalue(l, 2);
        lua_call(l, 2, LUA_MULTRET);
        int rv = lua_gettop(l) - oldtop;
        if (rv > 0)
        {
            return rv;
        }
        return capsluacs_raweq(l);
    }
    
    EXPORT_API void capslua_pushCommonEq(lua_State *l, int n_upvalue)
    {
        lua_pushcclosure(l, LuaMetaCommonEq, n_upvalue);
    }
    
    // liveness tracker
    static void PushTrackerReg(lua_State* l)
    {
        lua_checkstack(l, 1);
        lua_pushlightuserdata(l, (void*)1008);
        lua_gettable(l, LUA_REGISTRYINDEX);
    }
    static void PushOrCreateTrackerReg(lua_State* l)
    {
        lua_checkstack(l, 5);
        lua_pushlightuserdata(l, (void*)1008); // key
        lua_gettable(l, LUA_REGISTRYINDEX); // reg
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // X
            lua_newtable(l); // reg
            lua_pushlightuserdata(l, (void*)1008); // reg key
            lua_pushvalue(l, -2); // reg key reg
            lua_settable(l, LUA_REGISTRYINDEX); // reg
            lua_newtable(l); // reg meta
            lua_pushstring(l, "k"); // reg meta "k"
            lua_setfield(l, -2, "__mode"); // reg meta
            lua_setmetatable(l, -2); // reg
        }
    }
    EXPORT_API void capslua_trackLiveness(lua_State* l, int index)
    {
        lua_pushvalue(l, index); // tab
        PushOrCreateTrackerReg(l); // tab reg
        lua_insert(l, -2); // reg tab
        lua_pushboolean(l, 1); // reg tab true
        lua_settable(l, -3); // reg
        lua_pop(l, 1); // X
    }
    EXPORT_API int capslua_checkLiveness(lua_State* l, int index)
    {
        lua_pushvalue(l, index); // tab
        PushTrackerReg(l); // tab reg
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 2);
            return 0;
        }
        lua_insert(l, -2); // reg tab
        lua_gettable(l, -2); // reg alive?
        int valid = lua_toboolean(l, -1);
        lua_pop(l, 2);
        return valid;
    }

    // extend
    static void MakeExtendObj(lua_State* l, int index)
    {
        lua_checkstack(l, 4);
        index = abs_index(l, index);
        lua_newtable(l); // ext
        lua_pushlightuserdata(l, (void*)2201); // ext #tar
        lua_pushvalue(l, index); // ext #tar tar
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2303); // ext #trans
        lua_pushlightuserdata(l, capsluacs_exttrans); // ext #trans trans
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_pushnumber(l, 1); // ext #ext 1
        lua_rawset(l, -3); // ext
        
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_gettable(l, LUA_REGISTRYINDEX); // ext meta
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // ext
            CreateExtendMeta(l); // ext meta
            lua_pushlightuserdata(l, (void*)2401); // ext meta #ext
            lua_pushvalue(l, -2); // ext meta #ext meta
            lua_settable(l, LUA_REGISTRYINDEX); // ext meta
        }
        lua_setmetatable(l, -2); // ext
        lua_replace(l, index);
    }
    static void MakeExtendType(lua_State* l, int index)
    {
        lua_checkstack(l, 4);
        index = abs_index(l, index);
        lua_newtable(l); // ext
        lua_pushlightuserdata(l, (void*)2201); // ext #tar
        lua_pushvalue(l, index); // ext #tar tar
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2303); // ext #trans
        lua_pushlightuserdata(l, capsluacs_exttrans); // ext #trans trans
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_pushnumber(l, 2); // ext #ext 2
        lua_rawset(l, -3); // ext
        
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_gettable(l, LUA_REGISTRYINDEX); // ext meta
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // ext
            CreateExtendMeta(l); // ext meta
            lua_pushlightuserdata(l, (void*)2401); // ext meta #ext
            lua_pushvalue(l, -2); // ext meta #ext meta
            lua_settable(l, LUA_REGISTRYINDEX); // ext meta
        }
        lua_setmetatable(l, -2); // ext
        lua_replace(l, index);
    }
    static void MakeExtendCallable(lua_State* l, int index, int targetIndex)
    {
        lua_checkstack(l, 4);
        index = abs_index(l, index);
        if (targetIndex != 0)
        {
            targetIndex = abs_index(l, targetIndex);
        }
        lua_newtable(l); // ext
        lua_pushlightuserdata(l, (void*)2201); // ext #tar
        lua_pushvalue(l, index); // ext #tar tar
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2303); // ext #trans
        lua_pushlightuserdata(l, capsluacs_exttrans); // ext #trans trans
        lua_rawset(l, -3); // ext
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_pushnumber(l, 3); // ext #ext 3
        lua_rawset(l, -3); // ext
        if (targetIndex != 0)
        {
            lua_pushlightuserdata(l, (void*)2402);
            lua_pushvalue(l, targetIndex);
            lua_rawset(l, -3);
        }
        
        lua_pushlightuserdata(l, (void*)2401); // ext #ext
        lua_gettable(l, LUA_REGISTRYINDEX); // ext meta
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // ext
            CreateExtendMeta(l); // ext meta
            lua_pushlightuserdata(l, (void*)2401); // ext meta #ext
            lua_pushvalue(l, -2); // ext meta #ext meta
            lua_settable(l, LUA_REGISTRYINDEX); // ext meta
        }
        lua_setmetatable(l, -2); // ext
        lua_replace(l, index);
    }
    EXPORT_API void MakeExtend(lua_State* l, int index)
    {
        MakeExtendImp(l, index, 0);
    }
    static void MakeExtendImp(lua_State* l, int index, int targetIndex)
    {
        if (lua_type(l, index) == LUA_TUSERDATA)
        {
            MakeExtendObj(l, index);
        }
        else if (lua_istable(l, index))
        {
            int exttype = 0;
            if (lua_getmetatable(l, index)) // meta
            {
                lua_pushlightuserdata(l, (void*)2401); // meta #ext
                lua_rawget(l, -2); // meta exttype
                exttype = (int)lua_tonumber(l, -1);
                lua_pop(l, 2); // X
            }
            
            switch (exttype)
            {
                case 1:
                MakeExtendObj(l, index);
                break;
                case 2:
                MakeExtendType(l, index);
                break;
                case 3:
                MakeExtendCallable(l, index, targetIndex);
                break;
            }
        }
    }
    EXPORT_API void MakeUnextend(lua_State* l, int index)
    {
        if (lua_istable(l, index) && IsExtended(l, index))
        {
            index = abs_index(l, index);
            lua_pushlightuserdata(l, (void*)2201); // #tar
            lua_gettable(l, index); // tar
            lua_replace(l, index);
        }
    }
    static void CreateExtendMeta(lua_State* l)
    {
        lua_checkstack(l, 4);
        lua_newtable(l);
        lua_pushstring(l, "__call");
        lua_pushcfunction(l, LuaMetaExtCall);
        lua_rawset(l, -3);
        lua_pushstring(l, "__index");
        lua_pushcfunction(l, LuaMetaExtIndex);
        lua_rawset(l, -3);
        lua_pushstring(l, "__newindex");
        lua_pushcfunction(l, LuaMetaExtNewIndex);
        lua_rawset(l, -3);
        lua_pushstring(l, "__eq");
        
        lua_pushlightuserdata(l, (void*)2107); // mkey
        lua_gettable(l, LUA_REGISTRYINDEX); // meta
        if (!lua_isfunction(l, -1))
        {
            lua_pop(l, 1); // X
            lua_pushstring(l, "@==");
            capslua_pushCommonBinaryOp(l, 1);
            capslua_pushCommonEq(l, 1);
            lua_pushlightuserdata(l, (void*)2107); // meta mkey
            lua_pushvalue(l, -2); // meta mkey meta
            lua_settable(l, LUA_REGISTRYINDEX); // meta
        }
        
        lua_rawset(l, -3);
        
        // bin-op
        lua_pushstring(l, "__add");
        lua_pushstring(l, "@+");
        lua_pushcclosure(l, LuaMetaExtBinOp, 1);
        lua_rawset(l, -3);
        lua_pushstring(l, "__sub");
        lua_pushstring(l, "@-");
        lua_pushcclosure(l, LuaMetaExtBinOp, 1);
        lua_rawset(l, -3);
        lua_pushstring(l, "__mul");
        lua_pushstring(l, "@*");
        lua_pushcclosure(l, LuaMetaExtBinOp, 1);
        lua_rawset(l, -3);
        lua_pushstring(l, "__div");
        lua_pushstring(l, "@/");
        lua_pushcclosure(l, LuaMetaExtBinOp, 1);
        lua_rawset(l, -3);
        
        // unary-op
        lua_pushstring(l, "__unm");
        lua_pushvalue(l, -1);
        lua_pushcclosure(l, LuaMetaExtUnaryOp, 1);
        lua_rawset(l, -3);
    }
    static int IsExtended(lua_State* l, int index)
    {
        int extended = 0;
        if (lua_istable(l, index))
        {
            index = abs_index(l, index);
            lua_pushlightuserdata(l, (void*)2401); // #ext
            lua_gettable(l, index); // ext
            extended = lua_toboolean(l, -1);
            lua_pop(l, 1);
        }
        return extended;
    }
    static int LuaMetaExtCall(lua_State* l)
    {
        int oldtop = lua_gettop(l);
        lua_pushvalue(l, 1); // func
        MakeUnextend(l, -1);
        lua_pushlightuserdata(l, (void*)2402);
        lua_gettable(l, 1); // func tar
        if (lua_isnoneornil(l, -1))
        {
            lua_pop(l, 1); // func
        }
        else
        {
            MakeUnextend(l, -1);
        }
        int i;
        for (i = 2; i <= oldtop; ++i)
        {
            lua_pushvalue(l, i);
            MakeUnextend(l, -1);
        }
        lua_call(l, lua_gettop(l) - oldtop - 1, LUA_MULTRET);
        int rvcnt = lua_gettop(l) - oldtop;
        for (i = 1; i <= rvcnt; ++i)
        {
            MakeExtend(l, i + oldtop);
        }
        return rvcnt;
    }
    static int LuaMetaExtIndex(lua_State* l)
    {
        lua_pushvalue(l, 1); // obj
        MakeUnextend(l, -1);
        lua_pushvalue(l, 2); // obj key
        MakeUnextend(l, -1);
        lua_gettable(l, -2); // obj val
        
        int exttype = 0;
        lua_pushlightuserdata(l, (void*)2401); // obj val #ext
        lua_gettable(l, 1); // obj val exttype
        exttype = (int)lua_tonumber(l, -1);
        lua_pop(l, 1); // obj val
        switch (exttype)
        {
            case 2:
            MakeExtend(l, -1);
            break;
            case 1:
            {
                if (lua_isfunction(l, -1))
                {
                    lua_pushvalue(l, -1);
                    lua_gettable(l, -3);
                    if (lua_toboolean(l, -1))
                    {
                        MakeExtendCallable(l, -2, 1);
                    }
                    lua_pop(l, 1);
                }
                else
                {
                    MakeExtendImp(l, -1, 1);
                }
            }
            break;
            case 3:
            {
                lua_pushlightuserdata(l, (void*)2402);
                lua_gettable(l, 1);
                if (lua_isnoneornil(l, -1))
                {
                    lua_pop(l, 1);
                    MakeExtendCallable(l, -1, 0);
                }
                else
                {
                    // obj val tar
                    MakeExtendCallable(l, -2, -1);
                    lua_pop(l, 1); // obj val
                }
            }
            break;
        }
        lua_remove(l, -2); // val
        
        return 1;
    }
    static int LuaMetaExtNewIndex(lua_State* l)
    {
        lua_pushvalue(l, 1); // obj
        MakeUnextend(l, -1);
        lua_pushvalue(l, 2); // obj key
        MakeUnextend(l, -1);
        lua_pushvalue(l, 3); // obj key val
        MakeUnextend(l, -1);
        lua_settable(l, -3); // obj
        lua_pop(l, 1); // X
        return 0;
    }
    static int LuaMetaExtBinOp(lua_State* l)
    {
        if (lua_type(l, 1) == LUA_TUSERDATA || lua_istable(l, 1))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(1)); // err "op"
            lua_gettable(l, 1); // err func1
            if (lua_isfunction(l, -1))
            {
                lua_pushvalue(l, 1); // err func1 op1
                MakeUnextend(l, -1);
                lua_pushvalue(l, 2); // err func1 op1 op2
                MakeUnextend(l, -1);
                lua_pcall(l, 2, 2, -4); // err rv failed
                if (!lua_toboolean(l, -1))
                {
                    lua_pop(l, 1); // err rv
                    lua_insert(l, 3); // rv err
                    lua_settop(l, 3); // rv
                    MakeExtend(l, -1);
                    return 1;
                }
            }
            lua_settop(l, 2); // X
        }
        if (lua_type(l, 2) == LUA_TUSERDATA || lua_istable(l, 2))
        {
            lua_pushcfunction(l, capsluacs_onError); // err
            lua_pushvalue(l, lua_upvalueindex(1)); // err "op"
            lua_gettable(l, 2); // err func2
            if (lua_isfunction(l, -1))
            {
                lua_pushvalue(l, 1); // err func1 op1
                MakeUnextend(l, -1);
                lua_pushvalue(l, 2); // err func1 op1 op2
                MakeUnextend(l, -1);
                lua_pcall(l, 2, 2, -4); // err rv failed
                if (!lua_toboolean(l, -1))
                {
                    lua_pop(l, 1); // err rv
                    lua_insert(l, 3); // rv err
                    lua_settop(l, 3); // rv
                    MakeExtend(l, -1);
                    return 1;
                }
            }
            lua_settop(l, 2); // X
        }
        return 0;
    }
    static int LuaMetaExtUnaryOp(lua_State* l)
    {
        lua_pushvalue(l, 1); // obj
        MakeUnextend(l, -1);
        if (lua_getmetatable(l, -1)) // obj meta
        {
            lua_pushvalue(l, lua_upvalueindex(1)); // obj meta $op
            lua_rawget(l, -2); // obj meta op
            if (lua_isnoneornil(l, -1))
            {
                lua_pop(l, 3); // X
                return 0;
            }
            lua_remove(l, -2); // obj op
            lua_insert(l, -2); // op obj
            lua_call(l, 1, 1); // rv
            MakeExtend(l, -1);
            return 1;
        }
        else // obj
        {
            lua_pop(l, 1); // X
            return 0;
        }
    }
    
    // push-objs
    EXPORT_API void capslua_pushObject(lua_State *l, void* obj, void* type, int shouldcache)
    {
        lua_checkstack(l, 6);
        
        lua_newtable(l); // otab
        lua_pushlightuserdata(l, (void*)2201); // otab #tar
        void** pud = (void**)lua_newuserdata(l, sizeof(void*)); // otab #tar ud
        *pud = obj;
        
        if (shouldcache)
        {
            lua_pushlightuserdata(l, (void*)2109); // otab #tar ud #rawmeta
            lua_gettable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
            if (!lua_istable(l, -1))
            {
                lua_pop(l, 1); // otab #tar ud
                lua_newtable(l); // otab #tar ud rawmeta
                lua_pushcfunction(l, capsluacs_cachedgc); // otab #tar ud rawmeta gc
                lua_setfield(l, -2, "__gc"); // otab #tar ud rawmeta
                lua_pushcfunction(l, capsluacs_rawtostr); // otab #tar ud rawmeta tostr
                lua_setfield(l, -2, "__tostring"); // otab #tar ud rawmeta
                lua_pushlightuserdata(l, (void*)2109); // otab #tar ud rawmeta #rawmeta
                lua_pushvalue(l, -2); // otab #tar ud rawmeta #rawmeta rawmeta
                lua_settable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
            }
            lua_setmetatable(l, -2); // otab #tar ud
            lua_rawset(l, -3); // otab
        }
        else
        {
            lua_pushlightuserdata(l, (void*)2103); // otab #tar ud #rawmeta
            lua_gettable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
            if (!lua_istable(l, -1))
            {
                lua_pop(l, 1); // otab #tar ud
                lua_newtable(l); // otab #tar ud rawmeta
                lua_pushcfunction(l, capsluacs_rawgc); // otab #tar ud rawmeta gc
                lua_setfield(l, -2, "__gc"); // otab #tar ud rawmeta
                lua_pushcfunction(l, capsluacs_rawtostr); // otab #tar ud rawmeta tostr
                lua_setfield(l, -2, "__tostring"); // otab #tar ud rawmeta
                lua_pushlightuserdata(l, (void*)2103); // otab #tar ud rawmeta #rawmeta
                lua_pushvalue(l, -2); // otab #tar ud rawmeta #rawmeta rawmeta
                lua_settable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
            }
            lua_setmetatable(l, -2); // otab #tar ud
            lua_rawset(l, -3); // otab
        }
        
        lua_pushlightuserdata(l, (void*)2303); // otab #trans
        lua_pushlightuserdata(l, type); // otab #trans trans
        lua_rawset(l, -3); // otab
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, type); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, type); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    
    EXPORT_API void capslua_setObject(lua_State *l, int index, void* obj)
    {
        lua_checkstack(l, 6);
        
        index = abs_index(l, index);
        
        lua_pushlightuserdata(l, (void*)2201); // otab #tar
        void** pud = (void**)lua_newuserdata(l, sizeof(void*)); // otab #tar ud
        *pud = obj;
        
        lua_pushlightuserdata(l, (void*)2103); // otab #tar ud #rawmeta
        lua_gettable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab #tar ud
            lua_newtable(l); // otab #tar ud rawmeta
            lua_pushcfunction(l, capsluacs_rawgc); // otab #tar ud rawmeta gc
            lua_setfield(l, -2, "__gc"); // otab #tar ud rawmeta
            lua_pushcfunction(l, capsluacs_rawtostr); // otab #tar ud rawmeta tostr
            lua_setfield(l, -2, "__tostring"); // otab #tar ud rawmeta
            lua_pushlightuserdata(l, (void*)2103); // otab #tar ud rawmeta #rawmeta
            lua_pushvalue(l, -2); // otab #tar ud rawmeta #rawmeta rawmeta
            lua_settable(l, LUA_REGISTRYINDEX); // otab #tar ud rawmeta
        }
        lua_setmetatable(l, -2); // otab #tar ud
        lua_rawset(l, index); // otab
    }
    
    EXPORT_API void capslua_getObject(lua_State *l, int index, void** obj)
    {
        lua_checkstack(l, 2);
        
        index = abs_index(l, index);
        
        lua_pushlightuserdata(l, (void*)2201); // otab #tar
        lua_rawget(l, index); // otab tar
        void** pud = (void**)lua_touserdata(l, -1);
        lua_pop(l, 1); // otab
        *obj = *pud;
    }
    
    EXPORT_API int capslua_pushString(lua_State* l, int id)
    {
        lua_checkstack(l, 10);
        lua_pushlightuserdata(l, (void*)1001); // rkey
        lua_gettable(l, LUA_REGISTRYINDEX); // reg
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // X
            lua_newtable(l); // reg
            lua_pushlightuserdata(l, (void*)1001); // reg rkey
            lua_pushvalue(l, -2); // reg rkey reg
            lua_settable(l, LUA_REGISTRYINDEX); // reg
        }
        
        lua_pushnumber(l, 1); // reg 1
        lua_gettable(l, -2); // reg map
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // reg
            lua_newtable(l); // reg map
            lua_pushnumber(l, 1); // reg map 1
            lua_pushvalue(l, -2); // reg map 1 map
            lua_settable(l, -4); // reg map
        }
        
        lua_pushnumber(l, id); // reg map id
        lua_gettable(l, -2); // reg map str
        if (lua_type(l, -1) == LUA_TSTRING)
        {
            lua_insert(l, -3); // str reg map
            lua_pop(l, 2); // str
            return true;
        }
        else
        {
            lua_pop(l, 1); // reg map
            lua_pushnumber(l, 2); // reg map 2
            lua_gettable(l, -3); // reg map revmap
            if (!lua_istable(l, -1))
            {
                lua_pop(l, 1); // reg map
                lua_newtable(l); // reg map revmap
                lua_pushnumber(l, 2); // reg map revmap 2
                lua_pushvalue(l, -2); // reg map revmap 2 revmap
                lua_settable(l, -5); // reg map revmap
            }
            return false;
        }
    }
    EXPORT_API void capslua_pushAndRegString(lua_State* l, int id, const char* str)
    {
        lua_pushstring(l, str); // reg map revmap str
        lua_pushnumber(l, id); // reg map revmap str id
        lua_pushvalue(l, -2); // reg map revmap str id str
        lua_pushvalue(l, -1); // reg map revmap str id str str
        lua_pushvalue(l, -3); // reg map revmap str id str str id
        lua_settable(l, -6); // reg map revmap str id str
        lua_settable(l, -5); // reg map revmap str
        lua_insert(l, -4); // str reg map revmap
        lua_pop(l, 3); // str
    }
    EXPORT_API void capslua_regString(lua_State* l, int id, const char* str)
    {
        lua_checkstack(l, 8);
        lua_pushlightuserdata(l, (void*)1001); // rkey
        lua_gettable(l, LUA_REGISTRYINDEX); // reg
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // X
            lua_newtable(l); // reg
            lua_pushlightuserdata(l, (void*)1001); // reg rkey
            lua_pushvalue(l, -2); // reg rkey reg
            lua_settable(l, LUA_REGISTRYINDEX); // reg
        }
        
        lua_pushnumber(l, 1); // reg 1
        lua_gettable(l, -2); // reg map
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // reg
            lua_newtable(l); // reg map
            lua_pushnumber(l, 1); // reg map 1
            lua_pushvalue(l, -2); // reg map 1 map
            lua_settable(l, -4); // reg map
        }
        lua_pushnumber(l, 2); // reg map 2
        lua_gettable(l, -3); // reg map revmap
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // reg map
            lua_newtable(l); // reg map revmap
            lua_pushnumber(l, 2); // reg map revmap 2
            lua_pushvalue(l, -2); // reg map revmap 2 revmap
            lua_settable(l, -5); // reg map revmap
        }
        
        lua_pushnumber(l, id); // reg map revmap id
        lua_pushstring(l, str); // reg map revmap id str
        lua_pushvalue(l, -1); // reg map revmap id str str
        lua_pushvalue(l, -3); // reg map revmap id str str id
        lua_settable(l, -5); // reg map revmap id str
        lua_settable(l, -4); // reg map revmap
        lua_pop(l, 3); // X
    }
    EXPORT_API void capslua_unregString(lua_State* l, int id)
    {
        lua_checkstack(l, 8);
        lua_pushlightuserdata(l, (void*)1001); // rkey
        lua_gettable(l, LUA_REGISTRYINDEX); // reg
        if (lua_istable(l, -1))
        {
            lua_pushnumber(l, 1); // reg 1
            lua_gettable(l, -2); // reg map
            lua_pushnumber(l, 2); // reg map 2
            lua_gettable(l, -3); // reg map revmap
            if (lua_istable(l, -2))
            {
                lua_pushnumber(l, id); // reg map revmap id
                lua_pushvalue(l, -1); // reg map revmap id id
                lua_gettable(l, -4); // reg map revmap id str
                lua_pushvalue(l, -2); // reg map revmap id str id
                lua_pushnil(l); // reg map revmap id str id nil
                lua_settable(l, -6); // reg map revmap id str
                if (lua_type(l, -1) == LUA_TSTRING && lua_istable(l, -3))
                {
                    lua_pushnil(l); // reg map revmap id str nil
                    lua_settable(l, -4); // reg map revmap id
                    lua_pop(l, 1); // reg map revmap
                }
                else
                {
                    lua_pop(l, 2); // reg map revmap
                }
            }
            lua_pop(l, 3); // X
        }
        else
        {
            lua_pop(l, 1); // X
        }
    }
    EXPORT_API int capslua_getStringRegId(lua_State* l, int index)
    {
        if (lua_type(l, index) == LUA_TSTRING)
        {
            lua_checkstack(l, 5);
            lua_pushvalue(l, index); // lstr
            lua_pushlightuserdata(l, (void*)1001); // lstr rkey
            lua_gettable(l, LUA_REGISTRYINDEX); // lstr reg
            if (lua_istable(l, -1))
            {
                lua_pushnumber(l, 2); // lstr reg 2
                lua_gettable(l, -2); // lstr reg revmap
                
                if (lua_istable(l, -1))
                {
                    lua_pushvalue(l, -3); // lstr reg revmap lstr
                    lua_gettable(l, -2); // lstr reg revmap id
                    
                    if (lua_isnumber(l, -1))
                    {
                        int id = (int)lua_tonumber(l, -1);
                        lua_pop(l, 4); // X
                        return id;
                    }
                    else
                    {
                        lua_pop(l, 4); // X
                    }
                }
                else
                {
                    lua_pop(l, 3); // X
                }
            }
            else
            {
                lua_pop(l, 2); // X
            }
        }
        return 0;
    }
    
    static void* typeVector3 = 0;
    EXPORT_API void capslua_setTypeVector3(void* type)
    {
        typeVector3 = type;
    }
    EXPORT_API void capslua_pushVector3(lua_State *l, float x, float y, float z)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, x);
        lua_setfield(l, -2, "x");
        lua_pushnumber(l, y);
        lua_setfield(l, -2, "y");
        lua_pushnumber(l, z);
        lua_setfield(l, -2, "z"); // otab
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeVector3); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeVector3); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setVector3(lua_State *l, int index, float x, float y, float z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, x);
        lua_setfield(l, index, "x");
        lua_pushnumber(l, y);
        lua_setfield(l, index, "y");
        lua_pushnumber(l, z);
        lua_setfield(l, index, "z");
    }
    EXPORT_API void capslua_getVector3(lua_State *l, int index, float* x, float* y, float* z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "x");
        *x = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "y");
        *y = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "z");
        *z = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    
    
    static void* typeLayerMask = 0;
    EXPORT_API void capslua_setTypeLayerMask(void* type)
    {
        typeLayerMask = type;
    }
    EXPORT_API void capslua_pushLayerMask(lua_State *l, int value)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)value);
        lua_setfield(l, -2, "value");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeLayerMask); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeLayerMask); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setLayerMask(lua_State *l, int index, int value)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)value);
        lua_setfield(l, index, "value");
    }
    EXPORT_API void capslua_getLayerMask(lua_State *l, int index, int* value)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "value");
        *value = (int)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    
    
    
    static void* typeQuaternion = 0;
    EXPORT_API void capslua_setTypeQuaternion(void* type)
    {
        typeQuaternion = type;
    }
    EXPORT_API void capslua_pushQuaternion(lua_State *l, float x, float y, float z, float w)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)x);
        lua_setfield(l, -2, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, -2, "y");
        lua_pushnumber(l, (double)z);
        lua_setfield(l, -2, "z");
        lua_pushnumber(l, (double)w);
        lua_setfield(l, -2, "w");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeQuaternion); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeQuaternion); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setQuaternion(lua_State *l, int index, float x, float y, float z, float w)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)x);
        lua_setfield(l, index, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, index, "y");
        lua_pushnumber(l, (double)z);
        lua_setfield(l, index, "z");
        lua_pushnumber(l, (double)w);
        lua_setfield(l, index, "w");
    }
    EXPORT_API void capslua_getQuaternion(lua_State *l, int index, float* x, float* y, float* z, float* w)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "x");
        *x = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "y");
        *y = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "z");
        *z = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "w");
        *w = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    static void* typeColor = 0;
    EXPORT_API void capslua_setTypeColor(void* type)
    {
        typeColor = type;
    }
    EXPORT_API void capslua_pushColor(lua_State *l, float r, float g, float b, float a)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)r);
        lua_setfield(l, -2, "r");
        lua_pushnumber(l, (double)g);
        lua_setfield(l, -2, "g");
        lua_pushnumber(l, (double)b);
        lua_setfield(l, -2, "b");
        lua_pushnumber(l, (double)a);
        lua_setfield(l, -2, "a");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeColor); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeColor); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setColor(lua_State *l, int index, float r, float g, float b, float a)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)r);
        lua_setfield(l, index, "r");
        lua_pushnumber(l, (double)g);
        lua_setfield(l, index, "g");
        lua_pushnumber(l, (double)b);
        lua_setfield(l, index, "b");
        lua_pushnumber(l, (double)a);
        lua_setfield(l, index, "a");
    }
    EXPORT_API void capslua_getColor(lua_State *l, int index, float* r, float* g, float* b, float* a)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "r");
        *r = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "g");
        *g = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "b");
        *b = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "a");
        *a = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    
    static void* typeRect = 0;
    EXPORT_API void capslua_setTypeRect(void* type)
    {
        typeRect = type;
    }
    EXPORT_API void capslua_pushRect(lua_State *l, float xMin, float yMin, float width, float height)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)xMin);
        lua_setfield(l, -2, "xMin");
        lua_pushnumber(l, (double)yMin);
        lua_setfield(l, -2, "yMin");
        lua_pushnumber(l, (double)width);
        lua_setfield(l, -2, "width");
        lua_pushnumber(l, (double)height);
        lua_setfield(l, -2, "height");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeRect); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeRect); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setRect(lua_State *l, int index, float xMin, float yMin, float width, float height)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)xMin);
        lua_setfield(l, index, "xMin");
        lua_pushnumber(l, (double)yMin);
        lua_setfield(l, index, "yMin");
        lua_pushnumber(l, (double)width);
        lua_setfield(l, index, "width");
        lua_pushnumber(l, (double)height);
        lua_setfield(l, index, "height");
    }
    EXPORT_API void capslua_getRect(lua_State *l, int index, float* xMin, float* yMin, float* width, float* height)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "xMin");
        *xMin = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "yMin");
        *yMin = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "width");
        *width = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "height");
        *height = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    static void* typeVector2 = 0;
    EXPORT_API void capslua_setTypeVector2(void* type)
    {
        typeVector2 = type;
    }
    EXPORT_API void capslua_pushVector2(lua_State *l, float x, float y)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)x);
        lua_setfield(l, -2, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, -2, "y");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeVector2); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeVector2); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setVector2(lua_State *l, int index, float x, float y)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)x);
        lua_setfield(l, index, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, index, "y");
    }
    EXPORT_API void capslua_getVector2(lua_State *l, int index, float* x, float* y)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "x");
        *x = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "y");
        *y = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    static void* typeVector4 = 0;
    EXPORT_API void capslua_setTypeVector4(void* type)
    {
        typeVector4 = type;
    }
    EXPORT_API void capslua_pushVector4(lua_State *l, float x, float y, float z, float w)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        lua_pushnumber(l, (double)x);
        lua_setfield(l, -2, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, -2, "y");
        lua_pushnumber(l, (double)z);
        lua_setfield(l, -2, "z");
        lua_pushnumber(l, (double)w);
        lua_setfield(l, -2, "w");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeVector4); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeVector4); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setVector4(lua_State *l, int index, float x, float y, float z, float w)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_pushnumber(l, (double)x);
        lua_setfield(l, index, "x");
        lua_pushnumber(l, (double)y);
        lua_setfield(l, index, "y");
        lua_pushnumber(l, (double)z);
        lua_setfield(l, index, "z");
        lua_pushnumber(l, (double)w);
        lua_setfield(l, index, "w");
    }
    EXPORT_API void capslua_getVector4(lua_State *l, int index, float* x, float* y, float* z, float* w)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "x");
        *x = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "y");
        *y = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "z");
        *z = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
        lua_getfield(l, index, "w");
        *w = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    
    
    
    static void* typeBounds = 0;
    EXPORT_API void capslua_setTypeBounds(void* type)
    {
        typeBounds = type;
    }
    EXPORT_API void capslua_pushBounds(lua_State *l, float center_x, float center_y, float center_z, float extents_x, float extents_y, float extents_z)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        capslua_pushVector3(l, center_x, center_y, center_z);
        lua_setfield(l, -2, "center");
        capslua_pushVector3(l, extents_x, extents_y, extents_z);
        lua_setfield(l, -2, "extents");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeBounds); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeBounds); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setBounds(lua_State *l, int index, float center_x, float center_y, float center_z, float extents_x, float extents_y, float extents_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "center");
        capslua_setVector3(l, -1, center_x, center_y, center_z);
        lua_pop(l, 1);
        lua_getfield(l, index, "extents");
        capslua_setVector3(l, -1, extents_x, extents_y, extents_z);
        lua_pop(l, 1);
    }
    EXPORT_API void capslua_getBounds(lua_State *l, int index, float* center_x, float* center_y, float* center_z, float* extents_x, float* extents_y, float* extents_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "center");
        capslua_getVector3(l, -1, center_x, center_y, center_z);
        lua_pop(l, 1);
        lua_getfield(l, index, "extents");
        capslua_getVector3(l, -1, extents_x, extents_y, extents_z);
        lua_pop(l, 1);
    }
    
    static void* typePlane = 0;
    EXPORT_API void capslua_setTypePlane(void* type)
    {
        typePlane = type;
    }
    EXPORT_API void capslua_pushPlane(lua_State *l, float distance, float normal_x, float normal_y, float normal_z)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        capslua_pushVector3(l, normal_x, normal_y, normal_z);
        lua_setfield(l, -2, "normal");
        lua_pushnumber(l, (double)distance);
        lua_setfield(l, -2, "distance");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typePlane); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typePlane); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setPlane(lua_State *l, int index, float distance, float normal_x, float normal_y, float normal_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "normal");
        capslua_setVector3(l, -1, normal_x, normal_y, normal_z);
        lua_pop(l, 1);
        lua_pushnumber(l, (double)distance);
        lua_setfield(l, index, "distance");
    }
    EXPORT_API void capslua_getPlane(lua_State *l, int index, float* distance, float* normal_x, float* normal_y, float* normal_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "normal");
        capslua_getVector3(l, -1, normal_x, normal_y, normal_z);
        lua_pop(l, 1);
        lua_getfield(l, index, "distance");
        *distance = (float)lua_tonumber(l, -1);
        lua_pop(l, 1);
    }
    
    static void* typeRay = 0;
    EXPORT_API void capslua_setTypeRay(void* type)
    {
        typeRay = type;
    }
    EXPORT_API void capslua_pushRay(lua_State *l, float origin_x, float origin_y, float origin_z, float direction_x, float direction_y, float direction_z)
    {
        lua_checkstack(l, 3);
        
        lua_newtable(l); // otab
        capslua_pushVector3(l, origin_x, origin_y, origin_z);
        lua_setfield(l, -2, "origin");
        capslua_pushVector3(l, direction_x, direction_y, direction_z);
        lua_setfield(l, -2, "direction");
        
        lua_pushlightuserdata(l, (void*)1003); // otab #cache
        lua_gettable(l, LUA_REGISTRYINDEX); // otab cache
        if (lua_istable(l, -1))
        {
            lua_pushlightuserdata(l, typeRay); // otab cache #type
            lua_gettable(l, -2); // otab cache type
            lua_remove(l, -2); // otab type
        }
        
        if (!lua_istable(l, -1))
        {
            lua_pop(l, 1); // otab
            capsluacs_pushType(l, typeRay); // otab type
        }
        
        lua_pushlightuserdata(l, (void*)2101); // otab type #meta
        lua_rawget(l, -2); // otab type meta
        lua_setmetatable(l, -3); // otab type
        lua_pop(l, 1); // otab
    }
    EXPORT_API void capslua_setRay(lua_State *l, int index, float origin_x, float origin_y, float origin_z, float direction_x, float direction_y, float direction_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "origin");
        capslua_setVector3(l, -1, origin_x, origin_y, origin_z);
        lua_pop(l, 1);
        lua_getfield(l, index, "direction");
        capslua_setVector3(l, -1, direction_x, direction_y, direction_z);
        lua_pop(l, 1);
    }
    EXPORT_API void capslua_getRay(lua_State *l, int index, float* origin_x, float* origin_y, float* origin_z, float* direction_x, float* direction_y, float* direction_z)
    {
        lua_checkstack(l, 1);
        
        index = abs_index(l, index);
        
        lua_getfield(l, index, "origin");
        capslua_getVector3(l, -1, origin_x, origin_y, origin_z);
        lua_pop(l, 1);
        lua_getfield(l, index, "direction");
        capslua_getVector3(l, -1, direction_x, direction_y, direction_z);
        lua_pop(l, 1);
    }
}
