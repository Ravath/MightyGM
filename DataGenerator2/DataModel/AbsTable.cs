using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator2.Parser;

namespace DataGenerator2.DataModel {
	public abstract class AbsTable : DataConstructor {

		#region Members
		private List<AbsAttribute> _attributes = new List<AbsAttribute>();
		private AbsTable _parent;
		private AbsTable _fils;
		private string _name;
		#endregion

		#region Properties
		public string Name {
			get { return _name; }
			set { _name = Pascalise(value); }
		}
		public IEnumerable<AbsAttribute> Attributes { get { return _attributes; } }
		public IEnumerable<AbsAttribute> ParentAttributes { get { return _parent?.Attributes; } }
		public IEnumerable<AbsAttribute> AncestorsAttributes { get { return ParentAttributes.Union(_parent?.AncestorsAttributes); } }
		public AbsTable Parent {
			get { return _parent; }
			set {
				_parent = value;
				if(value!=null)
					value._fils = this;
			}
		}
		public AbsTable Fils {
			get { return _fils; }
			set {
				_fils = value;
				if(value != null)
					value._parent = this;
			}
		}
		public int NombreParents {
			get {
				if(_parent == null)
					return 0;
				return _parent.NombreParents + 1;
			}
		}
		#endregion
		#region Init
		public AbsTable( RawTable rwt ) {
			Name = rwt.Name;
			foreach(RawAttribute att in rwt.Attributes) {
				_attributes.Add(CreateAttribute(att));
			}
		}
		public abstract AbsAttribute CreateAttribute( RawAttribute attribute );
		#endregion


		public override void ToConsole() {
			Console.WriteLine(GetType().Name + "_ " + Name + " (");
			foreach(AbsAttribute att in _attributes) {
				att.ToConsole();
			}
			Console.WriteLine(")\n");
		}

		public override bool CheckIntegrity() {
			//Aucun doublon parmis les attributs
			return !TrouverDoublons(_attributes.Select(p => p.Name));
        }
	}
}
