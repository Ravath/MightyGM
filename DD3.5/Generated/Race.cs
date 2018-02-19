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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "racemodel")]
	[CoreData]
	public partial class RaceModel : DataModel {

		private RaceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RaceDescription> id = GetModelReferencer<RaceDescription>();
					if(id.Count() == 0) {
						_obj = new RaceDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _dexterite;
		[Column(Storage = "Dexterite",Name = "dexterite")]
		public int Dexterite{
			get{ return _dexterite;}
			set{_dexterite = value;}
		}

		private int _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _sagesse;
		[Column(Storage = "Sagesse",Name = "sagesse")]
		public int Sagesse{
			get{ return _sagesse;}
			set{_sagesse = value;}
		}

		private int _charisme;
		[Column(Storage = "Charisme",Name = "charisme")]
		public int Charisme{
			get{ return _charisme;}
			set{_charisme = value;}
		}

		private int _vD;
		[Column(Storage = "VD",Name = "vd")]
		public int VD{
			get{ return _vD;}
			set{_vD = value;}
		}

		private int _classePredilectionId;
		[Column(Storage = "ClassePredilectionId",Name = "fk_classemodel_classepredilection")]
		[HiddenProperty]
		public int ClassePredilectionId{
			get{ return _classePredilectionId;}
			set{_classePredilectionId = value;}
		}

		private ClasseModel _classePredilection;
		public ClasseModel ClassePredilection{
			get{
				if( _classePredilection == null)
					_classePredilection = LoadById<ClasseModel>(ClassePredilectionId);
				return _classePredilection;
			} set {
				if(_classePredilection == value){return;}
				_classePredilection = value;
				if( value != null)
					ClassePredilectionId = value.Id;
			}
		}

		private IEnumerable<LangueModel> _langueBase;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "LangueBase",OtherKey = "RaceModelId")]
		public IEnumerable <LangueModel> LangueBase{
			get{
				if( _langueBase == null ){
					_langueBase = LoadFromJointure<LangueModel,RaceModelToLangueModel_LangueBase>(false);
				}
				return _langueBase;
			}
			set{
				SaveToJointure<LangueModel, RaceModelToLangueModel_LangueBase> (_langueBase, value,false);
				_langueBase = value;
			}
		}

		private IEnumerable<LangueModel> _langueSupplmentaire;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "LangueSupplmentaire",OtherKey = "RaceModelId")]
		public IEnumerable <LangueModel> LangueSupplmentaire{
			get{
				if( _langueSupplmentaire == null ){
					_langueSupplmentaire = LoadFromJointure<LangueModel,RaceModelToLangueModel_LangueSupplmentaire>(false);
				}
				return _langueSupplmentaire;
			}
			set{
				SaveToJointure<LangueModel, RaceModelToLangueModel_LangueSupplmentaire> (_langueSupplmentaire, value,false);
				_langueSupplmentaire = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<RaceModel,RaceModelToLangueModel_LangueBase>(true);
			DeleteJoins<RaceModel,RaceModelToLangueModel_LangueSupplmentaire>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "racedescription")]
	public partial class RaceDescription : DataDescription<RaceModel> {

		private string _personnalite = "";
		[LargeText]
		[Column(Storage = "Personnalite",Name = "personnalite")]
		public string Personnalite{
			get{ return _personnalite;}
			set{_personnalite = value;}
		}

		private string _relations = "";
		[LargeText]
		[Column(Storage = "Relations",Name = "relations")]
		public string Relations{
			get{ return _relations;}
			set{_relations = value;}
		}

		private string _alignement = "";
		[LargeText]
		[Column(Storage = "Alignement",Name = "alignement")]
		public string Alignement{
			get{ return _alignement;}
			set{_alignement = value;}
		}

		private string _territoires = "";
		[LargeText]
		[Column(Storage = "Territoires",Name = "territoires")]
		public string Territoires{
			get{ return _territoires;}
			set{_territoires = value;}
		}

		private string _religion = "";
		[LargeText]
		[Column(Storage = "Religion",Name = "religion")]
		public string Religion{
			get{ return _religion;}
			set{_religion = value;}
		}

		private string _langue = "";
		[LargeText]
		[Column(Storage = "Langue",Name = "langue")]
		public string Langue{
			get{ return _langue;}
			set{_langue = value;}
		}

		private string _noms = "";
		[LargeText]
		[Column(Storage = "Noms",Name = "noms")]
		public string Noms{
			get{ return _noms;}
			set{_noms = value;}
		}

		private string _aventuriers = "";
		[LargeText]
		[Column(Storage = "Aventuriers",Name = "aventuriers")]
		public string Aventuriers{
			get{ return _aventuriers;}
			set{_aventuriers = value;}
		}
	}
	[Table(Schema = "dd35",Name = "raceexemplar")]
	public partial class RaceExemplar : DataExemplaire<RaceModel> {
	}
}
