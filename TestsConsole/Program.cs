using System;
using System.Linq;
using Core.Data;
using Core.Dice;
using Core.Engine;
using System.Collections.Generic;
using System.Text;
using DataGenerator;
using DataGenerator.CSharp;
using Core.Types;
using CinqAnneaux.JdrCore.Attributs;

namespace TestsConsole {
	class Program {
		public static void Main( string[] args ) {
			GenerationTest.Test();

			//RaceModel rm = new RaceModel();
			//rm.Id = 2;

			//ObjectModel om = new ObjectModel();
			//om.Id = 2;

			//ArmeModel am = new ArmeModel();
			//am.Id = 2;

			//object oo = am;

			//Console.WriteLine(am == om);
			//Console.WriteLine(oo == om);
			//Console.WriteLine(om == oo);

			//Console.WriteLine(am.Equals(om));
			//Console.WriteLine(oo.Equals(om));
			//Console.WriteLine(om.Equals(oo));

			//TimePeriod d = new TimePeriod(1, TimeUnity.day);
			//TimePeriod e = new TimePeriod(24, TimeUnity.hour);
			//Console.WriteLine(d == e);
			//Console.WriteLine(d > e);
			//Console.WriteLine(d.CompareTo(e));
			//Console.WriteLine(d.Equals(e));
			//e = d;
			//Console.WriteLine(d == e);
			//Console.WriteLine(d > e);
			//Console.WriteLine(d.CompareTo(e));
			//Console.WriteLine(d.Equals(e));

			Console.ReadLine();

		}
	}
}
