make clean
make BUILDMODE=dynamic
install_name_tool -change /usr/local/lib/libluajit-5.1.2.dylib @executable_path/libluajit.so ./src/luajit
