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
	[Table(Schema = "cinqanneaux",Name = "competence_model")]
	public partial class CompetenceModel : DataModel {

		private GroupeCompetence _Groupe;
		[Column(Storage = "Groupe",Name = "groupe")]
		public GroupeCompetence Groupe{
			get{ return _Groupe;}
			set{_Groupe = value;}
		}

		private Trait _TraitAssocie;
		[Column(Storage = "TraitAssocie",Name = "traitassocie")]
		public Trait TraitAssocie{
			get{ return _TraitAssocie;}
			set{_TraitAssocie = value;}
		}

		private IEnumerable<SousTypeFromCompetenceModel> _SousType;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "SousType",OtherKey = "Competence")]
		public IEnumerable<SousTypeFromCompetenceModel> SousType{
			get {
				if(_SousType == null) {
					_SousType = LoadByForeignKey<SousTypeFromCompetenceModel>(p => p.CompetenceModelId, Id);
			    }
				return _SousType;
			}
			set {
				foreach(SousTypeFromCompetenceModel item in _SousType) {
					item.CompetenceModel = null;
				}
				_SousType = value;
				foreach(SousTypeFromCompetenceModel item in value) {
					item.CompetenceModel = this;
				}
			}
		}


		private IEnumerable<SpecialisationsFromCompetenceModel> _Specialisations;
		[Association(ThisKey = "Id",CanBeNull = "true",Storage = "Specialisations",OtherKey = "Competence")]
		public IEnumerable<SpecialisationsFromCompetenceModel> Specialisations{
			get {
				if(_Specialisations == null) {
					_Specialisations = LoadByForeignKey<SpecialisationsFromCompetenceModel>(p => p.CompetenceModelId, Id);
			    }
				return _Specialisations;
			}
			set {
				foreach(SpecialisationsFromCompetenceModel item in _Specialisations) {
					item.CompetenceModel = null;
				}
				_Specialisations = value;
				foreach(SpecialisationsFromCompetenceModel item in value) {
					item.CompetenceModel = this;
				}
			}
		}


		private IEnumerable<CompetenceModelToMaitriseModel> _Maitrises;
		public IEnumerable<CompetenceModelToMaitriseModel> Maitrises{
			get {
				if(_Maitrises == null) {
					_Maitrises = LoadByForeignKey<CompetenceModelToMaitriseModel>(p => p.CompetenceModelId, Id);
			    }
				return _Maitrises;
			}
			set {
				foreach(CompetenceModelToMaitriseModel item in _Maitrises) {
					item.CompetenceModel = null;
				}
				_Maitrises = value;
				foreach(CompetenceModelToMaitriseModel item in value) {
					item.CompetenceModel = this;
				}
			}
		}

	}
	[Table(Schema = "cinqanneaux",Name = "competence_exemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "competence_description")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "soustypefromcompetencemodel")]
	public class SousTypeFromCompetenceModel : DataObject {

		private string _sousType;
		[Column(Storage = "SousType",Name = "soustype")]
		public string SousType{
			get{ return _sousType;}
			set{_sousType = value;}
		}

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competence")]
		public int CompetenceId{
			get{ return _competenceId}
			set{_competenceId = value;}
		}

		private CompetenceModel _competenceModel;
		[Association(ThisKey = "CompetenceId",CanBeNull = "false",Storage = "CompetenceModel",OtherKey = "Id")]
		public CompetenceModel CompetenceModel{
			get {
				if(_competenceModel == null) {
					_competenceModel = LoadById<CompetenceModel>(CompetenceModelId);
			       }
				return _competenceModel;
			} set {
				if(value == _competenceModel) { return; }
				_competenceModel = value;
				if(_competenceModel != null) {
					_competenceModelId = _competenceModel.Id;
				} else {
					_competenceModelId = 0;
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "specialisationsfromcompetencemodel")]
	public class SpecialisationsFromCompetenceModel : DataObject {

		private string _specialisations;
		[Column(Storage = "Specialisations",Name = "specialisations")]
		public string Specialisations{
			get{ return _specialisations;}
			set{_specialisations = value;}
		}

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competence")]
		public int CompetenceId{
			get{ return _competenceId}
			set{_competenceId = value;}
		}

		private CompetenceModel _competenceModel;
		[Association(ThisKey = "CompetenceId",CanBeNull = "false",Storage = "CompetenceModel",OtherKey = "Id")]
		public CompetenceModel CompetenceModel{
			get {
				if(_competenceModel == null) {
					_competenceModel = LoadById<CompetenceModel>(CompetenceModelId);
			       }
				return _competenceModel;
			} set {
				if(value == _competenceModel) { return; }
				_competenceModel = value;
				if(_competenceModel != null) {
					_competenceModelId = _competenceModel.Id;
				} else {
					_competenceModelId = 0;
				}
			}
		}
	}
}
