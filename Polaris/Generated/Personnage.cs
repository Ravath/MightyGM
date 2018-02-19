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

		private IEnumerable<OriginesExemplar> _origines;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Origines",OtherKey = "PersonnageModelId")]
		public IEnumerable <OriginesExemplar> Origines{
			get{
				if( _origines == null ){
					_origines = LoadFromJointure<OriginesExemplar,PersonnageModelToOriginesExemplar_Origines>(false);
				}
				return _origines;
			}
			set{
				SaveToJointure<OriginesExemplar, PersonnageModelToOriginesExemplar_Origines> (_origines, value,false);
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
			DeleteJoins<PersonnageModel,PersonnageModelToOriginesExemplar_Origines>(true);
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
	}
}
