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
	[Table(Schema = "starwars",Name = "carrieremodel")]
	[CoreData]
	public partial class CarriereModel : DataModel {

		private CarriereDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CarriereDescription> id = GetModelReferencer<CarriereDescription>();
					if(id.Count() == 0) {
						_obj = new CarriereDescription();
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

		private IEnumerable<CarriereModelToCompetenceModel> _competences;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Competences",OtherKey = "CarriereModelId")]
		public IEnumerable <CarriereModelToCompetenceModel> Competences{
			get{
				if( _competences == null ){
					_competences = LoadByForeignKey<CarriereModelToCompetenceModel>(p => p.CarriereModelId, Id);
				}
				return _competences;
			}
			set{
				foreach( CarriereModelToCompetenceModel item in _competences ){
					item.CarriereModel = null;
				}
				_competences = value;
				foreach( CarriereModelToCompetenceModel item in value ){
					item.CarriereModel = this;
				}
			}
		}

		private IEnumerable<SpecialiteModel> _specialites;
		public IEnumerable <SpecialiteModel> Specialites{
			get{
				if( _specialites == null ){
					_specialites = LoadByForeignKey<SpecialiteModel>(p => p.CarriereId, Id);
				}
				return _specialites;
			}
			set{
				foreach( SpecialiteModel item in _specialites ){
					item.Carriere = null;
				}
				_specialites = value;
				foreach( SpecialiteModel item in value ){
					item.Carriere = this;
				}
			}
		}

		private IEnumerable<HistoireDeCarriereModel> _histoires;
		public IEnumerable <HistoireDeCarriereModel> Histoires{
			get{
				if( _histoires == null ){
					_histoires = LoadByForeignKey<HistoireDeCarriereModel>(p => p.CarriereId, Id);
				}
				return _histoires;
			}
			set{
				foreach( HistoireDeCarriereModel item in _histoires ){
					item.Carriere = null;
				}
				_histoires = value;
				foreach( HistoireDeCarriereModel item in value ){
					item.Carriere = this;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "carrieredescription")]
	public partial class CarriereDescription : DataDescription<CarriereModel> {
	}
	[Table(Schema = "starwars",Name = "carriereexemplar")]
	public partial class CarriereExemplar : DataExemplaire<CarriereModel> {
	}
}
