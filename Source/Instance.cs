using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CrossPlattformUtils
{
    public static class Instance
    {
        public static T New<T>()
        {
            var currentPlatform = GetCurrentPlatform();
            var implementation = GetImplementationOf<T>(currentPlatform);

            return Injector.Get<T>(implementation);
        }

        private static Platform GetCurrentPlatform()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                return Platform.Windows;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                return Platform.Linux;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                return Platform.OSX;
            }

            return Platform.Windows;
        }

        private static Type GetImplementationOf<T>(Platform currentPlatform)
        {
            var ass = Assembly.GetEntryAssembly();
            var types = ass.GetTypes();

            foreach (var t in types)
            {
                if (t.IsInterface || t.IsAbstract) continue;
                else
                {
                    if (typeof(T).IsAssignableFrom(t) || t.IsInstanceOfType(typeof(T)))
                    {
                        var attr = t.GetCustomAttribute<PlattformImplementationAttribute>();
                        if (attr != null)
                        {
                            if (attr.Platform == currentPlatform)
                            {
                                return t;
                            }
                        }
                    }
                }
            }

            throw new PlatformNotSupportedException();
        }
    }
}