namespace DataGenerator {

	public class IndentationCount {
		public int Count { get; set; }
		public override string ToString() {
			string ind = "";
			for(int i = 0; i < Count; i++) {
				ind += "\t";
			}
			return ind;
		}
	}
}
