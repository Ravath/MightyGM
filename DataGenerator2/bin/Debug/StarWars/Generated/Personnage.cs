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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "personnagemodel")]
	public abstract partial class PersonnageModel : DataModel {

		private int _vigueur;
		[Column(Storage = "Vigueur",Name = "vigueur")]
		public int Vigueur{
			get{ return _vigueur;}
			set{_vigueur = value;}
		}

		private int _agilite;
		[Column(Storage = "Agilite",Name = "agilite")]
		public int Agilite{
			get{ return _agilite;}
			set{_agilite = value;}
		}

		private int _intelligence;
		[Column(Storage = "Intelligence",Name = "intelligence")]
		public int Intelligence{
			get{ return _intelligence;}
			set{_intelligence = value;}
		}

		private int _ruse;
		[Column(Storage = "Ruse",Name = "ruse")]
		public int Ruse{
			get{ return _ruse;}
			set{_ruse = value;}
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

		private bool _maitriseLaForce;
		[Column(Storage = "MaitriseLaForce",Name = "maitriselaforce")]
		public bool MaitriseLaForce{
			get{ return _maitriseLaForce;}
			set{_maitriseLaForce = value;}
		}

		private IEnumerable<CapaciteModel> _capacites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Capacites",OtherKey = "PersonnageModelId")]
		public IEnumerable <CapaciteModel> Capacites{
			get{
				if( _capacites == null ){
					_capacites = LoadFromJointure<CapaciteModel,PersonnageModelToCapaciteModel>(false);
				}
				return _capacites;
			}
			set{
				SaveToJointure<CapaciteModel, PersonnageModelToCapaciteModel> (_capacites, value,false);
				_capacites = value;
			}
		}

		private IEnumerable<TalentExemplar> _talents;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Talents",OtherKey = "PersonnageModelId")]
		public IEnumerable <TalentExemplar> Talents{
			get{
				if( _talents == null ){
					_talents = LoadFromJointure<TalentExemplar,PersonnageModelToTalentExemplar>(false);
				}
				return _talents;
			}
			set{
				SaveToJointure<TalentExemplar, PersonnageModelToTalentExemplar> (_talents, value,false);
				_talents = value;
			}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "PersonnageModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,PersonnageModelToCompetenceExemplar>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, PersonnageModelToCompetenceExemplar> (_competences, value,false);
				_competences = value;
			}
		}

		private IEnumerable<ObjectExemplar> _inventaire;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Inventaire",OtherKey = "PersonnageModelId")]
		public IEnumerable <ObjectExemplar> Inventaire{
			get{
				if( _inventaire == null ){
					_inventaire = LoadFromJointure<ObjectExemplar,PersonnageModelToObjectExemplar>(false);
				}
				return _inventaire;
			}
			set{
				SaveToJointure<ObjectExemplar, PersonnageModelToObjectExemplar> (_inventaire, value,false);
				_inventaire = value;
			}
		}

		private IEnumerable<ArmeExemplar> _armesPortees;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ArmesPortees",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmeExemplar> ArmesPortees{
			get{
				if( _armesPortees == null ){
					_armesPortees = LoadFromJointure<ArmeExemplar,PersonnageModelToArmeExemplar>(false);
				}
				return _armesPortees;
			}
			set{
				SaveToJointure<ArmeExemplar, PersonnageModelToArmeExemplar> (_armesPortees, value,false);
				_armesPortees = value;
			}
		}

		private IEnumerable<ArmureExemplar> _armuresPortees;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "ArmuresPortees",OtherKey = "PersonnageModelId")]
		public IEnumerable <ArmureExemplar> ArmuresPortees{
			get{
				if( _armuresPortees == null ){
					_armuresPortees = LoadFromJointure<ArmureExemplar,PersonnageModelToArmureExemplar>(false);
				}
				return _armuresPortees;
			}
			set{
				SaveToJointure<ArmureExemplar, PersonnageModelToArmureExemplar> (_armuresPortees, value,false);
				_armuresPortees = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageModel,PersonnageModelToCapaciteModel>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToTalentExemplar>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToCompetenceExemplar>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToObjectExemplar>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmeExemplar>(true);
			DeleteJoins<PersonnageModel,PersonnageModelToArmureExemplar>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "starwars",Name = "personnagedescription")]
	public abstract partial class PersonnageDescription : DataDescription<PersonnageModel> {
	}
	[Table(Schema = "starwars",Name = "personnageexemplar")]
	public abstract partial class PersonnageExemplar : DataExemplaire<PersonnageModel> {

		private bool _isDead;
		[Column(Storage = "IsDead",Name = "isdead")]
		public bool IsDead{
			get{ return _isDead;}
			set{_isDead = value;}
		}

		private int _stressCourant;
		[Column(Storage = "StressCourant",Name = "stresscourant")]
		public int StressCourant{
			get{ return _stressCourant;}
			set{_stressCourant = value;}
		}

		private int _vieCourante;
		[Column(Storage = "VieCourante",Name = "viecourante")]
		public int VieCourante{
			get{ return _vieCourante;}
			set{_vieCourante = value;}
		}

		private IEnumerable<BlessureCritiqueModel> _blessures;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Blessures",OtherKey = "PersonnageExemplarId")]
		public IEnumerable <BlessureCritiqueModel> Blessures{
			get{
				if( _blessures == null ){
					_blessures = LoadFromJointure<BlessureCritiqueModel,PersonnageExemplarToBlessureCritiqueModel>(false);
				}
				return _blessures;
			}
			set{
				SaveToJointure<BlessureCritiqueModel, PersonnageExemplarToBlessureCritiqueModel> (_blessures, value,false);
				_blessures = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<PersonnageExemplar,PersonnageExemplarToBlessureCritiqueModel>(true);
			base.DeleteObject();
		}
	}
}
