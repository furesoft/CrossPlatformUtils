using CrossPlattformUtils;
using System.Collections.Generic;
using System.Linq;

namespace TestProject
{
    [Injectible]
    public static class TestSingleton
    {
        [Injectible(typeof(IEnumerable<int>))]
        public static IEnumerable<int> MyValue => Enumerable.Range(42, 1);
    }
}