using System;
using System.Linq;
using static System.Console;
using StrtrExtension;

namespace StrtrApp
{
    class Program
    {
        static void Main(string[] args)
        {

			string input ="baab";
			output = input.StrTr("ab", "ba");

			WriteLine("input: {0}, output: {1}", input, output);

		}
    }
}
