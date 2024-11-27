using System.Text.RegularExpressions;

namespace CastraBus.Common.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Faz o Join de uma Lista de String
        /// </summary>
        /// <param name="listaText"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> listaText, string separador, string surroundChar = "")
        {
            string result;
            if (string.IsNullOrWhiteSpace(surroundChar))
            {
                result = listaText == null ?
                string.Empty :
                string.Join(separador, listaText.ToArray());
            }
            else
            {
                result = listaText == null ?
               string.Empty :
               string.Join(separador, listaText.Select(s => $"{surroundChar}{s}{surroundChar}").ToArray());
            }

            return result;
        }

        /// <summary>
        /// Faz o Join de uma Lista de String
        /// </summary>
        /// <param name="listaText"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string Join(this IDictionary<string, string> listaText, string separador)
        {
            return listaText == null ?
                string.Empty :
                string.Join(separador, listaText.Select(l => $"{l.Key}|{l.Value}").ToArray());
        }

        /// <summary>
        /// Faz o Join de uma Lista de String
        /// </summary>
        /// <param name="listaText"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string Join(this IEnumerable<string> listaText, char separador)
        {
            return Join(listaText, separador.ToString());
        }

        /// <summary>
        /// Faz o Join de uma Lista de String
        /// </summary>
        /// <param name="listaText"></param>
        /// <param name="separador"></param>
        /// <returns></returns>
        public static string Join(this IDictionary<string, string> listaText, char separador)
        {
            return Join(listaText, separador.ToString());
        }

        /// <summary>
        /// Retorna "numberOfCharacters" a esqueda de uma string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="numberOfCharacters"></param>
        /// <returns></returns>
        public static string Left(this string text, int numberOfCharacters)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            if (numberOfCharacters > text.Length)
                numberOfCharacters = text.Length;
            return text.Substring(0, numberOfCharacters);
        }

        /// <summary>
        /// Retorna "numberOfCharacters" a direita de uma string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="numberOfCharacters"></param>
        /// <returns></returns>
        public static string Right(this string text, int numberOfCharacters)
        {
            if (string.IsNullOrEmpty(text)) return string.Empty;
            if (numberOfCharacters > text.Length)
                numberOfCharacters = text.Length;
            return text.Substring(text.Length - numberOfCharacters);
        }

        /// <summary>
        /// Cleans up the received xml and replace some contents, in order to turn the data readable.
        /// </summary>
        /// <param name="source"></param>
        /// <returns>The sanitized string</returns>
        public static string SanitizeXmlString(this string source)
        {
            if (!string.IsNullOrEmpty(source))
            {
                string pattern = @"a[0-9]{3}";
                source = source.Replace("&lt;?xml version=\"1.0\"?&gt;", "");
                source = source.Replace("&lt;", "<");
                source = source.Replace("&gt;", ">");
                source = Regex.Replace(source, pattern, "FILE");
            }

            return source;
        }

        /// <summary>
        /// Convert a String to Base64 Stream 
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string ToBase64(this string plainText)
        {
            if (plainText.IsNullOrWhiteSpace()) return plainText;
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return Convert.ToBase64String(plainTextBytes);
        }

        /// <summary>
        /// Converto a Base 64 Stream to String
        /// </summary>
        /// <param name="base64EncodedData"></param>
        /// <returns></returns>
        public static string FromBase64(this string base64EncodedData)
        {
            if (base64EncodedData.IsNullOrWhiteSpace()) return base64EncodedData;
            var base64EncodedBytes = Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        /// <summary>
        /// Verifica se a string eh nula ou so espaços em branco
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Convert a String in Format YYYYMM to DateTime, and Day 1
        /// </summary>
        /// <param name="yearMonth"></param>
        /// <returns></returns>
        public static DateTime ConvertYearMonthToDateTime(this string yearMonth)
        {
            return new DateTime(yearMonth.Substring(0, 4).Parse<int>(), yearMonth.Substring(4, 2).Parse<int>(), 1);
        }

        /// <summary>
        /// Verify a valid email 
        /// </summary>
        /// <param name="emailaddress"></param>
        /// <returns></returns>
        public static bool EmailIsValid(this string emailaddress)
        {
            Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*" + "@" + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
            Match match = regex.Match(emailaddress);
            return match.Success;
        }

        public static List<int> AllIndexesOf(this string str, string value)
        {
            List<int> indexes = new List<int>();
            if (str.IsNullOrWhiteSpace()) return indexes;
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        /// <summary>
        /// Make Corrections in string to search in database
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SanitizeDataBaseString(this string value)
        {
            Regex re = new Regex(@"[<*>*\\*~*\^*!*@*#*$*%*\**(*)*\xA8*)]", RegexOptions.IgnoreCase | RegexOptions.Multiline);
            return re.Replace(value, string.Empty).Replace("'", "''"); // acho que nao precisa disso????.Replace("\"","\"\"");
        }

        /// <summary>
        /// remove specif character from a string
        /// </summary>
        /// <param name="text"></param>
        /// <param name="character"></param>
        /// <param name="onlyIfLast"></param>
        /// <returns></returns>
        public static string RemoveLast(this string text, string character, bool onlyIfLast = true)
        {
            if (text.IsNullOrWhiteSpace()) return "";
            if (text.Length < 1) return text;
            if (text.LastIndexOf(character) != (text.Length - 1) && onlyIfLast)
            {
                return text;
            }

            return text.Remove(text.ToString().LastIndexOf(character), character.Length);
        }
    }
}
