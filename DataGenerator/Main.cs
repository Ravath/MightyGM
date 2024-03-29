﻿using DataGenerator.DataModel;
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
				Console.WriteLine("File path expected");
				return;
			}

			//Parse File
#if DEBUG
			Console.Out.WriteLine("Start Parsing : ");
#endif
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
				Console.WriteLine("Parsing aborted with an error and stopped the generation.");
				Console.In.ReadLine();
				return;
			}
			try {
				//Create model
				DatabaseModel dm = Converter.Convert(parser.RawData);
#if DEBUG
				dm.Print(Console.Out);
#endif
				if (ErrorManager.Conclude())
				{
					Generation gn = new Generation();
					gn.Generate(dm);

					Console.WriteLine("Generation Done.");
				}
			} catch(Exception ex) {
				Console.WriteLine("An error Has occured and stopped the generation:");
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
#if DEBUG
			Console.In.ReadLine();
#endif
		}
	}
}
