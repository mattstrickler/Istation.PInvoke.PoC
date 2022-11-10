#include <string>

#ifndef LOGINTOKENNATIVELIBRARY_LIBRARY_H
#define LOGINTOKENNATIVELIBRARY_LIBRARY_H

#if defined DLL_EXPORTS
    #if defined WIN32
        #define LIB_API(RetType) extern "C" __declspec(dllexport) RetType
    #else
        #define LIB_API(RetType) extern "C" RetType __attribute__((visibility("default")))
    #endif
#else
    #if defined WIN32
        #define LIB_API(RetType) extern "C" __declspec(dllimport) RetType
    #else
        #define LIB_API(RetType) extern "C" RetType
    #endif
#endif

#pragma pack(push, 1)
class LoginToken
{
    public:
        LoginToken(void) {};
        LoginToken(const char *token);
        LoginToken(long userOid, long tokenOid, long issuedDateSeconds);

        long getUserOid();
        long getTokenOid();
        long getIssuedDateSeconds();
        const char* getToken();

    private:
        std::string _token = "Token_Original";
        long _userOid;
        long _tokenOid;
        long _issuedDateSeconds;
};
#pragma pack(pop)

LIB_API(LoginToken*) CreateLoginToken(const char *token);
LIB_API(LoginToken*) CreateLoginToken2(long userOid, long tokenOid, long issuedDateSeconds);
LIB_API(void) DeleteLoginToken(LoginToken* token);
LIB_API(long) GetUserOid(LoginToken* token);
LIB_API(long) GetTokenOid(LoginToken* token);
LIB_API(long) GetIssuedDateSeconds(LoginToken* token);
LIB_API(const char*) GetToken(LoginToken* token);

#endif //LOGINTOKENNATIVELIBRARY_LIBRARY_H