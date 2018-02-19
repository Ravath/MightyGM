using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator.Parser;

namespace DataGenerator.DataModel {
	public abstract class AbsTable : DataConstructor {

		#region Members
		private List<AbsAttribute> _attributes = new List<AbsAttribute>();
		private AbsTable _parent;
		private AbsTable _fils;
		private string _name;
		/// <summary>
		/// List of forbidden names for both table and attributes, in lower case.
		/// </summary>
		static string[] ForbiddenNames = { "all","and","or", "create", "table", "not" };//et tant d'autres
		/// <summary>
		/// List of forbidden table names, in lower case.
		/// </summary>
		static string[] ForbiddenTableNames = {  };
		/// <summary>
		/// List of forbidden attribute names, in lower case.
		/// </summary>
		static string[] ForbiddenAttributeNames = {  };
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
			bool errors = false;
			// check forbidden table names
			foreach(string forbidenStr in ForbiddenTableNames.Concat(ForbiddenNames)) {
				if(Name.ToLower() == forbidenStr) {
					errors = true;
                    ErrorManager.Error(Name + ": This name is forbiden.");
				}
			}
			//check forbidden attribute names
			foreach(string forbidenStr in ForbiddenAttributeNames.Concat(ForbiddenNames)) {
				foreach(string attStr in _attributes.Select(p => p.Name)) {
					if(attStr.ToLower() == forbidenStr) {
						errors = true;
						ErrorManager.Error(Name + ": The attribute name '" + attStr + "' is forbiden.");
					}
				}
			}
			//Aucun doublon parmis les attributs
			return !TrouverDoublons(_attributes.Select(p => p.Name)) && !errors;
        }

		protected void AddAttribute( AbsAttribute att ) {
			_attributes.Add(att);
		}
	}
}
