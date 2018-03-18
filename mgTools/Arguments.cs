using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools
{
	public abstract class Arguments
	{
		private string[] args;
		private int index = 1;
		public Arguments(string[] args)
		{
			this.args = args;
		}

		public bool HasNext()
		{
			return index < args.Length;
		}

		public bool CheckMin(int min)
		{
			if(args.Length < min + 1)
			{
				Console.Out.WriteLine("Minimum number of arguments is: " + min);
				return false;
			}
			return true;
		}

		public bool CheckMax(int max)
		{
			if (args.Length > max + 1)
			{
				Console.Out.WriteLine("Maximum number of arguments is: " + max);
				return false;
			}
			return true;
		}

		public bool CheckArgsNumber(int number)
		{
			return CheckMin(number) && CheckMax(number);
		}

		public string GetNext()
		{
			return args[index++];
		}

		public abstract bool ParseArguments();


	}
}
