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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "racemodel")]
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
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
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

		private IEnumerable<LangueModel> _languesBase;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "LanguesBase",OtherKey = "RaceModelId")]
		public IEnumerable <LangueModel> LanguesBase{
			get{
				if( _languesBase == null ){
					_languesBase = LoadFromJointure<LangueModel,RaceModelToLangueModel_LanguesBase>(false);
				}
				return _languesBase;
			}
			set{
				SaveToJointure<LangueModel, RaceModelToLangueModel_LanguesBase> (_languesBase, value,false);
				_languesBase = value;
			}
		}

		private IEnumerable<LangueModel> _langueSupplementaire;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "LangueSupplementaire",OtherKey = "RaceModelId")]
		public IEnumerable <LangueModel> LangueSupplementaire{
			get{
				if( _langueSupplementaire == null ){
					_langueSupplementaire = LoadFromJointure<LangueModel,RaceModelToLangueModel_LangueSupplementaire>(false);
				}
				return _langueSupplementaire;
			}
			set{
				SaveToJointure<LangueModel, RaceModelToLangueModel_LangueSupplementaire> (_langueSupplementaire, value,false);
				_langueSupplementaire = value;
			}
		}

		private IEnumerable<PouvoirSpecialModel> _pouvoirs;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Pouvoirs",OtherKey = "RaceModelId")]
		public IEnumerable <PouvoirSpecialModel> Pouvoirs{
			get{
				if( _pouvoirs == null ){
					_pouvoirs = LoadFromJointure<PouvoirSpecialModel,RaceModelToPouvoirSpecialModel_Pouvoirs>(false);
				}
				return _pouvoirs;
			}
			set{
				SaveToJointure<PouvoirSpecialModel, RaceModelToPouvoirSpecialModel_Pouvoirs> (_pouvoirs, value,false);
				_pouvoirs = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<RaceModel,RaceModelToLangueModel_LanguesBase>(true);
			DeleteJoins<RaceModel,RaceModelToLangueModel_LangueSupplementaire>(true);
			DeleteJoins<RaceModel,RaceModelToPouvoirSpecialModel_Pouvoirs>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "racedescription")]
	public partial class RaceDescription : DataDescription<RaceModel> {

		private string _physique = "";
		[LargeText]
		[Column(Storage = "Physique",Name = "physique")]
		public string Physique{
			get{ return _physique;}
			set{_physique = value;}
		}

		private string _societe = "";
		[LargeText]
		[Column(Storage = "Societe",Name = "societe")]
		public string Societe{
			get{ return _societe;}
			set{_societe = value;}
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

		private string _aventuriers = "";
		[LargeText]
		[Column(Storage = "Aventuriers",Name = "aventuriers")]
		public string Aventuriers{
			get{ return _aventuriers;}
			set{_aventuriers = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "raceexemplar")]
	public partial class RaceExemplar : DataExemplaire<RaceModel> {
	}
}
