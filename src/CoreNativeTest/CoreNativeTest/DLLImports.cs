using System;
using System.Runtime.InteropServices;

namespace CoreNativeTest
{
    public static class DLLImports
    {
        const string DLL_LIBRARY = "LoginTokenNativeLibrary";

        [DllImport(DLL_LIBRARY, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateLoginToken([MarshalAs(UnmanagedType.LPStr)] string token);

        [DllImport(DLL_LIBRARY)]
        public static extern IntPtr CreateLoginToken2(long userOid, long tokenOid, long issuedDateSeconds);

        [DllImport(DLL_LIBRARY)]
        public static extern void DeleteLoginToken(IntPtr token);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetUserOid(IntPtr token);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetTokenOid(IntPtr token);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetIssuedDateSeconds(IntPtr token);

        [DllImport(DLL_LIBRARY, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetToken(IntPtr token);
    }

    public static class DLLImportsLoginTokenWrap
    {
        const string DLL_LIBRARY = "ISTokenWrapper";

        [DllImport(DLL_LIBRARY)]
        public static extern IntPtr CreateLoginToken(long userOid, long tokenOid, long issueDateSeconds);

        [DllImport(DLL_LIBRARY, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr CreateLoginTokenFromString([MarshalAs(UnmanagedType.LPStr)] string token);


        [DllImport(DLL_LIBRARY)]
        public static extern void DeleteLoginToken(IntPtr logintoken_ptr);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetUserOid(IntPtr logintoken_ptr);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetTokenOid(IntPtr logintoken_ptr);

        [DllImport(DLL_LIBRARY)]
        public static extern long GetIssuedAtSeconds(IntPtr logintoken_ptr);


        [DllImport(DLL_LIBRARY, CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall)]
        public static extern IntPtr GetToken(IntPtr logintoken_ptr);
    }
}
