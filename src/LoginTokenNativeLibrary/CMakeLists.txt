cmake_minimum_required(VERSION 3.14)
project(LoginTokenNativeLibrary)

set(CMAKE_CXX_STANDARD 17)

add_compile_definitions(DLL_EXPORTS)

add_library(LoginTokenNativeLibrary SHARED LoginToken.cpp LoginToken.h)