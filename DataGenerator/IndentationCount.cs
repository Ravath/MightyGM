namespace DataGenerator
{
	/// <summary>
	/// Facility used to remember how many indentations are used at the current point of a writer process.
	/// </summary>
	public class IndentationCount {
		/// <summary>
		/// The current number of indentations.
		/// </summary>
		public int Count { get; set; }

		/// <summary>
		/// Returns a string with the right number of indentations.
		/// </summary>
		/// <returns></returns>
		public override string ToString() {
			string ind = "";
			for(int i = 0; i < Count; i++) {
				ind += "\t";
			}
			return ind;
		}
	}
}
