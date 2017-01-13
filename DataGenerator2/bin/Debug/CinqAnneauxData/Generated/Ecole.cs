using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace CinqAnneaux.Data {
	[CoreData]
	[Table(Schema = "cinqanneaux",Name = "ecole_model")]
	public partial class EcoleModel : DataModel {

		private TraitCompetence _BonusInitial;
		[Column(Storage = "BonusInitial",Name = "bonusinitial")]
		public TraitCompetence BonusInitial{
			get{ return _BonusInitial;}
			set{_BonusInitial = value;}
		}

		private IEnumerable<EcoleModelToCompetenceExemplar> _Competences;
		public IEnumerable<EcoleModelToCompetenceExemplar> Competences{
			get {
				if(_Competences == null) {
					_Competences = LoadByForeignKey<EcoleModelToCompetenceExemplar>(p => p.EcoleModelId, Id);
			    }
				return _Competences;
			}
			set {
				foreach(EcoleModelToCompetenceExemplar item in _Competences) {
					item.EcoleModel = null;
				}
				_Competences = value;
				foreach(EcoleModelToCompetenceExemplar item in value) {
					item.EcoleModel = this;
				}
			}
		}


		private decimal _honneur;
		[Column(Storage = "Honneur",Name = "honneur")]
		public decimal Honneur{
			get{ return _honneur;}
			set{_honneur = value;}
		}

		private IEnumerable<EcoleModelToAbsObjetModel> _Equipement;
		public IEnumerable<EcoleModelToAbsObjetModel> Equipement{
			get {
				if(_Equipement == null) {
					_Equipement = LoadByForeignKey<EcoleModelToAbsObjetModel>(p => p.EcoleModelId, Id);
			    }
				return _Equipement;
			}
			set {
				foreach(EcoleModelToAbsObjetModel item in _Equipement) {
					item.EcoleModel = null;
				}
				_Equipement = value;
				foreach(EcoleModelToAbsObjetModel item in value) {
					item.EcoleModel = this;
				}
			}
		}


		private decimal _argentInitial;
		[Column(Storage = "ArgentInitial",Name = "argentinitial")]
		public decimal ArgentInitial{
			get{ return _argentInitial;}
			set{_argentInitial = value;}
		}

		private IEnumerable<TechniqueModel> _Techniques;
		public IEnumerable<TechniqueModel> Techniques{
			get {
				if(_Techniques == null) {
					_Techniques = LoadByForeignKey<TechniqueModel>(p => p.EcoleId, Id);
			    }
				return _Techniques;
			}
			set {
				foreach(TechniqueModel item in _Techniques) {
					item.Ecole = null;
				}
				_Techniques = value;
				foreach(TechniqueModel item in value) {
					item.Ecole = this;
				}
			}
		}


		private Affinite _Affinite;
		[Column(Storage = "Affinite",Name = "affinite")]
		public Affinite Affinite{
			get{ return _Affinite;}
			set{_Affinite = value;}
		}

		private Affinite _Deficience;
		[Column(Storage = "Deficience",Name = "deficience")]
		public Affinite Deficience{
			get{ return _Deficience;}
			set{_Deficience = value;}
		}

		private IEnumerable<EcoleModelToSortModel> _Sorts;
		public IEnumerable<EcoleModelToSortModel> Sorts{
			get {
				if(_Sorts == null) {
					_Sorts = LoadByForeignKey<EcoleModelToSortModel>(p => p.EcoleModelId, Id);
			    }
				return _Sorts;
			}
			set {
				foreach(EcoleModelToSortModel item in _Sorts) {
					item.EcoleModel = null;
				}
				_Sorts = value;
				foreach(EcoleModelToSortModel item in value) {
					item.EcoleModel = this;
				}
			}
		}


		private AbsClanModel _clan;
		public AbsClanModel Clan{
			get {
				if(_clan == null) {
					_clan = LoadById<AbsClanModel>(ClanId);
			       }
				return _clan;
			} set {
				if(value == _clan) { return; }
				_clan = value;
				if(_clan != null) {
					_clanId = _clan.Id;
				} else {
					_clanId = 0;
				}
			}
		}

		private MotClefEcole _MotClef;
		[Column(Storage = "MotClef",Name = "motclef")]
		public MotClefEcole MotClef{
			get{ return _MotClef;}
			set{_MotClef = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecole_exemplar")]
	public partial class EcoleExemplar : DataExemplaire<EcoleModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "ecole_description")]
	public partial class EcoleDescription : DataDescription<EcoleModel> {
	}
}
