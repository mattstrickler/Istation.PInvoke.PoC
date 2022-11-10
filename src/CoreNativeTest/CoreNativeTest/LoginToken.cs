using System;
using System.Runtime.InteropServices;

namespace CoreNativeTest
{
    public class LoginToken
    {
        private readonly IntPtr _loginTokenPointer;

        public LoginToken(string token)
        {
            _loginTokenPointer = DLLImports.CreateLoginToken(token);
            UserOid = DLLImports.GetUserOid(_loginTokenPointer);
            TokenOid = DLLImports.GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = DLLImports.GetIssuedDateSeconds(_loginTokenPointer);

            IntPtr intPtr = DLLImports.GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr);
        }

        public LoginToken(long userOid, long tokenOid, long issuedDateSeconds)
        {
            _loginTokenPointer = DLLImports.CreateLoginToken2(userOid, tokenOid, issuedDateSeconds);
            UserOid = DLLImports.GetUserOid(_loginTokenPointer);
            TokenOid = DLLImports.GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = DLLImports.GetIssuedDateSeconds(_loginTokenPointer);

            IntPtr intPtr = DLLImports.GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr);
        }

        private long _UserOid;
        public long UserOid
        {
            get
            {
                return _UserOid;
            }
            set
            {
                _UserOid = value;
            }
        }

        private long _TokenOid;
        public long TokenOid
        {
            get
            {
                return _TokenOid;
            }
            set
            {
                _TokenOid = value;
            }
        }

        private long _IssuedDateSeconds;
        public long IssuedDateSeconds
        {
            get
            {
                return _IssuedDateSeconds;
            }
            set
            {
                _IssuedDateSeconds = value;
            }
        }

        private string _Token;
        public string Token
        {
            get
            {
                return _Token;
            }
            set
            {
                _Token = value;
            }
        }

        ~LoginToken()
        {
            DeletePointerLoginToken();
        }

        private bool _pointerDeleted = false;
        private void DeletePointerLoginToken()
        {
            if (_pointerDeleted == false)
            {
                DLLImports.DeleteLoginToken(_loginTokenPointer);
                _pointerDeleted = true;
            }
        }
    }
}
