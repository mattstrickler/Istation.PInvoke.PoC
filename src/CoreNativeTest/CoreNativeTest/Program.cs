using NativeLibraryManager;
using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CoreNativeTest
{
    public class Program
    {

        private static void Main(string[] args)
        {
            var accessor = new ResourceAccessor(Assembly.GetExecutingAssembly());
            var libManager = new LibraryManager(
                new LibraryItem(Platform.Windows, Bitness.x64,
                    new LibraryFile("LoginTokenNativeLibrary.dll", accessor.Binary("LoginTokenNativeLibrary.dll"))),
                new LibraryItem(Platform.Linux, Bitness.x64,
                    new LibraryFile("libLoginTokenNativeLibrary.so", accessor.Binary("libLoginTokenNativeLibrary.so")))
            );

            libManager.LoadNativeLibrary();

            var platform = "NOT DEFINED";

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                platform = "Windows";
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                platform = "Linux";
            }

            var OSArchitecture = RuntimeInformation.OSArchitecture;
            var OSDescription = RuntimeInformation.OSDescription;
            var FrameworkDescription = RuntimeInformation.FrameworkDescription;

            Console.WriteLine();
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine("-------------------------- P-Invoke Demo ----------------------------");
            Console.WriteLine("---------------------------------------------------------------------");
            Console.WriteLine();

            string msg = $"Platform: {platform}{Environment.NewLine}{nameof(OSArchitecture)}: {OSArchitecture}{Environment.NewLine}{nameof(OSDescription)}: {OSDescription}{Environment.NewLine}{nameof(FrameworkDescription)}: {FrameworkDescription}";
            Console.WriteLine(msg);
            Console.WriteLine();

            var LoginToken = new LoginToken("TestToken1");
            Console.WriteLine();
            Console.WriteLine("Successfully created LoginToken passing token string to C++ and importing properties.");

            var LoginToken2 = new LoginToken(10000, 12515, new DateTimeOffset(DateTime.Now).ToUnixTimeSeconds());
            Console.WriteLine();
            Console.WriteLine("Successfully created LoginToken passing UserOid, TokenOid, and IssuedAtSeconds to C++ and importing properties.");

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Press Any Key to Exit...");
            Console.ReadLine();
        }
    }
}