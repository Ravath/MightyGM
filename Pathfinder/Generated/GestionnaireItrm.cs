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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "gestionnaireitrmmodel")]
	[CoreData]
	public partial class GestionnaireItrmModel : DataModel {

		private GestionnaireItrmDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GestionnaireItrmDescription> id = GetModelReferencer<GestionnaireItrmDescription>();
					if(id.Count() == 0) {
						_obj = new GestionnaireItrmDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _salaire;
		[Column(Storage = "Salaire",Name = "salaire")]
		public int Salaire{
			get{ return _salaire;}
			set{_salaire = value;}
		}

		private IEnumerable<CompetenceExemplar> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "GestionnaireItrmModelId")]
		public IEnumerable <CompetenceExemplar> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceExemplar,GestionnaireItrmModelToCompetenceExemplar_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceExemplar, GestionnaireItrmModelToCompetenceExemplar_Competences> (_competences, value,false);
				_competences = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<GestionnaireItrmModel,GestionnaireItrmModelToCompetenceExemplar_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "gestionnaireitrmdescription")]
	public partial class GestionnaireItrmDescription : DataDescription<GestionnaireItrmModel> {
	}
	[Table(Schema = "pathfinder",Name = "gestionnaireitrmexemplar")]
	public partial class GestionnaireItrmExemplar : DataExemplaire<GestionnaireItrmModel> {
	}
}
