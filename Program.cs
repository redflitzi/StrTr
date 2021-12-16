using System;
using System.Linq;
using StrtrExtension;

namespace StrtrApp
{
    class Program
    {
        public static void Main(string[] args)
        {

			string input ="baab";
			string output = input.StrTr("ab", "ba");

			Console.WriteLine("input: {0}, output: {1}", input, output);

            input = "hallodrihallodra";
            output =  input.StrTr (("dri","dra"), ("dra","dri"));

            Console.WriteLine("input: {0}, output: {1}", input, output);

		}
    }
}
