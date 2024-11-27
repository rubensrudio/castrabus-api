using CastraBus.Common.Extensions;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace CastraBus.Common.Util
{
    /// <summary>
    /// Utility for string manipulation
    /// </summary>
    public static class StringUtil
    {
        /// <summary>
        /// Reads the xml data from a string and converts it into an object.
        /// </summary>
        /// <typeparam name="T">The type of object to convert to</typeparam>
        /// <param name="xml">The xml string</param>
        /// <returns>The object with converted data</returns>
        public static T ReadFromString<T>(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            byte[] byteArray = Encoding.UTF32.GetBytes(xml);
            using (var fs = new MemoryStream(byteArray))
            {
                T response;
                response = (T)serializer.Deserialize(fs);
                return response;
            }
        }

        /// <summary>
        /// Extracts a datetime from string
        /// </summary>
        /// <param name="dateString"></param>
        /// <returns></returns>
        public static DateTime ExtractDate(this string dateString, CultureInfo? culture = null)
        {
            if (culture == null) culture = new CultureInfo(Constants.Constants.Formatting.CULTURE_EN_US);

            try
            {
                return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_LONG_US, culture);
            }
            catch
            {
                try
                {
                    return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_LONG_SLASH, culture);
                }
                catch (Exception)
                {
                    try
                    {
                        return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_DD_MM_YYYY_HH_MM_SLASH, culture);
                    }
                    catch (Exception)
                    {
                        try
                        {
                            return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_DD_MM_Y_MINUS, culture);
                        }
                        catch
                        {
                            try
                            {
                                return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_YYYY_MM_DD_HH_MM_SS_SLASH, culture);
                            }
                            catch
                            {
                                try
                                {
                                    return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_YYYY_MM_DD_UNDESCORE, culture);
                                }
                                catch
                                {
                                    try
                                    {
                                        return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_SHORT_SLASH, culture);
                                    }
                                    catch
                                    {
                                        return DateTime.ParseExact(dateString, Constants.Constants.DateTime.DATE_YYYY_MM_DD_MINUS, culture);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Extracts a timespan from string
        /// </summary>
        /// <param name="datetime"></param>
        /// <returns></returns>
        public static TimeSpan ExtractTimeSpan(string datetime)
        {
            DateTime inicial = DateTime.FromOADate(Convert.ToDouble(datetime));
            TimeSpan ts;

            if (inicial.Day == 31 && inicial.Month == 12 && inicial.Year == 1899)
            {
                ts = new TimeSpan(24, 0, 0);
            }
            else
            {
                ts = new TimeSpan(inicial.Hour, inicial.Minute, inicial.Second);
            }

            return ts;
        }

        /// <summary>
        /// Returns a percentage value converted to decimal, gathered from a string.
        /// </summary>
        /// <param name="percentage"></param>
        /// <returns></returns>
        public static decimal ExtractPercentage(string percentage)
        {
            string sanitizedString = percentage.Replace("%", "").Replace("/64", "").Replace(",", ".").Trim();
            return decimal.Parse(sanitizedString);
        }

        /// <summary>
        /// Retuns a sanitized name for grouping items by installation id and reference date
        /// </summary>
        /// <param name="installationId"></param>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public static string SanitizeSendingGroupName(string installationId, string referenceDate)
        {
            return (installationId + Constants.Constants.Separators.UNDERSCORE + referenceDate)
                .Replace(Constants.Constants.Separators.WHITESPACE, string.Empty)
                .Replace(Constants.Constants.Separators.SLASH, string.Empty)
                .Replace(Constants.Constants.Separators.COLON.ToString(), string.Empty)
                .Replace(Constants.Constants.Separators.MINUS.ToString(), string.Empty);
        }

        /// <summary>
        /// Returns the last found separator from a string representing a number
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetSeparator(string input)
        {
            int lastCommaIndex = input.LastIndexOf(Constants.Constants.Separators.COMMA);
            int lastDotIndex = input.LastIndexOf(Constants.Constants.Separators.DOT);
            return lastCommaIndex > lastDotIndex ? Constants.Constants.Separators.COMMA.ToString() : Constants.Constants.Separators.DOT;
        }

        /// <summary>
        /// Extracts the reference date of a string, considering its length
        /// </summary>
        /// <param name="referenceDate"></param>
        /// <returns></returns>
        public static string GetReferenceDate(string referenceDate)
        {
            if (referenceDate != null)
            {
                int outerBound = Math.Min(referenceDate.Length, Constants.Constants.DateTime.DATE_SHORT_SLASH.Length);
                referenceDate = referenceDate.Substring(0, outerBound);
            }
            return referenceDate;
        }

        /// <summary>
        /// Returns if a filename matches for given file regex.
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public static bool CheckFileRegex(string filename, string regex)
        {
            Regex rx = new Regex(regex);
            return rx.IsMatch(filename);
        }

        /// <summary>
        /// Mounts the list of parameters for an IN clause
        /// </summary>
        /// <param name="query"></param>
        /// <param name="key"></param>
        /// <param name="values"></param>
        /// <param name="useStringSeparator"></param>
        /// <returns></returns>
        [Obsolete("Must be used the new way for pass to fortyfy, GetQuestion", false)]
        public static string MountInClause(string query, string key, List<string> values, bool useStringSeparator = true)
        {
            string groupedList = "";
            string format = useStringSeparator ? Constants.Constants.Formatting.QUERY_STRING_ITEM : Constants.Constants.Formatting.QUERY_ITEM;

            for (int i = 0; i < values.Count; i++)
            {
                groupedList = groupedList + string.Format(format, values[i]);
                if (i < values.Count - 1)
                {
                    groupedList = groupedList + Constants.Constants.Separators.COMMA;
                }
            }

            query = query.Replace(key, groupedList);
            return query;
        }

        /// <summary>
        /// Return A string with Question marks separated by common: ?,?,?,?....,?
        /// </summary>
        /// <param name="length">how many Question mark will be in string</param>
        /// <returns></returns>
        /// <remarks>Its possible, in the future, refactor this funciton to better function passa what char we want repeat and the separator we want</remarks>
        public static string GetQuestions(int length)
        {
            List<string> questions = new List<string>(length);
            questions.AddRange(Enumerable.Repeat("?", length));
            return questions.Join(",");
        }
    }
}
