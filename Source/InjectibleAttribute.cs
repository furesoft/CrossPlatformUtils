using System;

namespace CrossPlattformUtils
{
    public class InjectibleAttribute : Attribute
    {
        public InjectibleAttribute(Type @interface)
        {
            Interface = @interface;
        }

        public InjectibleAttribute()
        {

        }
        public Type Interface { get; set; }
    }
}