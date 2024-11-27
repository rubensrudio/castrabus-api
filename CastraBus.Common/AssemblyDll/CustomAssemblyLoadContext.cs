using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Loader;

namespace CastraBus.Common.AssemblyDll
{
    public class CustomAssemblyLoadContext : AssemblyLoadContext
    {
        public IntPtr LoadUnmanagedLibrary(string absolutePath)
        {
            return LoadUnmanagedDll(absolutePath);
        }

        protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        {
            return NativeLibrary.Load(unmanagedDllName);
        }

        protected override Assembly Load(AssemblyName assemblyName)
        {
            return null;
        }
    }
}
