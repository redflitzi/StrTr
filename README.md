# PHP's strtr for C#
Missing PHP's strtr function oh so badly ... \
So I implemented it as a String extension. 
## Installation

Usage of this extension is simple:
1. Copy the file StrTr.cs to your workspace
2. add the line: \
 `using StringStrtrExtension;` \
 to your source
3. use the additional StrTr methods.

<br/>


## Small and simple

These methods are simple and always work in Ordinal mode and case-sensitive. \
No cultures infos or string comparison modes are supported.  
<br/>
    

**StrTr(string** fromChars **, string** toChars **)**

This method works just like the function in PHP, with one string for the original chars and one for the replacement characters.

Call it just like: \
`mynewstring = mystring.StrTr("abcd","ABCD");` \
This will replace every 'a' with 'A', 'b' with 'B', 'c' with 'C' and 'd' with 'D'.

<br/>

**StrTr(params (string** Item1 **, string** Item2 **)[] ** replacePairs **)**

This method allows direct and literal use of tuples of (string, string) as parameters.

Call it like: \
`mynewstring = mystring.StrTr(("cat","dog"), ("small","big"), ("meow", "woof woof"));`

<br/>

## Culture-Aware 

A set of methods that takes various enumerable collections to change the input string. \
Additionally, they can take a culture info or string comparison mode. If this is omitted, they work in Ordinal mode.

<br/>

**StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)**
      
This Method takes any enumerable collection of KeyValuePair als first argument. \
It is especially suitable for consuming a Dictionary.

```
var mydog = "My dog is friendly";
var betterthanyours = new Dictionary<string,string> ()
{
    {"My", "Your"},
    {"friendly", "nasty"}
}; 
var yourdog = mydog.StrTr(betterthanyours);
Console.WriteLine("{0}, {1}.", mydog, yourdog);
```
Results in: \
My dog is friendly, Your dog is nasty.





