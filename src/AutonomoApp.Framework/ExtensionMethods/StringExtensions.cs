using System.Globalization;
using System.IO.Compression;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace AutonomoApp.Framework.ExtensionMethods
{
    public static class StringExtension
    {
        public static IEnumerable<string> SplitInParts(this string s, int partLength)
        {
            ArgumentNullException.ThrowIfNull(s);

            if (partLength <= 0)
            {
                throw new ArgumentException("O tamanho das partes tem que ser Positivo.", nameof(partLength));
            }

            if (s.Length <= partLength)
            {
                yield return s;
                yield break;
            }

            for (int i = 0; i < s.Length; i += partLength)
            {
                yield return s.Substring(i, Math.Min(partLength, s.Length - i));
            }
        }

        public static string Fmt(this string owner, params object[] args)
        {
            return string.Format(owner, args);
        }

        public static bool IsNullOrEmpty(this string owner)
        {
            return string.IsNullOrEmpty(owner);
        }

        public static bool IsNullOrWhiteSpace(this string owner)
        {
            return string.IsNullOrWhiteSpace(owner);
        }

        public static string OnlyNumbers(this string owner)
        {
            return Regex.Replace(owner, "[^\\d]", "", RegexOptions.Compiled);
        }

        public static string ValidateLenght(this string owner, int lenght, string message)
        {
            if (!owner.Length.Equals(lenght))
            {
                throw new ArgumentException(message, "Lenght");
            }

            return owner;
        }

        public static string ValidateLenght(this string owner, int lenght)
        {
            return owner.ValidateLenght(lenght, "Tamanho da string não respeita o pattern \n String: {0} \n Tamanho: {1}".Fmt(owner, lenght));
        }

        public static string SubstringByKey(this string owner, string key)
        {
            return owner.SubstringByKey(key, ',');
        }

        public static string SubstringByKey(this string owner, string key, char delimiter)
        {
            string[] source = owner.Split(delimiter);
            string text = (from x in source
                           where x.Contains(key + "=")
                           select x).FirstOrDefault();
            if (text == null)
            {
                return string.Empty;
            }

            int length = (key + "=").Length;
            return text.Substring(length, text.Length - length);
        }

        public static string TrySubstring(this string owner, int startIndex)
        {
            return owner.TrySubstring(startIndex, owner.Length - startIndex);
        }

        public static string TrySubstring(this string owner, int startIndex, int length)
        {
            return owner.IsNullOrEmpty() ? owner : owner.Length > length ? owner.Substring(startIndex, length) : owner;
        }

        public static string HtmlEncode(this string owner)
        {
            return SecurityElement.Escape(HttpUtility.HtmlDecode(owner));
        }

        public static string HtmlDecode(this string owner)
        {
            return HttpUtility.HtmlDecode(owner);
        }

        public static string RemoveSpecialCharacters(this string owner, bool trim = false)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(38, "amp");
            string text;
            if (owner != null)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (char c in owner)
                {
                    if (dictionary.ContainsKey(c))
                    {
                        stringBuilder.Append($"&{dictionary[c]};");
                    }
                    else
                    {
                        stringBuilder.Append(c);
                    }
                }

                text = stringBuilder.ToString();
            }
            else
            {
                text = owner;
            }

            if (trim)
            {
                text = string.IsNullOrEmpty(text) ? text : text.Trim();
            }

            return text;
        }

        public static string RemoveNonAlphaNumericChars(this string owner)
        {
            Regex regex = new Regex("[^a-zA-Z0-9 -]");
            return regex.Replace(owner, string.Empty);
        }

        public static string ReplaceAccents(this string owner, bool ignoreImplicitCategoriesToRemove = false, UnicodeCategory[] otherCategoriesToRemove = null)
        {
            UnicodeCategory[] array = new UnicodeCategory[8]
            {
            UnicodeCategory.ModifierSymbol,
            UnicodeCategory.MathSymbol,
            UnicodeCategory.OpenPunctuation,
            UnicodeCategory.ClosePunctuation,
            UnicodeCategory.DashPunctuation,
            UnicodeCategory.ConnectorPunctuation,
            UnicodeCategory.OtherPunctuation,
            UnicodeCategory.CurrencySymbol
            };
            UnicodeCategory[] source = array;
            if (otherCategoriesToRemove != null)
            {
                source = !ignoreImplicitCategoriesToRemove ? source.AsEnumerable().Concat(otherCategoriesToRemove.AsEnumerable()).ToArray() : otherCategoriesToRemove;
            }

            string text = owner.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(text[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    if (source.AsEnumerable().Contains(unicodeCategory))
                    {
                        stringBuilder.Append(' ');
                    }
                    else
                    {
                        stringBuilder.Append(text[i]);
                    }
                }
            }

            return stringBuilder.ToString();
        }

        public static string SeparateCamelCase(this string inputCamelCaseString)
        {
            return Regex.Replace(inputCamelCaseString, "([A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        public static StringBuilder AppendAfterLine(this StringBuilder owner, string value)
        {
            owner.Append(Environment.NewLine);
            owner.Append(value);
            return owner;
        }

        public static string Abs(this string owner)
        {
            return owner.IsNullOrEmpty() ? null : owner;
        }

        private static int OccurrenceIndexOfAnyOccurrence(this string owner, string value, int occurrence)
        {
            IEnumerable<KeyValuePair<string, int>> source = from x in owner.Select((c, i) => new KeyValuePair<string, int>(owner.Substring(i), i))
                                                            where x.Key.StartsWith(value)
                                                            select x;
            return source.Count() < occurrence ? -1 : source.Select((x) => x.Value).ElementAtOrDefault(occurrence - 1);
        }

        private static int OccurrenceIndexOfExclusive(this string owner, string value, int occurrenceNumber)
        {
            Match match = Regex.Match(owner, "((" + value + ").*?){" + occurrenceNumber + "}");
            if (match.Success)
            {
                return match.Groups[2].Captures[occurrenceNumber - 1].Index;
            }

            return -1;
        }

        public static bool IsValidRegex(this string owner, string regex)
        {
            return Regex.IsMatch(owner, regex, RegexOptions.Compiled);
        }

        public static string Reverse(this string owner)
        {
            char[] array = owner.ToCharArray();
            Array.Reverse(array);
            return new string(array);
        }

        public static string PadLeftEx(this string owner, int length, char paddingChar)
        {
            string text = owner ?? string.Empty;
            if (text.Length <= length)
            {
                return text.PadLeft(length, paddingChar);
            }

            return text.Substring(0, length);
        }

        public static string PadRightEx(this string owner, int length, char paddingChar)
        {
            string text = owner ?? string.Empty;
            if (text.Length <= length)
            {
                return text.PadRight(length, paddingChar);
            }

            return text.Substring(0, length);
        }

        public static bool IsNumeric(this string owner)
        {
            return owner.Count((c) => char.IsNumber(c)) == owner.Length;
        }

        public static string TrocaCaracteresEspeciais(this string texto)
        {
            string text = texto.Normalize(NormalizationForm.FormD);
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < text.Length; i++)
            {
                UnicodeCategory unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(text[i]);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(text[i]);
                }
            }

            return stringBuilder.ToString();
        }

        public static string GZip(this string input)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input);
            using MemoryStream memoryStream2 = new MemoryStream(bytes);
            using MemoryStream memoryStream = new MemoryStream();
            using (GZipStream destination = new GZipStream(memoryStream, CompressionMode.Compress))
            {
                memoryStream2.CopyTo(destination);
            }

            return Convert.ToBase64String(memoryStream.ToArray());
        }

        public static string GUnZip(this string input)
        {
            byte[] buffer = Convert.FromBase64String(input);
            using MemoryStream stream = new MemoryStream(buffer);
            using MemoryStream memoryStream = new MemoryStream();
            using (GZipStream gZipStream = new GZipStream(stream, CompressionMode.Decompress))
            {
                gZipStream.CopyTo(memoryStream);
            }

            return Encoding.UTF8.GetString(memoryStream.ToArray());
        }

        public static string EncodeStringTo64(this string baseString)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(baseString ?? string.Empty);
            return Convert.ToBase64String(bytes);
        }

        public static string EncodeArrayOfStringTo64(this string[] arrayOfString)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (string value in arrayOfString)
            {
                stringBuilder.Append(value);
            }

            return stringBuilder.ToString().EncodeStringTo64();
        }

        public static bool GreaterThan(this string s, string other)
        {
            return string.Compare(s, other) > 0;
        }

        public static bool GreaterThanOrEqual(this string s, string other)
        {
            return string.Compare(s, other) >= 0;
        }

        public static bool LessThan(this string s, string other)
        {
            return string.Compare(s, other) < 0;
        }

        public static bool LessThanOrEqual(this string s, string other)
        {
            return string.Compare(s, other) <= 0;
        }

        public static string ReplaceExtendedAphabeticalChars(this string owner, string extendedCharsToPreserve = "")
        {
            string text = "áéíóúÁÉÍÓÚàèìòùÀÈÌÒÙãeiõuÃEIÕUâêîôûÂÊÎÔÛäëïöüÄËÏÖÜçÇ";
            string text2 = "aeiouAEIOUaeiouAEIOUaeiouAEIOUaeiouAEIOUaeiouAEIOUcC";
            for (int i = 0; i < text.Length; i++)
            {
                owner = owner.Replace(text[i], text2[i]);
            }

            Regex regex = new Regex("[^a-zA-Z0-9" + extendedCharsToPreserve.Trim() + " -]");
            return regex.Replace(owner, string.Empty);
        }

        public static string ToPascalCase(this string owner, bool removeWhiteSpaces = true)
        {
            if (!removeWhiteSpaces)
            {
                return Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(owner);
            }

            return string.Join(removeWhiteSpaces ? string.Empty : " ", from x in owner.Split(' ')
                                                                       select Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(x));
        }

        static string RemoveEmptySpacesAndJoin(string[] array)
        {
            List<string> filteredArray = new List<string>();
            for (int i = 0; i < array.Length; i++)
            {
                if (!array[i].IsNullOrWhiteSpace())
                {
                    filteredArray.Add(array[i]);
                }
            }
            return string.Join(",", filteredArray.ToArray());
        }


        public static bool IsNullOrEmptyOrWhiteSpace(this string value)
        {
            return string.IsNullOrEmpty(value) ||
                   ReferenceEquals(value, null) ||
                   string.IsNullOrEmpty(value.Trim(' '));
        }

    }
}
