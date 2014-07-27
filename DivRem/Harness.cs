using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DivRem
{
	public class Harness
	{
		protected TextWriter writer;
		protected int counter = 1;

		const int times = 1000000;
		char[][] strings = new char[times][];
		int[] rands = new int[times];
		

		public Harness(TextWriter writer, int max = int.MaxValue)
		{
			this.writer = writer;

			var r = new Random();
			for(int i = times - 1; i >= 0; i--)
			{
				rands[i] = r.Next(max);
			}
		}

		public void Test(Func<int, char[]> method)
		{
			DateTime start = DateTime.Now;
			for(int i = times - 1; i >= 0; i--)
			{
				strings[i] = method(rands[i]);
			}
			DateTime end = DateTime.Now;

			writer.Write("Method ");
			writer.Write(counter);
			writer.Write(": ");
			writer.WriteLine((end - start).TotalSeconds);
			counter++;
		}
	}
}
