CC       = gcc 
CFLAGS   = -Wall -g -O -fPIC 
CXXFLAGS = 
TARGET   = libCapsLuaNative.so

OBJS     = CapsLuaNative.o LuaImport.o
SRCS     = CapsLuaNative.cpp LuaImport.cpp

$(OBJS): $(SRCS)
	$(CC) $(CFLAGS) -c $^
	
all: $(OBJS)
	$(CC) -shared -fPIC -o $(TARGET) $(OBJS)

clean:
	rm -f *.o
	rm -f *.so
