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
	[Table(Schema = "cinqanneaux",Name = "voiealternativemodel")]
	[CoreData]
	public partial class VoieAlternativeModel : DataModel {

		private VoieAlternativeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VoieAlternativeDescription> id = GetModelReferencer<VoieAlternativeDescription>();
					if(id.Count() == 0) {
						_obj = new VoieAlternativeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private string _nomTechnique = "";
		[Column(Storage = "NomTechnique",Name = "nomtechnique")]
		public string NomTechnique{
			get{ return _nomTechnique;}
			set{_nomTechnique = value;}
		}

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private MotClefEcole? _motClef;
		[Column(Storage = "MotClef",Name = "motclef")]
		public MotClefEcole? MotClef{
			get{ return _motClef;}
			set{_motClef = value;}
		}

		private IEnumerable<CompetenceExemplar> _competencesRequises;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CompetencesRequises",OtherKey = "VoieAlternativeModelId")]
		public IEnumerable <CompetenceExemplar> CompetencesRequises{
			get{
				if( _competencesRequises == null ){
					_competencesRequises = LoadFromJointure<CompetenceExemplar,VoieAlternativeModelToCompetenceExemplar_CompetencesRequises>(false);
				}
				return _competencesRequises;
			}
			set{
				SaveToJointure<CompetenceExemplar, VoieAlternativeModelToCompetenceExemplar_CompetencesRequises> (_competencesRequises, value,false);
				_competencesRequises = value;
			}
		}

		private IEnumerable<ConditionExemplar> _conditions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Conditions",OtherKey = "VoieAlternativeModelId")]
		public IEnumerable <ConditionExemplar> Conditions{
			get{
				if( _conditions == null ){
					_conditions = LoadFromJointure<ConditionExemplar,VoieAlternativeModelToConditionExemplar_Conditions>(false);
				}
				return _conditions;
			}
			set{
				SaveToJointure<ConditionExemplar, VoieAlternativeModelToConditionExemplar_Conditions> (_conditions, value,false);
				_conditions = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<VoieAlternativeModel,VoieAlternativeModelToCompetenceExemplar_CompetencesRequises>(true);
			DeleteJoins<VoieAlternativeModel,VoieAlternativeModelToConditionExemplar_Conditions>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "voiealternativedescription")]
	public partial class VoieAlternativeDescription : DataDescription<VoieAlternativeModel> {

		private string _technique = "";
		[LargeText]
		[Column(Storage = "Technique",Name = "technique")]
		public string Technique{
			get{ return _technique;}
			set{_technique = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "voiealternativeexemplar")]
	public partial class VoieAlternativeExemplar : DataExemplaire<VoieAlternativeModel> {
	}
}
