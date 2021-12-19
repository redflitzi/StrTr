# PHP's strtr for C#
Missing PHP's [strtr](https://www.php.net/manual/en/function.strtr.php) function oh so badly ... So I implemented it as a String extension. 

This extension provides an additional **String.StrTr** method in several overloaded flavors. Each **StrTr** method call does not change the original string, but returns a modified copy. The arguments vary.

<br/>

## Installation

Usage of this extension is simple:
1. Copy the file **StrTr.cs** to your workspace
2. Add the following line to your source file where you want to call **String.Strtr()**: \
 `using StringStrtrExtension;`
3. start calling the additional **StrTr** methods.

## Methods:

[**StrTr(string** fromChars **, string** toChars **)**](#m1)

<br/>

---

## Small and simple

These methods are simple and always work in Ordinal mode and case-sensitive. \
No culture info or string comparison mode is supported.  
<br/>
    

### **StrTr(string** fromChars **, string** toChars **)** {#m1}

This method returns a copy of the current string where all occurrences of each character in **fromChars** have been translated to the corresponding character in **toChars**, i.e., every occurrence of fromChars[n] has been replaced with toChars[n], where n is a valid offset in both arguments.

Call it just like: \
`mynewstring = mystring.StrTr("abcd","ABCD");`

This will replace every 'a' with 'A', 'b' with 'B', 'c' with 'C', and 'd' with 'D'.

<br/>

### **StrTr(params (string** Item1 **, string** Item2 **)[] ** replacePairs **)**

This method allows direct and literal use of tuples of (string, string) as arguments.\
Each tuple is a (original, replacement) pair.

Call it like: \
`myotherpet = mypet.StrTr(("cat","dog"), ("small","big"), ("meow", "woof woof"));`

So if mypet contains "My small cat says meow", myotherpet will be "My big dog says woof woof".

<br/>

--- 


## Culture-Aware 

A set of methods that take various enumerable collections with (original, replacement) pairs to apply to the input string. \
Additionally, they can take a culture info or string comparison mode. If this is omitted, they work in Ordinal mode.

<br/>

### **StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)**
      
This Method takes any enumerable collection of KeyValuePair als first argument. \
It is therefore suitable for consuming a Dictionary.

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





