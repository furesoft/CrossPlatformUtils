using System;

namespace CrossPlattformUtils
{
    [AttributeUsage(AttributeTargets.Class)]
    public sealed class PlattformImplementationAttribute : Attribute
    {
        public Platform Platform { get; set; }

        public PlattformImplementationAttribute(Platform platform)
        {
            Platform = platform;
        }
    }
}