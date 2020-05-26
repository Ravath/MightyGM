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
	[Table(Schema = "polaris",Name = "personnagemodel")]
	[CoreData]
	public partial class PersonnageModel : DataModel {

		private PersonnageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PersonnageDescription> id = GetModelReferencer<PersonnageDescription>();
					if(id.Count() == 0) {
						_obj = new PersonnageDescription();
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

		private int _constitution;
		[Column(Storage = "Constitution",Name = "constitution")]
		public int Constitution{
			get{ return _constitution;}
			set{_constitution = value;}
		}

		private int _coordination;
		[Column(Storage = "Coordination",Name = "coordination")]
		public int Coordination{
			get{ return _coordination;}
			set{_coordination = value;}
		}

		private int _adaptation;
		[Column(Storage = "Adaptation",Name = "adaptation")]
		public int Adaptation{
			get{ return _adaptation;}
			set{_adaptation = value;}
		}

		private int _perception;
		[Column(Storage = "Perception",Name = "perception")]
		public int Perception{
			get{ return _perception;}
			set{_perception = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public int Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}

		private int _presence;
		[Column(Storage = "Presence",Name = "presence")]
		public int Presence{
			get{ return _presence;}
			set{_presence = value;}
		}

		private int _chance;
		[Column(Storage = "Chance",Name = "chance")]
		public int Chance{
			get{ return _chance;}
			set{_chance = value;}
		}

		private bool _effetPolaris;
		[Column(Storage = "EffetPolaris",Name = "effetpolaris")]
		public bool EffetPolaris{
			get{ return _effetPolaris;}
			set{_effetPolaris = value;}
		}

		private bool _fecond;
		[Column(Storage = "Fecond",Name = "fecond")]
		public bool Fecond{
			get{ return _fecond;}
			set{_fecond = value;}
		}

		private MainDirectrice _mainDirectrice;
		[Column(Storage = "MainDirectrice",Name = "maindirectrice")]
		public MainDirectrice MainDirectrice{
			get{ return _mainDirectrice;}
			set{_mainDirectrice = value;}
		}

		private int _archetypeId;
		[Column(Storage = "ArchetypeId",Name = "fk_archetypemodel_archetype")]
		[HiddenProperty]
		public int ArchetypeId{
			get{ return _archetypeId;}
			set{_archetypeId = value;}
		}

		private ArchetypeModel _archetype;
		public ArchetypeModel Archetype{
			get{
				if( _archetype == null)
					_archetype = LoadById<ArchetypeModel>(ArchetypeId);
				return _archetype;
			} set {
				if(_archetype == value){return;}
				_archetype = value;
				if( value != null)
					ArchetypeId = value.Id;
			}
		}

		private int _typeGenetiqueId;
		[Column(Storage = "TypeGenetiqueId",Name = "fk_typegenetiqueexemplar_typegenetique")]
		[HiddenProperty]
		public int TypeGenetiqueId{
			get{ return _typeGenetiqueId;}
			set{_typeGenetiqueId = value;}
		}

		private TypeGenetiqueExemplar _typeGenetique;
		public TypeGenetiqueExemplar TypeGenetique{
			get{
				if( _typeGenetique == null)
					_typeGenetique = LoadById<TypeGenetiqueExemplar>(TypeGenetiqueId);
				return _typeGenetique;
			} set {
				if(_typeGenetique == value){return;}
				_typeGenetique = value;
				if( value != null)
					TypeGenetiqueId = value.Id;
			}
		}

		private IEnumerable<MutationExemplar> _mutations;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Mutations",OtherKey = "PersonnageModelId")]
		public IEnumerable <MutationExemplar> Mutations{
			get{
				if( _mutations == null ){
					_mutations = LoadFromJointure<MutationExemplar,PersonnageModelToMutationExemplar_Mutations>(false);
				}
				return _mutations;
			}
			set{
				SaveToJointure<MutationExemplar, PersonnageModelToMutationExemplar_Mutations> (_mutations, value,false);
				_mutations = value;
			}
		}

		private IEnumerable<OrigineExemplar> _origines;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Origines",OtherKey = "PersonnageModelId")]
		public IEnumerable <OrigineExemplar> Origines{
			get{
				if( _origines == null ){
					_origines = LoadFromJointure<OrigineExemplar,PersonnageModelToOrigineExemplar_Origines>(false);
				}
				return _origines;
			}
			set{
				SaveToJointure<OrigineExemplar, PersonnageModelToOrigineExemplar_Origines> (_origines, value,false);
				_origines = value;
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "PersonnageModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,PersonnageModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, PersonnageModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<ProfessionExemplar> _professions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Professions",OtherKey = "PersonnageModelId")]
		public IEnumerable <ProfessionExemplar> Professions{
			get{
				if( _professions == null ){
					_professions = LoadFromJointure<ProfessionExemplar,PersonnageModelToProfessionExemplar_Professions>(false);
				}
				return _professions;
			}
			set{
				SaveToJointure<ProfessionExemplar, PersonnageModelToProfessionExemplar_Professions> (_professions, value,false);
				_professions = value;
			}
		}

		private IEnumerable<AvantageExemplar> _avantages;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Avantages",OtherKey = "PersonnageModelId")]
		public IEnumerable <AvantageExemplar> Avantages{
			get{
				if( _avantages == null ){
					_avantages = LoadFromJointure<AvantageExemplar,PersonnageModelToAvantageExemplar_Avantages>(false);
				}
				return _avantages;
			}
			set{
				SaveToJointure<AvantageExemplar, PersonnageModelToAvantageExemplar_Avantages> (_avantages, value,false);
				_avantages = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageModel,PersonnageModelToMutationExemplar_Mutations>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToOrigineExemplar_Origines>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToCompetenceExemplar_Competences>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToProfessionExemplar_Professions>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToAvantageExemplar_Avantages>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "personnagedescription")]
	public partial class PersonnageDescription : DataDescription<PersonnageModel> {
	}
	[Table(Schema = "polaris",Name = "personnageexemplar")]
	public partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private int _teteId;
		[Column(Storage = "TeteId",Name = "fk_blessures_tete")]
		[HiddenProperty]
		public int TeteId{
			get{ return _teteId;}
			set{_teteId = value;}
		}

		private Blessures _tete;
		public Blessures Tete{
			get{
				if( _tete == null)
					_tete = LoadById<Blessures>(TeteId);
				return _tete;
			} set {
				if(_tete == value){return;}
				_tete = value;
				if( value != null)
					TeteId = value.Id;
			}
		}

		private int _corpsId;
		[Column(Storage = "CorpsId",Name = "fk_blessures_corps")]
		[HiddenProperty]
		public int CorpsId{
			get{ return _corpsId;}
			set{_corpsId = value;}
		}

		private Blessures _corps;
		public Blessures Corps{
			get{
				if( _corps == null)
					_corps = LoadById<Blessures>(CorpsId);
				return _corps;
			} set {
				if(_corps == value){return;}
				_corps = value;
				if( value != null)
					CorpsId = value.Id;
			}
		}

		private int _brasDId;
		[Column(Storage = "BrasDId",Name = "fk_blessures_brasd")]
		[HiddenProperty]
		public int BrasDId{
			get{ return _brasDId;}
			set{_brasDId = value;}
		}

		private Blessures _brasD;
		public Blessures BrasD{
			get{
				if( _brasD == null)
					_brasD = LoadById<Blessures>(BrasDId);
				return _brasD;
			} set {
				if(_brasD == value){return;}
				_brasD = value;
				if( value != null)
					BrasDId = value.Id;
			}
		}

		private int _brasGId;
		[Column(Storage = "BrasGId",Name = "fk_blessures_brasg")]
		[HiddenProperty]
		public int BrasGId{
			get{ return _brasGId;}
			set{_brasGId = value;}
		}

		private Blessures _brasG;
		public Blessures BrasG{
			get{
				if( _brasG == null)
					_brasG = LoadById<Blessures>(BrasGId);
				return _brasG;
			} set {
				if(_brasG == value){return;}
				_brasG = value;
				if( value != null)
					BrasGId = value.Id;
			}
		}

		private int _jambeDId;
		[Column(Storage = "JambeDId",Name = "fk_blessures_jambed")]
		[HiddenProperty]
		public int JambeDId{
			get{ return _jambeDId;}
			set{_jambeDId = value;}
		}

		private Blessures _jambeD;
		public Blessures JambeD{
			get{
				if( _jambeD == null)
					_jambeD = LoadById<Blessures>(JambeDId);
				return _jambeD;
			} set {
				if(_jambeD == value){return;}
				_jambeD = value;
				if( value != null)
					JambeDId = value.Id;
			}
		}

		private int _jambeGId;
		[Column(Storage = "JambeGId",Name = "fk_blessures_jambeg")]
		[HiddenProperty]
		public int JambeGId{
			get{ return _jambeGId;}
			set{_jambeGId = value;}
		}

		private Blessures _jambeG;
		public Blessures JambeG{
			get{
				if( _jambeG == null)
					_jambeG = LoadById<Blessures>(JambeGId);
				return _jambeG;
			} set {
				if(_jambeG == value){return;}
				_jambeG = value;
				if( value != null)
					JambeGId = value.Id;
			}
		}
	}
}
