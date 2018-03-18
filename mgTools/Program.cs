using mgTools.canvas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools
{
	public class Program
	{
		static void Main(string[] args)
		{
			try
			{
				switch (args[0].ToLower())
				{
					case "canvas":
						Execute(new CanvasArguments(args), new CanvasProgram());
						break;
					default:
						Console.Out.WriteLine(args[0] + " is an unknown command");
						break;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
#if DEBUG
				Console.Out.WriteLine(ex.StackTrace);
#endif
			}

			Console.Out.WriteLine("End of Process");
#if DEBUG
			Console.In.Read();
#endif	
		}

		private static void Execute(Arguments args, IExecute exec)
		{
			if (args.ParseArguments())
			{
				exec.Exec(args);
			}
		}
	}
}
