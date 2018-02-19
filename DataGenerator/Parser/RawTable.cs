using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.Parser {
	/// <summary>
	/// The data parsed from the description.
	/// A DatabaseName and raw tables descrption.
	/// </summary>
	public class RawData {
		public string DatabaseName;
		public List<RawTable> RawTables = new List<RawTable>();
	}
	/// <summary>
	/// The raw description of a table to create.
	/// </summary>
	public class RawTable {
		public string Type;
		public string Name;
		public string MajorTag;
		public List<string> MinorTags = new List<string>();
		public List<RawAttribute> Attributes = new List<RawAttribute>();
	}
	/// <summary>
	/// The raw description of the attribute of a table to create.
	/// </summary>
	public class RawAttribute {
		public string Section;
		public string Type;
		public string TypeTag;
		public string Name;
		public string CardMin;
		public string CardMax;
		public string Target;
	}
}
