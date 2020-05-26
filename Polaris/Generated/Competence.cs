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
	[Table(Schema = "polaris",Name = "competencemodel")]
	[CoreData]
	public partial class CompetenceModel : AbsCompetenceModel {

		private CompetenceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CompetenceDescription> id = GetModelReferencer<CompetenceDescription>();
					if(id.Count() == 0) {
						_obj = new CompetenceDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<SpecialiteModel> _specialites;
		public IEnumerable <SpecialiteModel> Specialites{
			get{
				if( _specialites == null ){
					_specialites = LoadByForeignKey<SpecialiteModel>(p => p.CompetenceId, Id);
				}
				return _specialites;
			}
			set{
				foreach( SpecialiteModel item in _specialites ){
					item.Competence = null;

				}
				_specialites = value;
				foreach( SpecialiteModel item in value ){
					item.Competence = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "polaris",Name = "competencedescription")]
	public partial class CompetenceDescription : AbsCompetenceDescription {
	}
	[Table(Schema = "polaris",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : AbsCompetenceExemplar {

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_specialitemodel_specialite")]
		[HiddenProperty]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private SpecialiteModel _specialite;
		public SpecialiteModel Specialite{
			get{
				if( _specialite == null)
					_specialite = LoadById<SpecialiteModel>(SpecialiteId);
				return _specialite;
			} set {
				if(_specialite == value){return;}
				_specialite = value;
				if( value != null)
					SpecialiteId = value.Id;
			}
		}
	}
}
