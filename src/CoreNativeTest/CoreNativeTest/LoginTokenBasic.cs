using System;
using System.Runtime.InteropServices;

namespace CoreNativeTest
{
    public class LoginTokenBasic
    {
        /// <summary>
        /// Name of Unmanaged Library (C++) being imported
        /// </summary>
        const string DLL_LIBRARY_BASIC = "LoginTokenNativeLibrary";
        private readonly IntPtr _loginTokenPointer;

        #region Extern Code
        // Import unmanaged code, .dll, .so
        [DllImport(DLL_LIBRARY_BASIC, 
                   CharSet = CharSet.Ansi, 
                   CallingConvention = CallingConvention.StdCall, 
                   SetLastError = true)]
        // The C# method which corresponds to the native unmanaged C++ code
        public static extern IntPtr CreateLoginToken([MarshalAs(UnmanagedType.LPStr)] string token);

        // Import unmanaged code, .dll, .so
        [DllImport(DLL_LIBRARY_BASIC)]
        // The C# method which corresponds to the native unmanaged C++ code
        public static extern long GetUserOid(IntPtr token);

        #region Collapsed for Demo
        [DllImport(DLL_LIBRARY_BASIC)]
        public static extern void DeleteLoginToken(IntPtr token);

        [DllImport(DLL_LIBRARY_BASIC)]
        public static extern long GetTokenOid(IntPtr token);

        [DllImport(DLL_LIBRARY_BASIC)]
        public static extern long GetIssuedDateSeconds(IntPtr token);

        [DllImport(DLL_LIBRARY_BASIC, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetToken(IntPtr token);
        #endregion Collapsed for Demo

        #endregion Extern Code

        public LoginTokenBasic(string token)
        {
            _loginTokenPointer = CreateLoginToken(token);
            UserOid = GetUserOid(_loginTokenPointer);

            #region Collapsed for Demo
            TokenOid = GetTokenOid(_loginTokenPointer);
            IssuedDateSeconds = GetIssuedDateSeconds(_loginTokenPointer);

            IntPtr intPtr = GetToken(_loginTokenPointer);
            Token = Marshal.PtrToStringAnsi(intPtr);
            #endregion Collapsed for Demo
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

        ~LoginTokenBasic()
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
