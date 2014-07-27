using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DivRem
{
	public class SerializeMethods
	{
		const int maxNumLength = 10;

		public char[] CustomWriteInt_Standard(int number)
		{
			var buffer = new char[maxNumLength];
			var ptr = buffer.Length - 1;
			char zero = '0';

			uint copy;
			if (number < 0)
				copy = (uint)(-number);
			else
				copy = (uint)number;

			do
			{
				byte ix = (byte)(copy % 10);
				copy /= 10;

				buffer[ptr--] = (char)(zero + ix);
			} while (copy != 0);

			return buffer;
		}

		public char[] CustomWriteInt_Preallocate(int number)
		{
			var buffer = new char[maxNumLength];
			var ptr = buffer.Length - 1;
			char zero = '0';
			byte ix;

			uint copy;
			if (number < 0)
				copy = (uint)(-number);
			else
				copy = (uint)number;

			do
			{
				ix = (byte)(copy % 10);
				copy /= 10;

				buffer[ptr--] = (char)(zero + ix);
			} while (copy != 0);

			return buffer;
		}

		public char[] CustomWriteInt_CustomDivMod(int number)
		{
			var buffer = new char[maxNumLength];
			var ptr = buffer.Length - 1;
			char zero = (char)'0';

			uint copy;
			uint div;
			if (number < 0)
				copy = (uint)(-number);
			else
				copy = (uint)number;

			do
			{
				div = copy / 10;
				byte ix = (byte)(copy - 10 * div);
				copy = div;

				buffer[ptr--] = (char)(zero + ix);
			} while (copy != 0);

			return buffer;
		}

		public char[] CustomWriteInt_MathDivRem(int number)
		{
			var buffer = new char[maxNumLength];
			var ptr = buffer.Length - 1;
			char zero = (char)'0';

			uint copy;
			if (number < 0)
				copy = (uint)(-number);
			else
				copy = (uint)number;

			do
			{
				int ix;
				copy = (uint)Math.DivRem((int)copy, 10, out ix);

				buffer[ptr--] = (char)(zero + ix);
			} while (copy != 0);

			return buffer;
		}


		public char[] CustomWriteInt_AllInt(int number)
		{
			var buffer = new char[maxNumLength];
			var ptr = buffer.Length - 1;
			char zero = '0';

			if (number < 0)
				number = -number;

			do
			{
				int ix = number % 10;
				number /= 10;

				buffer[ptr--] = (char)(zero + ix);
			} while (number != 0);

			return buffer;
		}

		public char[] CustomWriteInt_Unrolled(int number)
		{
			var buffer = new char[maxNumLength];
			char zero = '0';

			if (number < 0)
				number = -number;

			// Binary search for length of int
			if (number >= 10000)
			{
				if (number >= 1000000)	// 1 million
				{
					if (number >= 10000000)	// 10 million
					{
						if (number >= 100000000)	// 100 million
						{
							if (number < 1000000000)	// 1billion
								goto digit1;
							//else
							//goto digit0;
						}
						else
						{
							goto digit2;
						}
					}
					else
					{
						goto digit3;
					}
				}
				else
				{
					if (number >= 100000)
					{
						goto digit4;
					}
					//else
					goto digit5;
				}
			}
			else
			{
				if (number >= 100)
				{
					if (number >= 1000)
					{
						goto digit6;
					}
					//else
					goto digit7;
				}
				else
				{
					if (number >= 10)
					{
						goto digit8;
					}
					//else
					goto digit9;
				}
			}


			buffer[0] = (char)(number / 1000000000 % 10 + zero);	// billions place
			digit1:
			buffer[1] = (char)(number / 100000000 % 10 + zero);
			digit2:
			buffer[2] = (char)(number / 10000000 % 10 + zero);
			digit3:
			buffer[3] = (char)(number / 1000000 % 10 + zero);	// millions place
			digit4:
			buffer[4] = (char)(number / 100000 % 10 + zero);
			digit5:
			buffer[5] = (char)(number / 10000 % 10 + zero);
			digit6:
			buffer[6] = (char)(number / 1000 % 10 + zero);
			digit7:
			buffer[7] = (char)(number / 100 % 10 + zero);
			digit8:
			buffer[8] = (char)(number / 10 % 10 + zero);
			digit9:
			buffer[9] = (char)(number % 10 + zero);

			return buffer;
		}
	}
}
