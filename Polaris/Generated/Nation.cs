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
	[Table(Schema = "polaris",Name = "nationmodel")]
	[CoreData]
	public partial class NationModel : DataModel {

		private NationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<NationDescription> id = GetModelReferencer<NationDescription>();
					if(id.Count() == 0) {
						_obj = new NationDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeNation _typeNation;
		[Column(Storage = "TypeNation",Name = "typenation")]
		public TypeNation TypeNation{
			get{ return _typeNation;}
			set{_typeNation = value;}
		}

		private IEnumerable<PersonnaliteModel> _personnalites;
		public IEnumerable <PersonnaliteModel> Personnalites{
			get{
				if( _personnalites == null ){
					_personnalites = LoadByForeignKey<PersonnaliteModel>(p => p.NationId, Id);
				}
				return _personnalites;
			}
			set{
				foreach( PersonnaliteModel item in _personnalites ){
					item.Nation = null;

				}
				_personnalites = value;
				foreach( PersonnaliteModel item in value ){
					item.Nation = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<VilleModel> _villes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Villes",OtherKey = "NationModelId")]
		public IEnumerable <VilleModel> Villes{
			get{
				if( _villes == null ){
					_villes = LoadFromJointure<VilleModel,NationModelToVilleModel_Villes>(false);
				}
				return _villes;
			}
			set{
				SaveToJointure<VilleModel, NationModelToVilleModel_Villes> (_villes, value,false);
				_villes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<NationModel,NationModelToVilleModel_Villes>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "nationdescription")]
	public partial class NationDescription : DataDescription<NationModel> {

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
	}
	[Table(Schema = "polaris",Name = "nationexemplar")]
	public partial class NationExemplar : DataExemplaire<NationModel> {
	}
}
