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
	[Table(Schema = "pathfinder",Name = "absdvmodel")]
	public abstract partial class AbsDVModel : DataModel {

		private int _dVType;
		[Column(Storage = "DVType",Name = "dvtype")]
		public int DVType{
			get{ return _dVType;}
			set{_dVType = value;}
		}

		private int _facteurCompetence;
		[Column(Storage = "FacteurCompetence",Name = "facteurcompetence")]
		public int FacteurCompetence{
			get{ return _facteurCompetence;}
			set{_facteurCompetence = value;}
		}

		private IEnumerable<CompetenceModel> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "AbsDVModelId")]
		public IEnumerable <CompetenceModel> Competences{
			get{
				if( _competences == null ){
					_competences = LoadFromJointure<CompetenceModel,AbsDVModelToCompetenceModel_Competences>(false);
				}
				return _competences;
			}
			set{
				SaveToJointure<CompetenceModel, AbsDVModelToCompetenceModel_Competences> (_competences, value,false);
				_competences = value;
			}
		}

		private ProgressionBBA _bBA;
		[Column(Storage = "BBA",Name = "bba")]
		public ProgressionBBA BBA{
			get{ return _bBA;}
			set{_bBA = value;}
		}

		private ProgessionSauvegarde _reflexes;
		[Column(Storage = "Reflexes",Name = "reflexes")]
		public ProgessionSauvegarde Reflexes{
			get{ return _reflexes;}
			set{_reflexes = value;}
		}

		private ProgessionSauvegarde _vigueur;
		[Column(Storage = "Vigueur",Name = "vigueur")]
		public ProgessionSauvegarde Vigueur{
			get{ return _vigueur;}
			set{_vigueur = value;}
		}

		private ProgessionSauvegarde _volonte;
		[Column(Storage = "Volonte",Name = "volonte")]
		public ProgessionSauvegarde Volonte{
			get{ return _volonte;}
			set{_volonte = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsDVModel,AbsDVModelToCompetenceModel_Competences>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "absdvdescription")]
	public abstract partial class AbsDVDescription : DataDescription<AbsDVModel> {
	}
	[Table(Schema = "pathfinder",Name = "absdvexemplar")]
	public abstract partial class AbsDVExemplar : DataExemplaire<AbsDVModel> {

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}
	}
}
