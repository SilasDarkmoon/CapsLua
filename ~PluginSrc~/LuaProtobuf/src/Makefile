CC       = gcc 
CFLAGS   = -Wall -g -O -fPIC -isystem .
CXXFLAGS = 
TARGET   = libLuaProtobuf.so

OBJS     = pb.o LuaProtobuf.o LuaImport.o
SRCS     = pb.c LuaProtobuf.cpp LuaImport.cpp

default all: $(OBJS)
	$(CC) -shared -fPIC -o $(TARGET) $(OBJS)
	strip -x $(TARGET)

$(OBJS): $(SRCS)
	$(CC) $(CFLAGS) -c $^

clean:
	rm -f *.o
	rm -f *.so
