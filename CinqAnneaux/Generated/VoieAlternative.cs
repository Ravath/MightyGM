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

		private BaliseEcole? _balise;
		[Column(Storage = "Balise",Name = "balise")]
		public BaliseEcole? Balise{
			get{ return _balise;}
			set{_balise = value;}
		}

		private IEnumerable<CompetenceStatus> _competencesRequises;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CompetencesRequises",OtherKey = "VoieAlternativeModelId")]
		public IEnumerable <CompetenceStatus> CompetencesRequises{
			get{
				if( _competencesRequises == null ){
					_competencesRequises = LoadFromJointure<CompetenceStatus,VoieAlternativeModelToCompetenceStatus_CompetencesRequises>(false);
				}
				return _competencesRequises;
			}
			set{
				SaveToJointure<CompetenceStatus, VoieAlternativeModelToCompetenceStatus_CompetencesRequises> (_competencesRequises, value,false);
				_competencesRequises = value;
			}
		}

		private IEnumerable<ConditionAdmissionExemplar> _conditions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Conditions",OtherKey = "VoieAlternativeModelId")]
		public IEnumerable <ConditionAdmissionExemplar> Conditions{
			get{
				if( _conditions == null ){
					_conditions = LoadFromJointure<ConditionAdmissionExemplar,VoieAlternativeModelToConditionAdmissionExemplar_Conditions>(false);
				}
				return _conditions;
			}
			set{
				SaveToJointure<ConditionAdmissionExemplar, VoieAlternativeModelToConditionAdmissionExemplar_Conditions> (_conditions, value,false);
				_conditions = value;
			}
		}

		private int _clanRequisId;
		[Column(Storage = "ClanRequisId",Name = "fk_clanmodel_clanrequis")]
		[HiddenProperty]
		public int ClanRequisId{
			get{ return _clanRequisId;}
			set{_clanRequisId = value;}
		}

		private ClanModel _clanRequis;
		public ClanModel ClanRequis{
			get{
				if( _clanRequis == null)
					_clanRequis = LoadById<ClanModel>(ClanRequisId);
				return _clanRequis;
			} set {
				if(_clanRequis == value){return;}
				_clanRequis = value;
				if( value != null)
					ClanRequisId = value.Id;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<VoieAlternativeModel,VoieAlternativeModelToCompetenceStatus_CompetencesRequises>(true);
			DeleteJoins<VoieAlternativeModel,VoieAlternativeModelToConditionAdmissionExemplar_Conditions>(true);
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
