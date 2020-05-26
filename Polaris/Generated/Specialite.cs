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
	[Table(Schema = "polaris",Name = "specialitemodel")]
	[CoreData]
	public partial class SpecialiteModel : AbsCompetenceModel {

		private SpecialiteDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SpecialiteDescription> id = GetModelReferencer<SpecialiteDescription>();
					if(id.Count() == 0) {
						_obj = new SpecialiteDescription();
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
	}
	[Table(Schema = "polaris",Name = "specialitedescription")]
	public partial class SpecialiteDescription : AbsCompetenceDescription {
	}
	[Table(Schema = "polaris",Name = "specialiteexemplar")]
	public partial class SpecialiteExemplar : AbsCompetenceExemplar {
	}
}
