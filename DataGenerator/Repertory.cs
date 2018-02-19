using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator {
	public class Repertory {
		#region members
		private Repertory _parent;
		private List<Repertory> _repertories = new List<Repertory>();
		private List<File> _files = new List<File>();
		#endregion

		#region Properties
		/// <summary>
		/// The vanilla name of the repertory
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// The full pathname, finishing with  '\\'.
		/// </summary>
		public string Path {
			get {
				if(_parent == null)
					return Name + "\\";
				else {
					return Parent.Path + Name + "\\";
				}
			}
		}
		public Repertory Parent {
			get { return _parent; }
			set {
				if(_parent == value) { return; }
				if(_parent != null)
					_parent.RemoveRepertory(this);
				_parent = value;
				_parent.AddRepertory(this);
			}
		}
		#endregion

		#region RepertoryCollection
		public void AddRepertory( Repertory repertory ) {
			_repertories.Add(repertory);
			repertory.Parent = this;
		}

		public bool RemoveRepertory( Repertory repertory ) {
			repertory.Parent = null;
			return _repertories.Remove(repertory);
		}
		public IEnumerable<Repertory> Repertories {
			get { return _repertories; }
		}
		#endregion

		#region File Collection
		public void AddFile( File file ) {
			_files.Add(file);
			file.Parent = this;
		}

		public bool RemoveFile( File file ) {
			file.Parent = null;
			return _files.Remove(file);
		}
		public IEnumerable<File> Files {
			get { return _files; }
		}
		#endregion

		public void GenerateRepertory() {
			string path = Path;
			Directory.CreateDirectory(path);
			foreach(File f in Files) {
				f.CreateFile(path);
			}
			foreach(Repertory rep in Repertories) {
				rep.GenerateRepertory();
			}
		}
	}
}
