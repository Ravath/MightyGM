using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Data.Linq;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;

namespace Mushroom.Data {
	[CoreData]
	[Table(Schema = "mushroom",Name = "carriere_model")]
	public partial class CarriereModel : DataModel {

		private IEnumerable<machinsFromCarriereModel> _machins;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "machins",OtherKey = "Carriere")]
		public IEnumerable<machinsFromCarriereModel> machins{
			get {
				if(_machins == null) {
					_machins = LoadByForeignKey<machinsFromCarriereModel>(p => p.CarriereModelId, Id);
			    }
				return _machins;
			}
			set {
				foreach(machinsFromCarriereModel item in _machins) {
					item.From = null;
				}
				_machins = value;
				foreach(machinsFromCarriereModel item in value) {
					item.From = this;
				}
			}
		}
		private CarriereDescription _obj;
		public override IDataDescription Description {
			get {
				if(_obj == null) {
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

	}
	[Table(Schema = "mushroom",Name = "carriere_exemplar")]
	public partial class CarriereExemplar : DataExemplaire<CarriereModel> {
	}
	[Table(Schema = "mushroom",Name = "carriere_description")]
	public partial class CarriereDescription : DataDescription<CarriereModel> {
	}
	[Table(Schema = "mushroom",Name = "machinsfromcarrieremodel")]
	public class machinsFromCarriereModel : DataValue<CarriereModel,int> {
		[Column(Name = "fk_carriere", Storage = "CarriereModelId")]
		public int CarriereModelId {
			get { return base.FromId; }
			set { base.FromId = value; }
		}

		[Column(Name = "machins", Storage = "Machin")]
		public int Machin {
			get { return base.Value; }
			set { base.Value = value; }
		}
		[Association(ThisKey = "CarriereModelId", OtherKey = "Id", CanBeNull = false, Storage = "Carriere")]
		public CarriereModel Carriere {
			get { return From; }
			set { From = value; }
		}
	}
}
