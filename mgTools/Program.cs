using mgTools.canvas;
using mgTools.ImportExcel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mgTools
{
	public class Program
	{
		private const string doc =
@"
	== MGTools ==
A tool box for many usefull processes, especially during development.
Arguments are <name of the tool> <arguments of the tool>.

	Processes : 
	 - canvas
		Arguments : DllPath, OutPath
	 - excel
		Arguments : SubProcess, <subArgs>
		SubProcesses : 
			check	   : arguments : DllPath, ExcelPath
			import	   : arguments : DllPath, ExcelPath, TypeName
			importAll  : arguments : DllPath, ExcelPath
";

		static void Main(string[] args)
		{
			try
			{
				switch (args[0].ToLower())
				{
					case "-h":
					case "help":
					case "-help":
					case "--help":
						Console.Out.WriteLine(doc);
						break;
					case "excel":
						Execute(new ExcelArguments(args), new ExcelProgram());
						break;
					case "canvas":
						Execute(new CanvasArguments(args), new CanvasProgram());
						break;
					default:
						Console.Out.WriteLine(args[0] + " is an unknown mgTools command");
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
