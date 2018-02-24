using System.Collections.Generic;
using System.Text;

namespace DataGenerator.CSharp
{
	/// <summary>
	/// Un namespace contenant une collection de classes et d'énumérations.
	/// </summary>
	public class CSNamespace {
		#region members
		private string _name;
		private List<CSClass> _classes = new List<CSClass>();
		private List<CSEnum> _enums = new List<CSEnum>();
		private string _repo;
		#endregion
		
		#region Properties
		public string Name {
			get { return _name; }
			set { _name = value; }
		}
		public string Repository {
			get { return _repo; }
			set {
				if(!value.EndsWith("/"))
					_repo = value + "/";
				else
					_repo = value;
			}
		}
		#endregion

		#region Collections Classes
		public bool RemoveClass( CSClass csClass ) {
			return _classes.Remove(csClass);
		}

		public void AddClass( CSClass table ) {
			if(!_classes.Contains(table)) {
				_classes.Add(table);
				table.Namespace = this;
			}
		}
		public IEnumerable<CSClass> Classes {
			get { return _classes; }
		}
		#endregion

		#region Collection Enums
		public void AddEnum( CSEnum csEnum ) {
			_enums.Add(csEnum);
		}
		public IEnumerable<CSEnum> Enumerations {
			get { return _enums; }
		}
		#endregion
		
		/// <summary>
		/// Ecrit toutes les classes et enumerations du namespace dans le StringBuilder.
		/// </summary>
		/// <param name="sb"></param>
		public void GenerateNamespace( StringBuilder sb ) {
			sb.AppendLine("namespace " + Name + " {");
			//les classes
			IndentationCount ind = new IndentationCount();
			foreach(CSClass cl in Classes) {
				cl.CreateString(sb, ind);
			}
			//les enums
			foreach(var en in Enumerations) {
				en.CreateString(sb, ind);
			}
			sb.AppendLine("}");

		}
		/// <summary>
		/// Ecrit les classes dans le StringBuilder en les encadrant avec le namespace spécifié.
		/// </summary>
		/// <param name="sb"></param>
		/// <param name="classes"></param>
		public void GenerateClassesInNamespace( StringBuilder sb, IEnumerable<CSEntity> classes ) {
			sb.AppendLine("namespace " + Name + " {");
			//générer un fichier par classe
			IndentationCount ind = new IndentationCount { Count = 1 };
			foreach(CSEntity cl in classes) {
				cl.CreateString(sb, ind);
				sb.AppendLine();
			}
			sb.AppendLine("}");
		}
	}

}
