
using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace StringStrtrExtension
{

    public static class StringExtension
    {

        // char => char (classic, with Strings, Ordinal)
        public static string StrTr(this string src, string fromChars, string toChars)
        {
            StringBuilder sb = new StringBuilder();
            int i;
            if (fromChars.Length > toChars.Length)
            {
                fromChars = fromChars.Substring(0, toChars.Length);
            }
            foreach (char c in src)
            {
                i = fromChars.IndexOf(c);
                if (i >= 0)
                {
                    sb.Append(toChars[i]);
                }
                else
                {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }


        // string, string (with array of Tuples), Ordinal
        public static string StrTr22(this string src, params (string Item1, string Item2)[] translatePairs)
        {
            // sort by length descending, making sure to compare longer Keys first!
            StringBuilder sb = new StringBuilder();
            int srcoffs = 0;
            string srctail;
            bool done;
            Array.Sort(translatePairs, (r1, r2) => (r2.Item1.Length.CompareTo(r1.Item1.Length)));
            while (srcoffs < src.Length)
            {
                srctail = src.Substring(srcoffs);
                done = false;
                foreach ((string Item1, string Item2) replacement in translatePairs)
                {
                    if (srctail.StartsWith(replacement.Item1, StringComparison.Ordinal))
                    {
                        sb.Append(replacement.Item2);
                        srcoffs += replacement.Item1.Length;
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    sb.Append(src[srcoffs]);
                    srcoffs++;
                }
            }
            return sb.ToString();
        }


       public static string StrTr(this string src, params (string, string)[] translatePairs)
        {
			List<(string, string)> pairs = translatePairs.ToList();
			string newsrc = src.StrTr(pairs);
			return newsrc;

        }


       public static string StrTr(this string src, params KeyValuePair<string, string>[] translatePairs)
        {
			List<KeyValuePair<string, string>> pairs = translatePairs.ToList();
			string newsrc = src.StrTr(pairs, StringComparison.Ordinal);
			return newsrc;

        }

        /********************************* IEnumerable **********************************/

        // string => string (with IEnumerable of KeyValuePairs<string, string>)
        public static string StrTr(this string src, IEnumerable<KeyValuePair<string, string>> replacePairs, StringComparison mode = StringComparison.Ordinal)
        {
            StringBuilder sb = new StringBuilder();
            int srcoffs = 0;
            string srctail;
            bool done;
			IEnumerable<KeyValuePair<string, string>> orderedPairs = replacePairs.Where(rp => rp.Key != "").OrderByDescending(rp => rp.Key.Length);
            while (srcoffs < src.Length)
            {
                srctail = src.Substring(srcoffs);
                done = false;
                foreach (KeyValuePair<string, string> rp in orderedPairs)
                {
                    if (srctail.StartsWith(rp.Key, mode))
                    {
                        sb.Append(rp.Value);
                        srcoffs += rp.Key.Length;
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    sb.Append(src[srcoffs]);
                    srcoffs++;
                }
            }
            return sb.ToString();
        }


        // string => string (with IEnumerable of Tuples<string, string>)
        public static string StrTr(this string src, IEnumerable<(string, string)> replacePairs, StringComparison mode = StringComparison.Ordinal)
        {
            StringBuilder sb = new StringBuilder();
            int srcoffs = 0;
            string srctail;
            bool done;
			IEnumerable<(string, string)> orderedPairs = replacePairs.Where(rp => rp.Item1 != "").OrderByDescending(rp => rp.Item1.Length);
            while (srcoffs < src.Length)
            {
                srctail = src.Substring(srcoffs);
                done = false;
                foreach ((string, string) rp in orderedPairs)
                {
                    if (srctail.StartsWith(rp.Item1, mode))
                    {
                        sb.Append(rp.Item2);
                        srcoffs += rp.Item1.Length;
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    sb.Append(src[srcoffs]);
                    srcoffs++;
                }
            }
            return sb.ToString();
        }



        // string => string (with IEnumerable of KeyValuePairs<string, string>)
        public static string StrTr(this string src, IEnumerable<KeyValuePair<string, string>> replacePairs, bool ignoreCase, System.Globalization.CultureInfo culture = null)
        {
            StringBuilder sb = new StringBuilder();
            int srcoffs = 0;
            string srctail;
            bool done;
			IEnumerable<KeyValuePair<string, string>> orderedPairs = replacePairs.Where(rp => rp.Key != "").OrderByDescending(rp => rp.Key.Length);
            while (srcoffs < src.Length)
            {
                srctail = src.Substring(srcoffs);
                done = false;
                foreach (KeyValuePair<string, string> rp in orderedPairs)
                {
                    if (srctail.StartsWith(rp.Key, ignoreCase, culture))
                    {
                        sb.Append(rp.Value);
                        srcoffs += rp.Key.Length;
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    sb.Append(src[srcoffs]);
                    srcoffs++;
                }
            }
            return sb.ToString();
        }


        // string => string (with IEnumerable of Tuples<string, string>)
        public static string StrTr(this string src, IEnumerable<(string, string)> replacePairs, bool ignoreCase, System.Globalization.CultureInfo culture = null)
        {
            StringBuilder sb = new StringBuilder();
            int srcoffs = 0;
            string srctail;
            bool done;
			IEnumerable<(string, string)> orderedPairs = replacePairs.Where(rp => rp.Item1 != "").OrderByDescending(rp => rp.Item1.Length);
            while (srcoffs < src.Length)
            {
                srctail = src.Substring(srcoffs);
                done = false;
                foreach ((string, string) rp in orderedPairs)
                {
                    if (srctail.StartsWith(rp.Item1, ignoreCase, culture))
                    {
                        sb.Append(rp.Item2);
                        srcoffs += rp.Item1.Length;
                        done = true;
                        break;
                    }
                }
                if (!done)
                {
                    sb.Append(src[srcoffs]);
                    srcoffs++;
                }
            }
            return sb.ToString();
        }


    }

}
