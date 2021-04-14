//
//  CapsLua.hpp
//  CapsLua
//
//  Created by Silas on 2021/4/12.
//

#ifndef CapsLua_
#define CapsLua_

/* The classes below are exported */
#pragma GCC visibility push(default)

//class CapsLua
//{
//    public:
//    void HelloWorld(const char *);
//};

extern "C"
{
int luapoen_CapsLua(void* l);
}

#pragma GCC visibility pop
#endif
