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
	[Table(Schema = "starwars",Name = "capacitedecompetencemodel")]
	[CoreData]
	public partial class CapaciteDeCompetenceModel : CapaciteModel {

		private CapaciteDeCompetenceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CapaciteDeCompetenceDescription> id = GetModelReferencer<CapaciteDeCompetenceDescription>();
					if(id.Count() == 0) {
						_obj = new CapaciteDeCompetenceDescription();
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

		private int _competenceId;
		[Column(Storage = "CompetenceId",Name = "fk_competencemodel")]
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
	}
	[Table(Schema = "starwars",Name = "capacitedecompetencedescription")]
	public partial class CapaciteDeCompetenceDescription : CapaciteDescription {
	}
	[Table(Schema = "starwars",Name = "capacitedecompetenceexemplar")]
	public partial class CapaciteDeCompetenceExemplar : CapaciteExemplar {
	}
}
