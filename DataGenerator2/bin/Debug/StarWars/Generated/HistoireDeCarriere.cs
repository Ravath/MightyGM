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
	[Table(Schema = "starwars",Name = "histoiredecarrieremodel")]
	[CoreData]
	public partial class HistoireDeCarriereModel : DataModel {

		private HistoireDeCarriereDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<HistoireDeCarriereDescription> id = GetModelReferencer<HistoireDeCarriereDescription>();
					if(id.Count() == 0) {
						_obj = new HistoireDeCarriereDescription();
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

		private int _carriereId;
		[Column(Storage = "CarriereId",Name = "fk_carrieremodel")]
		[HiddenProperty]
		public int CarriereId{
			get{ return _carriereId;}
			set{_carriereId = value;}
		}

		private CarriereModel _carriere;
		public CarriereModel Carriere{
			get {
				if(_carriere == null) {
					_carriere = LoadById<CarriereModel>(CarriereId);
			       }
				return _carriere;
			} set {
				if(value == _carriere) { return; }
				_carriere = value;
				if(_carriere != null) {
					_carriereId = _carriere.Id;
				} else {
					_carriereId = 0;
				}
			}
		}
	}
	[Table(Schema = "starwars",Name = "histoiredecarrieredescription")]
	public partial class HistoireDeCarriereDescription : DataDescription<HistoireDeCarriereModel> {
	}
	[Table(Schema = "starwars",Name = "histoiredecarriereexemplar")]
	public partial class HistoireDeCarriereExemplar : DataExemplaire<HistoireDeCarriereModel> {
	}
}
