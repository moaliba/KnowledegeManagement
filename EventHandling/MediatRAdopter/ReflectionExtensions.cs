using System;
using System.Collections.Generic;
using System.Linq;

namespace EventHandling.MediatRAdopter
{
    public static class ReflectionExtensions
    {
        public static bool Implements(this Type @interface, Type expectedInterface)
                => @interface.IsGenericType
                && @interface.GetGenericTypeDefinition() == expectedInterface;

        public static IEnumerable<Type> GetInterfacesOfType(this Type @class, Type expectedInterface)
        => @class.GetInterfaces().Where(@interface => @interface.Implements(expectedInterface));
    }
}
