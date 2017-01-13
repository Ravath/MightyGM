using System;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator2.DataModel {
	public abstract class DataConstructor {
		/// <summary>
		/// Set the first letter to uppercase.
		/// </summary>
		/// <param name="s"></param>
		/// <returns></returns>
		public static string Pascalise( string s ) {
			return char.ToUpper(s.ElementAt(0)) + s.Substring(1);
		}
		/// <summary>
		/// Si trouve un doublon parmis les strings, envoie un message d'erreur.
		/// </summary>
		/// <param name="en"></param>
		/// <returns></returns>
		public static bool TrouverDoublons( IEnumerable<string> en ) {
			bool doublon = false;
			for(int i = 0; i < en.Count(); i++) {
				for(int j = i + 1; j < en.Count(); j++) {
					if(en.ElementAt(i) == en.ElementAt(j)) {
						Console.Error.WriteLine("the string " + en.ElementAt(i) + " has been found twice at positions:" + i + "," + j);
						doublon = true;
					}
				}
			}
			return doublon;
		}

		public abstract bool CheckIntegrity();

		public abstract void ToConsole();
	}
}
