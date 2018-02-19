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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "absclassemodel")]
	public abstract partial class AbsClasseModel : AbsDVModel {

		private int _competencesId;
		[Column(Storage = "CompetencesId",Name = "fk_competencemodel_competences")]
		[HiddenProperty]
		public int CompetencesId{
			get{ return _competencesId;}
			set{_competencesId = value;}
		}

		private CompetenceModel _competences;
		public CompetenceModel Competences{
			get{
				if( _competences == null)
					_competences = LoadById<CompetenceModel>(CompetencesId);
				return _competences;
			} set {
				if(_competences == value){return;}
				_competences = value;
				if( value != null)
					CompetencesId = value.Id;
			}
		}

		private IEnumerable<PouvoirClasseModel> _pouvoir;
		public IEnumerable <PouvoirClasseModel> Pouvoir{
			get{
				if( _pouvoir == null ){
					_pouvoir = LoadByForeignKey<PouvoirClasseModel>(p => p.ClasseId, Id);
				}
				return _pouvoir;
			}
			set{
				foreach( PouvoirClasseModel item in _pouvoir ){
					item.Classe = null;

				}
				_pouvoir = value;
				foreach( PouvoirClasseModel item in value ){
					item.Classe = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "dd35",Name = "absclassedescription")]
	public abstract partial class AbsClasseDescription : AbsDVDescription {
	}
	[Table(Schema = "dd35",Name = "absclasseexemplar")]
	public abstract partial class AbsClasseExemplar : AbsDVExemplar {

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}
	}
}
