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

        ~LoginToken()
        {
            DeletePointerLoginToken();
        }

        #region Properties
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
        #endregion Properties

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

    public class LoginTokenWrap
    {
        private readonly IntPtr _loginTokenPointer;
        private readonly IntPtr _loginTokenPointer2;

        public LoginTokenWrap(long userOid, long tokenOid, long issuedDateSeconds)
        {
            _loginTokenPointer = DLLImportsLoginTokenWrap.CreateLoginToken(userOid, tokenOid, issuedDateSeconds);
            UserOid = DLLImportsLoginTokenWrap.GetUserOid(_loginTokenPointer);
            TokenOid = DLLImportsLoginTokenWrap.GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = DLLImportsLoginTokenWrap.GetIssuedAtSeconds(_loginTokenPointer);

            IntPtr intPtr = DLLImportsLoginTokenWrap.GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr);

            _loginTokenPointer2 = DLLImportsLoginTokenWrap.CreateLoginTokenFromString(Token);
            UserOid = DLLImportsLoginTokenWrap.GetUserOid(_loginTokenPointer2);
            TokenOid = DLLImportsLoginTokenWrap.GetTokenOid(_loginTokenPointer2);
            IssuedDateSeconds = DLLImportsLoginTokenWrap.GetIssuedAtSeconds(_loginTokenPointer2);

            IntPtr intPtr2 = DLLImportsLoginTokenWrap.GetToken(_loginTokenPointer2);
            Token = Marshal.PtrToStringAnsi(intPtr2);
        }

        ~LoginTokenWrap()
        {
            DeletePointerLoginToken();
        }

        #region Properties
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
        #endregion Properties

        private bool _pointerDeleted = false;
        private void DeletePointerLoginToken()
        {
            if (_pointerDeleted == false)
            {
                DLLImportsLoginTokenWrap.DeleteLoginToken(_loginTokenPointer);
                _pointerDeleted = true;
            }
        }

    }
}
