using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator2.CSharp;
using DataGenerator2.SQL;
using DataGenerator2.Parser;

namespace DataGenerator2.DataModel {
	public class StructTable : AbsTable {
		#region Members
		private bool _odd;
		private bool _abstract;
		private string _heritage;
		private bool _pj;
		#endregion

		#region Properties
		public bool IsAbstract { get { return _abstract; } }
		public bool IsOddTable { get { return _odd; } }
		public bool PJTag { get { return _pj; } }
		public string ModelClassName { get { return Name + "Model"; } }
		public string ExemplarClassName { get { return Name + "Exemplar"; } }
		public string DescriptionClassName { get { return Name + "Description"; } }
		#endregion

		#region Init
		public StructTable( RawTable rwt ) : base(rwt) {
			_heritage = rwt.MajorTag;
			CheckTags(rwt.MinorTags);
		}
		public override AbsAttribute CreateAttribute( RawAttribute attribute ) {
			return new ValueAttribute(attribute);
		}
		#endregion

		protected void CheckTags( IEnumerable<string> tags ) {
			foreach(string tag in tags) {
				switch(tag.ToLower()) {
					case "odd":
					_odd = true;
                    break;
					case "abstract":
					_abstract = true;
					break;
					case "pj":
					if(this is DataTable) {
						_pj = true;
					} else
						ErrorManager.Error("les tags 'PJ' sont réservés aux datatable");
					break;
					default:
					ErrorManager.Error(Name + ": tag inconnu:" + tag);
					break;
				}
			}
		}

		public override bool CheckIntegrity() {
			foreach(AbsAttribute att in Attributes) {
				//tous les attributs d'un struct doivent être des ValueAttribute
				if(!(att is ValueAttribute)) {
					ErrorManager.Error("The attribute " + att.Name + " from strutTable " + Name + " is not an ValueAttribute.");
				} else {
					ValueAttribute vatt = (ValueAttribute)att;
					//Ils doivent tous avoir un type
					if(vatt.Type == null) {
						ErrorManager.Error("The attribute " + att.Name + " from strutTable " + Name + " Don't have a type.");
					}else if (vatt.Type is ReferenceType) {
						//les références doivent pointer
						ReferenceType rt = (ReferenceType)vatt.Type;
						if(rt.ReferencedAttribute != null) {
							ReferenceType rtret = rt.ReferencedAttribute.Type as ReferenceType;
							if(rtret?.ReferencedTable != this) {
								ErrorManager.Error(string.Format(
									"The {0}({1})'scounterpart must link to {0}.", Name, att.Name));
							}
						}
                    }
				}
			}
			return base.CheckIntegrity();
		}
	}
}
