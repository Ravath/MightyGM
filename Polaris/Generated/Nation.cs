using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Polaris.Data {
	[Table(Schema = "polaris",Name = "nation")]
	[CoreData]
	public partial class Nation : DataObject {

		private string _geographie = "";
		[LargeText]
		[Column(Storage = "Geographie",Name = "geographie")]
		public string Geographie{
			get{ return _geographie;}
			set{_geographie = value;}
		}

		private string _historique = "";
		[LargeText]
		[Column(Storage = "Historique",Name = "historique")]
		public string Historique{
			get{ return _historique;}
			set{_historique = value;}
		}

		private string _societe = "";
		[LargeText]
		[Column(Storage = "Societe",Name = "societe")]
		public string Societe{
			get{ return _societe;}
			set{_societe = value;}
		}

		private string _territoire = "";
		[LargeText]
		[Column(Storage = "Territoire",Name = "territoire")]
		public string Territoire{
			get{ return _territoire;}
			set{_territoire = value;}
		}

		private string _armes = "";
		[LargeText]
		[Column(Storage = "Armes",Name = "armes")]
		public string Armes{
			get{ return _armes;}
			set{_armes = value;}
		}

		private IEnumerable<Personnalite> _personnalites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Personnalites",OtherKey = "NationId")]
		public IEnumerable <Personnalite> Personnalites{
			get{
				if( _personnalites == null ){
					_personnalites = LoadFromJointure<Personnalite,NationToPersonnalite_Personnalites>(false);
				}
				return _personnalites;
			}
			set{
				SaveToJointure<Personnalite, NationToPersonnalite_Personnalites> (_personnalites, value,false);
				_personnalites = value;
			}
		}

		private IEnumerable<Ville> _villes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Villes",OtherKey = "NationId")]
		public IEnumerable <Ville> Villes{
			get{
				if( _villes == null ){
					_villes = LoadFromJointure<Ville,NationToVille_Villes>(false);
				}
				return _villes;
			}
			set{
				SaveToJointure<Ville, NationToVille_Villes> (_villes, value,false);
				_villes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Nation,NationToPersonnalite_Personnalites>(true);
			DeleteJoins<Nation,NationToVille_Villes>(true);
			base.DeleteObject();
		}
	}
}
