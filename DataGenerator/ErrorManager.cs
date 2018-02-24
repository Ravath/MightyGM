using System;

namespace DataGenerator
{
	/// <summary>
	/// The error log static manager.
	/// </summary>
	public static class ErrorManager {

		/// <summary>
		/// Counts the number of errors.
		/// </summary>
		private static int nbrErrors = 0;

		/// <summary>
		/// Displays the error message corresponding to the given reference.
		/// </summary>
		/// <param name="messageRef">Reference to the error message in the ressource file.</param>
		/// <param name="objs">Arguments to format in the message.</param>
		public static void ErrorRef(string messageRef, params object[] objs)
		{
			nbrErrors++;
			Console.Error.WriteLine(string.Format(DataGenMessages_Fr.ResourceManager.GetString(messageRef), objs));
		}

		/// <summary>
		/// Conclude the process by printing the number of errors.
		/// </summary>
		/// <returns>True if no error occured.</returns>
		public static bool Conclude()
		{
			if (nbrErrors==0)
			{
				Console.Out.WriteLine("Ended without error");
				return true;
			}
			else
			{
				Console.Out.WriteLine("Ended with "+nbrErrors+" error");
				return false;
			}
		}
	}
}
