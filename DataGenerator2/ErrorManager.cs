using System;

namespace DataGenerator2 {
	public static class ErrorManager {
		public static void Error( string message ) {
			Console.Error.WriteLine(message);
		}
	}
}
