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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "competencestatus")]
	[CoreData]
	public partial class CompetenceStatus : DataObject {

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competencemodel_competence")]
		[HiddenProperty]
		public int CompetenceId{
			get{ return _competenceId;}
			set{_competenceId = value;}
		}

		private CompetenceModel _competence;
		public CompetenceModel Competence{
			get{
				if( _competence == null)
					_competence = LoadById<CompetenceModel>(CompetenceId);
				return _competence;
			} set {
				if(_competence == value){return;}
				_competence = value;
				if( value != null)
					CompetenceId = value.Id;
			}
		}

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_specialisationmodel_specialite")]
		[HiddenProperty]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private SpecialisationModel _specialite;
		public SpecialisationModel Specialite{
			get{
				if( _specialite == null)
					_specialite = LoadById<SpecialisationModel>(SpecialiteId);
				return _specialite;
			} set {
				if(_specialite == value){return;}
				_specialite = value;
				if( value != null)
					SpecialiteId = value.Id;
			}
		}
	}
}
