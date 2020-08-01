using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace CrossPlattformUtils
{
    public static class Allocator
    {
        public static T New<T>(params object[] args)
        {
            var currentPlatform = GetCurrentPlatform();
            var implementation = GetImplementationOf<T>(currentPlatform);

            return Injector.Get<T>(implementation);
        }

        private static Type GetImplementationOf<T>(Platform currentPlatform)
        {
            var types = Assembly.GetEntryAssembly().GetTypes().Concat(Assembly.GetExecutingAssembly().GetTypes()).Concat(Assembly.GetCallingAssembly().GetTypes());

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
    }
}