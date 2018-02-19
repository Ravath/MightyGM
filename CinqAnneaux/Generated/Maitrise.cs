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
	[Table(Schema = "cinqanneaux",Name = "maitrisemodel")]
	[CoreData]
	public partial class MaitriseModel : DataModel {

		private MaitriseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MaitriseDescription> id = GetModelReferencer<MaitriseDescription>();
					if(id.Count() == 0) {
						_obj = new MaitriseDescription();
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

		private int _rangRequis;
		[Column(Storage = "RangRequis",Name = "rangrequis")]
		public int RangRequis{
			get{ return _rangRequis;}
			set{_rangRequis = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "maitrisedescription")]
	public partial class MaitriseDescription : DataDescription<MaitriseModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "maitriseexemplar")]
	public partial class MaitriseExemplar : DataExemplaire<MaitriseModel> {
	}
}
