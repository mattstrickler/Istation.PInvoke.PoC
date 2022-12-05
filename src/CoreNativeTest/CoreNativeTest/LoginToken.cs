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

        public LoginTokenWrap(long userOid, long tokenOid, DateTime issuedDate)
        {
            _IssuedDate = issuedDate;
            _loginTokenPointer = DLLImportsLoginTokenWrap.CreateLoginToken(userOid, tokenOid, new DateTimeOffset(_IssuedDate).ToUnixTimeSeconds());
            UserOid = DLLImportsLoginTokenWrap.GetUserOid(_loginTokenPointer);
            TokenOid = DLLImportsLoginTokenWrap.GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = DLLImportsLoginTokenWrap.GetIssuedAtSeconds(_loginTokenPointer);
            DateTime dateTimeUTC = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            DateTime dateTimeLocal = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTimeUTC = dateTimeUTC.AddSeconds(IssuedDateSeconds);
            dateTimeLocal = dateTimeLocal.AddSeconds(IssuedDateSeconds).ToLocalTime();

            IntPtr intPtr = DLLImportsLoginTokenWrap.GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr);

            //DLLImportsLoginTokenWrap.DeleteLoginToken(_loginTokenPointer);
        }

        public LoginTokenWrap(string Token)
        {
            _loginTokenPointer = DLLImportsLoginTokenWrap.CreateLoginTokenFromString(Token);
            UserOid = DLLImportsLoginTokenWrap.GetUserOid(_loginTokenPointer);
            TokenOid = DLLImportsLoginTokenWrap.GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = DLLImportsLoginTokenWrap.GetIssuedAtSeconds(_loginTokenPointer);

            IntPtr intPtr2 = DLLImportsLoginTokenWrap.GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr2);

            //DLLImportsLoginTokenWrap.DeleteLoginToken(_loginTokenPointer);
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

        private DateTime _IssuedDate;
        public DateTime IssuedDate
        {
            get
            {
                return _IssuedDate;
            }
            set
            {
                _IssuedDate = value;
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
