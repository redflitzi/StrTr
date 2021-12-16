
using System;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections.Generic;

namespace StrtrExtension
{

public static class StringExtension {

// char => char (classic, with Strings, Ordinal)
public static string StrTr(this string src, string from, string to) {
  StringBuilder sb = new StringBuilder();
  int i;
	if (from.Length > to.Length) {
		from = from.Substring(0, to.Length);
	}
	foreach (char c in src) {
		i = from.IndexOf(c);
		if (i >= 0) {
			sb.Append(to[i]);
		} else {
			sb.Append(c);
		}
	}
	return sb.ToString();
}



// string => string (with List of KeyValuePairs<string, string>)
public static string StrTr(this string src, List<KeyValuePair<string, string>> replacePairs, StringComparison mode = StringComparison.Ordinal) {
  StringBuilder sb = new StringBuilder();
  int srcoffs = 0;
  string srctail;
  bool done;
	// sorting Keys by descending length makes sure to apply longer Keys first!
	replacePairs.Sort(( r1, r2) => (r2.Key.Length.CompareTo(r1.Key.Length)));
	replacePairs.RemoveAll(r => r.Key == "");
	while (srcoffs < src.Length) {
		srctail = src.Substring(srcoffs);
		done = false;
		foreach (KeyValuePair<string, string> replacePair in replacePairs) {
			if (srctail.StartsWith(replacePair.Key, mode)) {
				sb.Append(replacePair.Value);
				srcoffs += replacePair.Key.Length;
				done = true;
				break;
			}
		}
		if (!done) {
			sb.Append(src[srcoffs]);
			srcoffs++;
		}
	}
	return sb.ToString();
}


// string => string (with Dictionary)
public static string StrTr(this string src, Dictionary<string, string> replacePairs, StringComparison mode = StringComparison.Ordinal) {
	List<KeyValuePair<string, string>> replaceList = replacePairs.ToList(); // ist this expensive?
	return src.StrTr(replaceList, mode);
}


// string, string (with array of Tuples), Ordinal
public static string StrTr(this string src, params (string Key, string Value)[] replacePairs) {
	// sort by length descending, making sure to compare longer Keys first!
  StringBuilder sb = new StringBuilder();
  int srcoffs = 0;
  string srctail;
  bool done;
	Array.Sort(replacePairs, (r1, r2) => (r2.Key.Length.CompareTo(r1.Key.Length)));
	while (srcoffs < src.Length) {
		srctail = src.Substring(srcoffs);
		done = false;
		foreach ((string Key, string Value) replacement in replacePairs) {
			if (srctail.StartsWith(replacement.Key, StringComparison.Ordinal)) {
				sb.Append(replacement.Value);
				srcoffs += replacement.Key.Length;
				done = true;
				break;
			}
		}
		if (!done) {
			sb.Append(src[srcoffs]);
			srcoffs++;
		}
	}
	return sb.ToString();
}


}

} // namespace StrtrExtension
