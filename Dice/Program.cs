using Core.Dice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dice
{
	/// <summary>
	/// Interpret and Roll a Macro Dice.
	/// </summary>
	class Program
	{
		static void Main(string[] args)
		{
			string macro = args[0];
			try
			{
				IRoll result = Core.Dice.Procedures.Parse(macro);
				if (result!=null)
				{
					Console.WriteLine(String.Format("{0,-9} = {1, -9} > {2,-9} = {3}",
						macro,
						'[' + GetDice(result.Result) + ']',
						'[' + GetKeptDice(result.Result) + ']',
						result.NetResult));
				}
				else
				{
					Console.WriteLine("Parsing ended with problem...");
				}
			}
			catch (Exception lex)
			{
				Console.WriteLine(lex.Message);
				Console.WriteLine(lex.StackTrace);
				Console.WriteLine("Parsing aborted with an error and stopped the generation.");
			}
		}

		public static string GetDice(IEnumerable<DiceResult> dice)
		{
			string res = "";
			int i = 0;
			foreach (DiceResult item in dice)
			{
				if (i != 0)
				{
					res += (";" + item.result);
				}
				else
				{
					res += item.result.ToString();
					i++;
				}
			}
			return res;
		}

		public static string GetKeptDice(IEnumerable<DiceResult> dice)
		{
			string res = "";
			int i = 0;
			foreach (DiceResult item in dice.Where(d => d.kept))
			{
				if (i != 0)
				{
					res += (";" + item.result);
				}
				else
				{
					res += item.result.ToString();
					i++;
				}
			}
			return res;
		}
	}
}
