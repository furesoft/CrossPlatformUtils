using System;
using System.Collections.Generic;
using System.Linq;

namespace CrossPlattformUtils
{
    public static class Injector
    {
        public static void Add<T>(object value)
        {
            _objectMappings.Add(typeof(T), value);
        }

        public static void Add<T, V>() where V : T
        {
            _mappings.Add(typeof(T), typeof(V));
        }

        public static void Clear()
        {
            _mappings.Clear();
        }

        public static T Get<T>()
        {
            var type = typeof(T);

            return (T)Get(type);
        }

        public static T Get<T>(Type type)
        {
            return (T)Get(type);
        }

        private static Dictionary<Type, Type> _mappings
                                                    = new Dictionary<Type, Type>();

        private static Dictionary<Type, object> _objectMappings =
            new Dictionary<Type, object>();

        private static object Get(Type type)
        {
            var target = ResolveType(type);
            var constructors = target.GetConstructors();

            if (constructors.Any())
            {
                var constructor = constructors.First();
                var parameters = constructor.GetParameters();

                List<object> resolvedParameters = new List<object>();

                foreach (var item in parameters)
                {
                    resolvedParameters.Add(Get(item.ParameterType));
                }

                return constructor.Invoke(resolvedParameters.ToArray());
            }

            return _objectMappings[type];
        }

        private static Type ResolveType(Type type)
        {
            if (_mappings.Keys.Contains(type))
            {
                return _mappings[type];
            }

            return type;
        }
    }
}