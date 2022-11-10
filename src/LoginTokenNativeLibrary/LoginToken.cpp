#include "LoginToken.h"

#include <iostream>
#include <string>

#if defined(_WIN32)
#define OS "Windows"
#elif defined(__linux__)
#define OS "Linux"
#elif defined(__APPLE__)
#define OS "MacOS"
#else
#define OS "Unknown OS"
#endif


LoginToken::LoginToken(const char *token)
{
    // this is where parseToken would be called to parse and populate the Login Token respective properties.

    _token = token;
    _userOid = 123;
    _tokenOid = 456;
    _issuedDateSeconds = 789;
}

LoginToken::LoginToken(long userOid, long tokenOid, long issuedDateSeconds)
{
    // this is where issueLoginToken AND parseToken would called to populate the LoginToken class and properties.

    _token = "Token2";
    _userOid = userOid;
    _tokenOid = tokenOid;
    _issuedDateSeconds = issuedDateSeconds;
}

long LoginToken::getUserOid()
{
    return _userOid;
}

long LoginToken::getTokenOid()
{
    return _tokenOid;
}

long LoginToken::getIssuedDateSeconds()
{
    return _issuedDateSeconds;
}

const char* LoginToken::getToken()
{
    return _token.c_str();
}




LoginToken* CreateLoginToken(const char *token)
{
    return new LoginToken(token);
}

LoginToken* CreateLoginToken2(long userOid, long tokenOid, long issuedDateSeconds)
{
    return new LoginToken(userOid, tokenOid, issuedDateSeconds);
}

void DeleteLoginToken(LoginToken* token)
{
    if (token != NULL)
    {
        delete token;
    }
}

long GetUserOid(LoginToken* token)
{
    return token->getUserOid();
}

long GetTokenOid(LoginToken* token)
{
    return token->getTokenOid();
}

long GetIssuedDateSeconds(LoginToken* token)
{
    return token->getIssuedDateSeconds();
}

const char* GetToken(LoginToken* token)
{
    return token->getToken();
}
