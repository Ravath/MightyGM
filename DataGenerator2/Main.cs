﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGenerator2;
using QUT.Gppg;
using DataGenerator2.Parser;
using DataGenerator2.DataModel;

namespace DataGenerator2 {
	public static class MainClass {
		static void Main( string[] args ) {
			Parser.Parser parser = new Parser.Parser();

			System.IO.TextReader reader;
			if(args.Length > 0)
				reader = new System.IO.StreamReader(args[0]);
			else {
				System.Console.WriteLine("File path expected");
				return;
			}

			parser.Scanner = new Parser.Parser.Lexer(reader);

			try {
				parser.Parse();
				Console.WriteLine();
				Console.WriteLine("Parsing ended without problem...");
			} catch(Exception lex) {
				Console.WriteLine();
				Console.WriteLine(lex.Message);
				Console.WriteLine(lex.StackTrace);
				Console.WriteLine("Parsing ended with an error and stopped the generation.");
				Console.In.ReadLine();
				return;
			}
#if !DEBUG
			try {
#endif
				Database db = new Database(parser.RawData);
				Console.WriteLine("Model elaborated...");
			if(db.CheckIntegrity()) {
				Console.WriteLine("Integrity checked...");
				DetailedTables dt;
					dt = db.FinalTables;
					ModelGenerator mg = new ModelGenerator();
					mg.GenererProjet(dt);
					Console.WriteLine("Generation Done.");
				} else {
					Console.WriteLine("Some errors has been found and the data will not be generated.");
			}
#if !DEBUG
			} catch(Exception ex) {
				Console.WriteLine("An error Has occured and stopped the generation:");
				Console.WriteLine(ex.Message);
		}
#endif
			Console.In.ReadLine();
		}
	}
}
