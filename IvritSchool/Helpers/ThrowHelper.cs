using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IvritSchool.Helpers
{
    public static class ThrowHelper
    {
        public static void ThrowIfNull(object @object, string paramName)
        {
            if(@object == null)
            {
                Throw(paramName);
            }
        }

        private static void Throw(string? paramName) => throw new ArgumentNullException(paramName);
    }
}
