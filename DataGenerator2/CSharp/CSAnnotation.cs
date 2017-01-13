using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataGenerator2.CSharp {

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

	public class CSTableAnnotation : CSAnnotation {
		public CSTableAnnotation( string schema, string name ) : base("Table") {
			AddArgument("Schema", schema);
			AddArgument("Name", name);
		}
	}

	public class CSColumnAnnotation : CSAnnotation {
		public CSColumnAnnotation( string storage, string name ) : base("Column") {
			AddArgument("Storage", storage);
			AddArgument("Name", name);
		}
	}

	public class CSAssociationAnnotation : CSAnnotation {
		public CSAssociationAnnotation( string storage, string otherkey ) : base("Association") {
			AddArgument("ThisKey", "Id");
			AddArgument("CanBeNull", true);
			AddArgument("Storage", storage);
			AddArgument("OtherKey", otherkey);
		}
		public CSAssociationAnnotation( string thisKey, string storage, string otherkey, bool canBeNull ) : base("Association") {
			AddArgument("ThisKey", thisKey);
			AddArgument("CanBeNull", canBeNull);
			AddArgument("Storage", storage);
			AddArgument("OtherKey", otherkey);
		}
	}
	/// <summary>
	/// A Collection of CSAnnotations.
	/// </summary>
	public class CSAnnotationCollection {
		#region Members
		private List<CSAnnotation> _annotations = new List<CSAnnotation>();
		#endregion
		#region Collection Annotations
		public IEnumerable<CSAnnotation> Annotations {
			get {
				return _annotations;
			}
		}
		public void AddAnnotation( CSAnnotation anno ) {
			_annotations.Add(anno);
		}
		public void AddAnnotation( string annoName ) {
			_annotations.Add(new CSAnnotation() { Name = annoName });
		}

		public bool RemoveAnnotation( CSAnnotation anno ) {
			return _annotations.Remove(anno);
		}
		#endregion

		public void CreateString( StringBuilder sb, IndentationCount indentation ) {
			foreach(CSAnnotation annot in Annotations) {
				annot.CreateString(sb, indentation);
				sb.AppendLine();
			}
		}

	}

}
