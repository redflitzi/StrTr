using System;
using System.Linq;
using System.Globalization;
using System.Collections.Generic;
using StringStrtrExtension;

namespace StrtrApp
{
    class Program
    {
        public static void Main(string[] args)
        {

            Console.WriteLine();
	    string input ="baab";
	    string output = input.StrTr("ab", "ba");

	    Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            input = "hallodrihallodra";
            output =  input.StrTr (("dri","dra"), ("dra","dri"));

            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            var kvpdict = new Dictionary<string,string> ()
            {
                {"hallo", "hi"},
                {"dri", "dra"},
                {"dra", "drix"}
            };

            output = input.StrTr(kvpdict);
            
            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            var tupleList = new List<(string, string)>
            {
                ("hallo", "cow"),
                ("Dri", "chicken"),
                ("RA", "dog")
            };
            output = input.StrTr(tupleList,StringComparison.OrdinalIgnoreCase);
            
            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            output = input.StrTr(tupleList,false);
            
            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            var tupleArray = new (string, string)[]
            {
                ("hallo", "cow"),
                ("Dri", "chicken"),
                ("RA", "dog")
            };
            output = input.StrTr(tupleArray,StringComparison.OrdinalIgnoreCase);
            
            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

            output = input.StrTr(tupleArray,false,CultureInfo.CurrentCulture);
            
            Console.WriteLine("input: {0}, output: {1}", input, output);            
            Console.WriteLine();

 
 
            var animals = "dogcathorsecow";
            var animalsReplace = animals.Replace("dog","cat").Replace("cat","horse").Replace("horse","cow").Replace("cow","bird");
            var animalsStrTr = animals.StrTr(("dog","cat"),("cat","horse"),("horse","cow"),("cow","bird"));

            Console.WriteLine("animalsReplace: {0}", animalsReplace);
            Console.WriteLine("animalsStrTr: {0}", animalsStrTr);  

	}		
    }
}
