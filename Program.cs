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

            var mydog = "My dog is friendly";
var betterthanyours = new Dictionary<string,string> ()
{
    {"My", "Your"},
    {"friendly", "nasty"}
}; 
var yourdog = mydog.StrTr(betterthanyours);
            Console.WriteLine("{0}, {1}.", mydog, yourdog);

		}		
    }
}
