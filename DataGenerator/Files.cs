using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataGenerator.SQL;
using DataGenerator.CSharp;

namespace DataGenerator {
	/// <summary>
	/// A file with specific content to be writen.
	/// </summary>
	public abstract class File {
		#region Members
		private string _extension;
		private string _name;
		private Repertory _parent;
		#endregion

		#region Properties
		public string Name { get { return _name; } }
		public string Extension { get { return _extension; } }
		public Repertory Parent {
			get { return _parent; }
			set {
				if(_parent == value) { return; }
				if(_parent != null)
					_parent.RemoveFile(this);
				_parent = value;
				_parent.AddFile(this);
			}
		}
		#endregion

		#region Init
		public File(string name, string extension) {
			_name = name;
			_extension = extension;
		}
		#endregion

		public void CreateFile( string repoName ) {
			if(!repoName.EndsWith("\\"))
				repoName+="\\";
			StringBuilder sb = new StringBuilder();
			WriteFile(sb);
			using(StreamWriter fs = new StreamWriter(System.IO.File.Create(repoName + Name + "."+ Extension))) {
				fs.Write(sb);
				sb.Clear();
			}

		}
		/// <summary>
		/// Write the content of the file on the StringBuilder on a specific way.
		/// </summary>
		/// <param name="sb"></param>
		protected abstract void WriteFile( StringBuilder sb );
	}
	/// <summary>
	/// Write a CSFile with namespace, usings and classes.
	/// </summary>
	public class CsFile : File {
		#region Members
		private CSNamespace _namespace;
		private List<string> _usings = new List<string>();
		private List<CSEntity> _classes = new List<CSEntity>();
		#endregion

		#region Properties
		public CSNamespace Namespace {
			get { return _namespace; }
			set { _namespace = value; }
		}
		#endregion
		public CsFile( string name ) :this(name, null) {

		}
		public CsFile(string name, CSNamespace csNamespace) : base(name, "cs"){
			_namespace = csNamespace;
		}

		#region Collection Usings
		public void AddUsing( string usingName ) {
			_usings.Add(usingName);
		}
		public IEnumerable<string> Usings {
			get { return _usings; }
		}
		#endregion

		#region Collection Classes
		public void AddClasse( CSEntity clas ) {
			_classes.Add(clas);
		}
		public IEnumerable<CSEntity> Classes {
			get { return _classes; }
		}
		#endregion

		protected override void WriteFile( StringBuilder sb ) {
			foreach(string usi in Usings) {
				sb.AppendFormat("using {0};", usi);
				sb.AppendLine();
			}
			Namespace.GenerateClassesInNamespace(sb, Classes);
		}
	}
	/// <summary>
	/// Write a SQL File. Mainly tables declaration.
	/// </summary>
	public class SqlFile : File {
		#region Members
		private SQLSchema _database;
		#endregion
		#region Properties
		public SQLSchema Database { get { return _database; } } 
		#endregion
		public SqlFile( string name , SQLSchema database ) : base(name, "sql"){
			_database = database;
		}

		protected override void WriteFile( StringBuilder sb ) {
			sb.AppendLine("CREATE SCHEMA " + _database.Name+";");
			foreach(SQLTable table in _database.Tables.OrderBy(t=>t.ParentNumber)) {
				table.WriteTable(sb);
				sb.AppendLine();
            }
		}
	}
}
