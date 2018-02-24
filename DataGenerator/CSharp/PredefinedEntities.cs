using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.CSharp
{
	public class CSEnum : CSEntity
	{
		private List<string> _tags = new List<string>();

		public CSEnum(string name) : base(name) { }

		public void AddTag(string tag)
		{
			_tags.Add(tag);
		}

		public IEnumerable<string> Tags
		{
			get { return _tags; }
		}

		public override void CreateString(StringBuilder sb, IndentationCount indentation)
		{
			sb.AppendLine(indentation + "public enum " + Name + "{");
			if (_tags.Count() != 0)
				sb.Append(indentation + "\t" + _tags.ElementAt(0));
			for (int i = 1; i < _tags.Count(); i++)
				sb.Append(", " + _tags.ElementAt(i));
			sb.AppendLine("}");
		}

	}

	public class CSPartialClass : CSClass
	{
		public CSClass OtherClass { get; private set; }
		public CSPartialClass(CSClass cl) : base(cl.Name)
		{
			Partial = true;
			cl.Partial = true;
			OtherClass = cl;
		}
	}
}
