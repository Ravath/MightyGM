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
	[Table(Schema = "cinqanneaux",Name = "ecoleavanceemodel")]
	[CoreData]
	public partial class EcoleAvanceeModel : DataModel {

		private EcoleAvanceeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EcoleAvanceeDescription> id = GetModelReferencer<EcoleAvanceeDescription>();
					if(id.Count() == 0) {
						_obj = new EcoleAvanceeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _clanId;
		[Column(Storage = "ClanId",Name = "fk_clanmodel_clan")]
		[HiddenProperty]
		public int ClanId{
			get{ return _clanId;}
			set{_clanId = value;}
		}

		private ClanModel _clan;
		public ClanModel Clan{
			get{
				if( _clan == null)
					_clan = LoadById<ClanModel>(ClanId);
				return _clan;
			} set {
				if(_clan == value){return;}
				_clan = value;
				if( value != null)
					ClanId = value.Id;
			}
		}

		private BaliseEcole _balise;
		[Column(Storage = "Balise",Name = "balise")]
		public BaliseEcole Balise{
			get{ return _balise;}
			set{_balise = value;}
		}

		private IEnumerable<CompetenceStatus> _competencesRequises;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "CompetencesRequises",OtherKey = "EcoleAvanceeModelId")]
		public IEnumerable <CompetenceStatus> CompetencesRequises{
			get{
				if( _competencesRequises == null ){
					_competencesRequises = LoadFromJointure<CompetenceStatus,EcoleAvanceeModelToCompetenceStatus_CompetencesRequises>(false);
				}
				return _competencesRequises;
			}
			set{
				SaveToJointure<CompetenceStatus, EcoleAvanceeModelToCompetenceStatus_CompetencesRequises> (_competencesRequises, value,false);
				_competencesRequises = value;
			}
		}

		private IEnumerable<TechniqueAvanceeModel> _techniques;
		public IEnumerable <TechniqueAvanceeModel> Techniques{
			get{
				if( _techniques == null ){
					_techniques = LoadByForeignKey<TechniqueAvanceeModel>(p => p.EcoleId, Id);
				}
				return _techniques;
			}
			set{
				foreach( TechniqueAvanceeModel item in _techniques ){
					item.Ecole = null;

				}
				_techniques = value;
				foreach( TechniqueAvanceeModel item in value ){
					item.Ecole = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<ConditionExemplar> _conditions;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Conditions",OtherKey = "EcoleAvanceeModelId")]
		public IEnumerable <ConditionExemplar> Conditions{
			get{
				if( _conditions == null ){
					_conditions = LoadFromJointure<ConditionExemplar,EcoleAvanceeModelToConditionExemplar_Conditions>(false);
				}
				return _conditions;
			}
			set{
				SaveToJointure<ConditionExemplar, EcoleAvanceeModelToConditionExemplar_Conditions> (_conditions, value,false);
				_conditions = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<EcoleAvanceeModel,EcoleAvanceeModelToCompetenceStatus_CompetencesRequises>(true);
			DeleteJoins<EcoleAvanceeModel,EcoleAvanceeModelToConditionExemplar_Conditions>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "ecoleavanceedescription")]
	public partial class EcoleAvanceeDescription : DataDescription<EcoleAvanceeModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "ecoleavanceeexemplar")]
	public partial class EcoleAvanceeExemplar : DataExemplaire<EcoleAvanceeModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
