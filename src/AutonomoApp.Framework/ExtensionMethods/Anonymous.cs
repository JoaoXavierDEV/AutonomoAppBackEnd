using System.Reflection;
using System.Runtime.CompilerServices;

namespace AutonomoApp.Framework.ExtensionMethods
{
    public static class Anonymous
    {
        public static bool IsAnonymous<T>(this T _)
        {
            return IsAnonymous<T>();
        }

        public static T Null<T>(T _)
        {
            ValidateStructure<T>();
            return default;
        }

        public static List<T> EmptyListOf<T>(T _)
        {
            ValidateStructure<T>();
            return new List<T>();
        }

        public static T[] EmptyArrayOf<T>(T _)
        {
            ValidateStructure<T>();
            return Array.Empty<T>();
        }

        public static IEnumerable<T> EmptyEnumerableOf<T>(T _)
        {
            ValidateStructure<T>();
            return Enumerable.Empty<T>();
        }

        private static bool IsAnonymous<T>()
        {
            Type typeFromHandle = typeof(T);
            bool flag = Attribute.IsDefined(typeFromHandle, typeof(CompilerGeneratedAttribute), inherit: false);
            bool flag2 = typeFromHandle.FullName.Contains("AnonymousType");
            bool flag3 = typeFromHandle.FullName.StartsWith("<>");
            bool flag4 = typeFromHandle.Attributes.HasFlag(TypeAttributes.NotPublic);
            return flag && flag2 && flag3 && flag4;
        }

        private static void ValidateStructure<T>()
        {
            if (!IsAnonymous<T>())
            {
                throw new InvalidOperationException("O uso dos métodos para manipulação de objetos anônimos somente podem ser usados para anônimos.");
            }
        }
    }
}
