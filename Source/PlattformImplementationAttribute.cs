using System;

namespace CrossPlattformUtils
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PlattformImplementationAttribute : Attribute
    {
        public PlattformImplementationAttribute(Platform platform)
        {
            Platform = platform;
        }

        public Platform Platform { get; set; }
    }
}
