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
	[Table(Schema = "cinqanneaux",Name = "specialisationmodel")]
	[CoreData]
	public partial class SpecialisationModel : DataModel {

		private SpecialisationDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialisationDescription> id = GetModelReferencer<SpecialisationDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialisationDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competencemodel_competence")]
		[HiddenProperty]
		public int CompetenceId{
			get{ return _competenceId;}
			set{_competenceId = value;}
		}

		private CompetenceModel _competence;
		public CompetenceModel Competence{
			get {
				if(_competence == null) {
					_competence = LoadById<CompetenceModel>(CompetenceId);
			       }
				return _competence;
			} set {
				if(value == _competence) { return; }
				_competence = value;
				if(_competence != null) {
					_competenceId = _competence.Id;
				} else {
					_competenceId = 0;
				}
			}
		}

		private bool _degradante;
		[Column(Storage = "Degradante",Name = "degradante")]
		public bool Degradante{
			get{ return _degradante;}
			set{_degradante = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "specialisationdescription")]
	public partial class SpecialisationDescription : DataDescription<SpecialisationModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "specialisationexemplar")]
	public partial class SpecialisationExemplar : DataExemplaire<SpecialisationModel> {
	}
}
