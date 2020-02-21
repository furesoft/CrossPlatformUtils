using System;

namespace CrossPlattformUtils
{
    public class PlattformImplementationAttribute : Attribute
    {
        public PlattformImplementationAttribute(Platform platform)
        {
            Platform = platform;
        }

        public Platform Platform { get; set; }
    }
}
