using DataGenerator.DataModel;
using System;

namespace DataGenerator
{
	public static class MainClass {
		static void Main( string[] args ) {
			Parser.Parser parser = new Parser.Parser();

			//Get File
			System.IO.TextReader reader;
			if(args.Length > 0)
				reader = new System.IO.StreamReader(args[0]);
			else {
				System.Console.WriteLine("File path expected");
				return;
			}

			//Parse File
			parser.Scanner = new Parser.Parser.Lexer(reader);
			Console.WriteLine();
			try
			{
				if (parser.Parse()) {
					Console.WriteLine("Parsing ended without problem...");
				} else {
					Console.WriteLine("Parsing ended with problem...");
					Console.In.ReadLine();
					return;
				}
			} catch(Exception lex) {
				Console.WriteLine(lex.Message);
				Console.WriteLine(lex.StackTrace);
				Console.WriteLine("Parsing abouted with an error and stopped the generation.");
				Console.In.ReadLine();
				return;
			}
#if !DEBUG
			try {
#endif
			//Create model
			DatabaseModel dm = Converter.Convert(parser.RawData);
			dm.Print(Console.Out);
			if (ErrorManager.Conclude())
			{
				DataModel.Generation gn = new DataModel.Generation();
				gn.Generate(dm);

				Console.WriteLine("Generation Done.");
			}
#if !DEBUG
			} catch(Exception ex) {
				Console.WriteLine("An error Has occured and stopped the generation:");
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
#endif
#if DEBUG
			Console.In.ReadLine();
#endif
		}
	}
}
