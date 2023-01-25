using System.Globalization;

namespace AutonomoApp.WebApi.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrWhiteSpace(this string value)
        {
            if (value == null) return true;
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i])) return false;
            }
            return true;
        }

        static string RemoveEmptySpacesAndJoin(string[] array)
        {
            List<string> filteredArray = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!IsNullOrWhiteSpace(array[i]))
                {
                    filteredArray.Add(array[i]);
                }
            }
            return string.Join(",", filteredArray.ToArray());
        }

        public static bool IsNullOrEmpty(this string value)
        {
            if (value != null) 
                return value.Length == 0;
            return true;
        }

        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) ||
                   ReferenceEquals(value, null) ||
                   string.IsNullOrEmpty(value.Trim(' '));
        }


    }
}
