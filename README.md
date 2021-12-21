# PHP's strtr for C#
Missing PHP's [strtr](https://www.php.net/manual/en/function.strtr.php) function oh so badly ... So I implemented it as a String extension. 

This extension provides an additional **String.StrTr** method in several overloaded flavors. Each **StrTr** method call does not change the original string, but returns a modified copy. The arguments vary.

Using **StrTr** method with a collection of replacements, each character of the string will be replaced at most once. \
In the opposite, when chaining several **Replace** calls, each call will potentially replace all characters,so each position can be modified more than once. See [below](#why-not-simply-use-a-series-of-stringreplace).

## Installation

Usage of this extension is simple:
1. Copy the file **StrTr.cs** to your workspace
2. Add the following line to your source file where you want to call **String.Strtr()**: \
 `using StringStrtrExtension;`
3. start calling the additional **StrTr** methods.

## Methods:

### [**StrTr(string** fromChars **, string** toChars **)**](#id-s1)
### [**StrTr(params (string** Item1 **, string** Item2 **)[]** replacePairs **)**](#id-s2)
### [**StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)**](#kvp-sc)
### [**StrTr(IEnumerable<(string, string)>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)**](#tup-sc)
### [**StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **bool** ignoreCase, **System.Globalization.CultureInfo** culture = null **)**](#kvp-cu)
### [**StrTr(IEnumerable<(string, string)>** replacePairs,  **bool** ignoreCase, **System.Globalization.CultureInfo** culture = null **)**](#tup-cu)

<br/>

---

## Small and simple

These methods are simple and always work in Ordinal mode and case-sensitive. \
No culture info or string comparison mode is supported.  
<br/>
    

### **StrTr(string** fromChars **, string** toChars **)** <a id="id-s1"></a>

This method returns a copy of the current string where all occurrences of each character in **fromChars** have been translated to the corresponding character in **toChars**, i.e., every occurrence of fromChars[n] has been replaced with toChars[n], where n is a valid offset in both arguments.

Call it just like: \
```
var mystring = "a dog is a bad cat";

// replace each 'a' with 'A', 'b' with 'B', 'c' with 'C', and 'd' with 'D'
var mynewstring = mystring.StrTr("abcd","ABCD");
Console.WriteLine(mynewstring);
```
Results in: \
A Dog is A BAD CAt

<br/>

### **StrTr(params (string** Item1 **, string** Item2 **)[]** replacePairs **)** <a id="id-s2"></a>

This method allows direct and literal use of tuples of (string, string) as arguments.\
Each tuple is a (original, replacement) pair.

Call it like: \
```
var mypet = "My small cat says meow";

// replace each "cat" with "dog", "small" with "big", and "meow" with "woof woof"
var myotherpet = mypet.StrTr(("cat","dog"), ("small","big"), ("meow", "woof woof"));
Console.WriteLine(myotherpet);
```
Results in: \
My big dog says woof woof

<br/>

--- 


## Culture-Aware 

A set of methods that take various enumerable collections with (original, replacement) pairs to apply to the input string. \
Additionally, they can take a culture info or string comparison mode. If this is completely omitted, they work in Ordinal mode.

<br/>

### **StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)** <a id="kvp-sc"></a>
      
This Method takes any enumerable collection of KeyValuePair as its first argument. \
It is therefore suitable for consuming a Dictionary. \
Each Key will be replaced with the Value of the same KeyValuePair.

An optional StringComparison enum argument allows specifying what type of comparison will be used for identifying the Key in the original string.

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



<br/>

### **StrTr(IEnumerable<(string, string)>** replacePairs, **StringComparison** mode = StringComparison.Ordinal **)**<a id="tup-sc"></a>
      
This Method takes any enumerable collection of tuples<string, string> as its first argument. \
It is therefore suitable for a List or Array of (original, replacement) tuples. \
Each Item1 will be replaced by Item2 of the same tuple.

An optional StringComparison enum argument allows specifying what type of comparison will be used for identifying Item1 to replace in the original string.


```
var mydog = "My dog is friendly";
var betterthanyours = new (string, string)[]
{
    ("MY", "Your"),
    ("FrIeNdLy", "nasty")
};
         
var yourdog = mydog.StrTr(betterthanyours,StringComparison.OrdinalIgnoreCase);
Console.WriteLine("{0}, {1}.", mydog, yourdog);
```
Results in: \
My dog is friendly, Your dog is nasty.


<br/>

### **StrTr(IEnumerable<KeyValuePair<string, string>>** replacePairs, **bool** ignoreCase, **System.Globalization.CultureInfo** culture = null **)** <a id="kvp-cu"></a>
      
This Method takes any enumerable collection of KeyValuePair as its first argument. \
It is therefore suitable for consuming a Dictionary. \
Each Key will be replaced with the Value of the same KeyValuePair.

For identifiying the Key in the original string, the ignore casing mode and optionally a culture info can be added. If the culture info is omitted, the default setting will be used (CultureInfo.CurrentCulture).


```
var mydog = "My dog is friendly";
var betterthanyours = new Dictionary<string,string> ()
{
    {"MY", "Your"},
    {"FRIENDLY", "nasty"}
}; 
var yourdog = mydog.StrTr(betterthanyours, true);
Console.WriteLine("{0}, {1}.", mydog, yourdog);
```
Results in: \
My dog is friendly, Your dog is nasty.



<br/>

### **StrTr(IEnumerable<(string, string)>** replacePairs, **bool** ignoreCase, **System.Globalization.CultureInfo** culture = null **)**<a id="tup-cu"></a>
      
This Method takes any enumerable collection of tuples<string, string> as its first argument. \
It is therefore suitable for a List or Array of (original, replacement) tuples. \
Each Item1 will be replaced by Item2 of the same tuple.

For identifiying Item1 in the original string, the ignore casing mode and optionally a culture info can be added. If the culture info is omitted, the default setting will be used (CultureInfo.CurrentCulture).

```
var mydog = "My dog is friendly";
var betterthanyours = new (string, string)[]
{
    ("My", "Your"),
    ("friendly", "nasty")
};
         
var yourdog = mydog.StrTr(betterthanyours, false, CultureInfo.CurrentCulture);
Console.WriteLine("{0}, {1}.", mydog, yourdog);
```
Results in: \
My dog is friendly, Your dog is nasty.


---

## Why not simply use a series of String.Replace?

**Because it does not do the same.** \
String.Replace replaces all occurences in the whole string. If you call it several times, any position in the string can be modified several times. \
In the opposite, if you call String.StrTr with a collection of all desired replacements, each position will only be modified once.

Consider the following:
````
var animals = "dogcathorsecow";

var animalsReplace = animals.Replace("dog","cat").Replace("cat","horse").Replace("horse","cow").Replace("cow","bird");

var animalsStrTr = animals.StrTr(("dog","cat"),("cat","horse"),("horse","cow"),("cow","bird"));

Console.WriteLine("Replace: {0}", animalsReplace);
Console.WriteLine("StrTr: {0}", animalsStrTr);
````
This will result in: \
Replace: birdbirdbirdbird \
StrTr: cathorsecowbird

