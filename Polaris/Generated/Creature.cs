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
	[Table(Schema = "polaris",Name = "creaturemodel")]
	[CoreData]
	public partial class CreatureModel : DataModel {

		private CreatureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CreatureDescription> id = GetModelReferencer<CreatureDescription>();
					if(id.Count() == 0) {
						_obj = new CreatureDescription();
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

		private Echelle _echelle;
		[Column(Storage = "Echelle",Name = "echelle")]
		public Echelle Echelle{
			get{ return _echelle;}
			set{_echelle = value;}
		}

		private int? _force;
		[Column(Storage = "Force",Name = "force")]
		public int? Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int? _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int? Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}

		private int? _coordination;
		[Column(Storage = "Coordination",Name = "coordination")]
		public int? Coordination{
			get{ return _coordination;}
			set{_coordination = value;}
		}

		private int? _adaptation;
		[Column(Storage = "Adaptation",Name = "adaptation")]
		public int? Adaptation{
			get{ return _adaptation;}
			set{_adaptation = value;}
		}

		private int? _perception;
		[Column(Storage = "Perception",Name = "perception")]
		public int? Perception{
			get{ return _perception;}
			set{_perception = value;}
		}

		private int? _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int? Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int? _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public int? Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}

		private int? _presence;
		[Column(Storage = "Presence",Name = "presence")]
		public int? Presence{
			get{ return _presence;}
			set{_presence = value;}
		}

		private int _vitesse;
		[Column(Storage = "Vitesse",Name = "vitesse")]
		public int Vitesse{
			get{ return _vitesse;}
			set{_vitesse = value;}
		}

		private int _vIT;
		[Column(Storage = "VIT",Name = "vit")]
		public int VIT{
			get{ return _vIT;}
			set{_vIT = value;}
		}

		private int _poids;
		[Column(Storage = "Poids",Name = "poids")]
		public int Poids{
			get{ return _poids;}
			set{_poids = value;}
		}

		private int _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public int Taille{
			get{ return _taille;}
			set{_taille = value;}
		}

		private bool _marine;
		[Column(Storage = "Marine",Name = "marine")]
		public bool Marine{
			get{ return _marine;}
			set{_marine = value;}
		}

		private IEnumerable<LocalisationCreatureModel> _localisations;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Localisations",OtherKey = "CreatureModelId")]
		public IEnumerable <LocalisationCreatureModel> Localisations{
			get{
				if( _localisations == null ){
					_localisations = LoadFromJointure<LocalisationCreatureModel,CreatureModelToLocalisationCreatureModel_Localisations>(false);
				}
				return _localisations;
			}
			set{
				SaveToJointure<LocalisationCreatureModel, CreatureModelToLocalisationCreatureModel_Localisations> (_localisations, value,false);
				_localisations = value;
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "CreatureModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,CreatureModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, CreatureModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<AttaqueCreatureExemplar> _attaquesCreature;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "AttaquesCreature",OtherKey = "CreatureModelId")]
		public IEnumerable <AttaqueCreatureExemplar> AttaquesCreature{
			get{
				if( _attaquesCreature == null ){
					_attaquesCreature = LoadFromJointure<AttaqueCreatureExemplar,CreatureModelToAttaqueCreatureExemplar_AttaquesCreature>(false);
				}
				return _attaquesCreature;
			}
			set{
				SaveToJointure<AttaqueCreatureExemplar, CreatureModelToAttaqueCreatureExemplar_AttaquesCreature> (_attaquesCreature, value,false);
				_attaquesCreature = value;
			}
		}

		private IEnumerable<SpecialCreatureExemplar> _specialCreature;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SpecialCreature",OtherKey = "CreatureModelId")]
		public IEnumerable <SpecialCreatureExemplar> SpecialCreature{
			get{
				if( _specialCreature == null ){
					_specialCreature = LoadFromJointure<SpecialCreatureExemplar,CreatureModelToSpecialCreatureExemplar_SpecialCreature>(false);
				}
				return _specialCreature;
			}
			set{
				SaveToJointure<SpecialCreatureExemplar, CreatureModelToSpecialCreatureExemplar_SpecialCreature> (_specialCreature, value,false);
				_specialCreature = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<CreatureModel,CreatureModelToLocalisationCreatureModel_Localisations>(true);
			DeleteJoins<CreatureModel,CreatureModelToCompetenceExemplar_Competences>(true);
			DeleteJoins<CreatureModel,CreatureModelToAttaqueCreatureExemplar_AttaquesCreature>(true);
			DeleteJoins<CreatureModel,CreatureModelToSpecialCreatureExemplar_SpecialCreature>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "creaturedescription")]
	public partial class CreatureDescription : DataDescription<CreatureModel> {
	}
	[Table(Schema = "polaris",Name = "creatureexemplar")]
	public partial class CreatureExemplar : DataExemplaire<CreatureModel> {
	}
}
