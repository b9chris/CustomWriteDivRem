using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DivRem
{
	class Program
	{
		static void Main(string[] args)
		{
			runTest();
			//verifyMethods();
			//verifyMethod();
			Console.ReadLine();
		}

		static void runTest()
		{
			var harness = new Harness(Console.Out);
			var methods = new SerializeMethods();

			for (int i = 0; i < 10; i++ )
			{
				//harness.Test(methods.CustomWriteInt_MathDivRem);
				//harness.Test(methods.CustomWriteInt_AllInt);
				harness.Test(methods.CustomWriteInt_Standard);
				//harness.Test(methods.CustomWriteInt_Preallocate);
				//harness.Test(methods.CustomWriteInt_CustomDivMod);
				harness.Test(methods.CustomWriteInt_Unrolled);
			}
		}

		static void verifyMethods()
		{
			var r = new Random();
			var n = r.Next();
			var methods = new SerializeMethods();

			var fns = new Func<int, char[]>[] {
				methods.CustomWriteInt_AllInt,
				methods.CustomWriteInt_CustomDivMod,
				methods.CustomWriteInt_MathDivRem,
				methods.CustomWriteInt_Preallocate,
				methods.CustomWriteInt_Standard,
				methods.CustomWriteInt_Unrolled
			};

			foreach(var fn in fns)
			{
				var s = new String(fn(n));
				Console.WriteLine(s);
			}
		}

		static void verifyMethod()
		{
			int[] tests = new int[]
			{
				0, 1,
				10, 11,
				100, 101,
				1000,
				10000,
				100000,
				1000000,
				10000000,
				100000000,
				1000000000
			};

			var methods = new SerializeMethods();

			foreach(int n in tests)
			{
				var s = new String(methods.CustomWriteInt_Unrolled(n));
				Console.WriteLine(s);
			}
		}
	}
}
