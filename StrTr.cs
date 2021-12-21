
using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace StringStrtrExtension
{

    public static class StringExtension
    {

        // char => char (classic, with from/to Strings, Ordinal)
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
    	public static string StrTr(this string src, params (string, string)[] replacePairs)
        {
	    string newsrc = src.StrTr(replacePairs, StringComparison.Ordinal);
	    return newsrc;

        }


        /********************************* IEnumerable **********************************/

        // string => string (with IEnumerable of KeyValuePairs<string, string> and StringComparison)
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


        // string => string (with IEnumerable of Tuples<string, string> and StringComparison)
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



        // string => string (with IEnumerable of KeyValuePairs<string, string> and CultureInfo)
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


        // string => string (with IEnumerable of Tuples<string, string> and CultureInfo)
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
