using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator.CSharp
{
	/// <summary>
	/// A C# annotation.
	/// </summary>
	public class CSAnnotation {
		#region Members
		private Dictionary<string, object> _args = new Dictionary<string, object>();
		#endregion

		#region Properties
		public string Name { get; set; }
		#endregion

		#region Init
		public CSAnnotation() { }
		public CSAnnotation( string name ) {
			Name = name;
		}
		#endregion

		public void AddArgument( string name, object value ) {
			if(_args.ContainsKey(name))
				_args[name] = value;
			else {
				_args.Add(name, value);
			}
		}

		public void CreateString( StringBuilder sb, IndentationCount indentation ) {
			if(_args.Count() == 0)
				sb.AppendFormat(indentation + "[{0}]", Name);
			else {
				string list = string.Format("{0} = {1}", _args.ElementAt(0).Key, formater(_args.ElementAt(0).Value));
				for(int i = 1; i < _args.Count(); i++)
					list += string.Format(",{0} = {1}", _args.ElementAt(i).Key, formater(_args.ElementAt(i).Value));
				sb.AppendFormat(indentation + "[{0}({1})]", Name, list);
			}
		}
		private string formater( object obj ) {
			if(obj is string)
				return "\"" + obj + "\"";
			else if(obj is bool)
				return ((bool)obj) == true ? "true" : "false";
			else
				return obj.ToString();
		}
	}
}
