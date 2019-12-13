CC       = gcc 
CFLAGS   = -Wall -g -O -fPIC 
CXXFLAGS = 
TARGET   = libCapsLuaNative.so

OBJS     = CapsLuaNative.o LuaImport.o
SRCS     = CapsLuaNative.cpp LuaImport.cpp

default all: $(OBJS)
	$(CC) -shared -fPIC -Wl,-soname,$(TARGET).1 -o $(TARGET) $(OBJS)
	strip -x $(TARGET)

$(OBJS): $(SRCS)
	$(CC) $(CFLAGS) -c $^

clean:
	rm -f *.o
	rm -f *.so
