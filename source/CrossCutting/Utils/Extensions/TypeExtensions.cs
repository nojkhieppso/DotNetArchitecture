using System;
using System.Collections;

namespace Solution.CrossCutting.Utils
{
    public static class TypeExtensions
    {
        public static IDictionary ToDictionary(this Type type)
        {
            return type?.GetProperties().ToDictionary();
        }
    }
}
