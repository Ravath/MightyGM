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
	[Table(Schema = "polaris",Name = "techniquetirmodel")]
	[CoreData]
	public partial class TechniqueTirModel : DataModel {

		private TechniqueTirDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TechniqueTirDescription> id = GetModelReferencer<TechniqueTirDescription>();
					if(id.Count() == 0) {
						_obj = new TechniqueTirDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeTechniqueTir _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeTechniqueTir Type{
			get{ return _type;}
			set{_type = value;}
		}

		private bool _actionExclusive;
		[Column(Storage = "ActionExclusive",Name = "actionexclusive")]
		public bool ActionExclusive{
			get{ return _actionExclusive;}
			set{_actionExclusive = value;}
		}
	}
	[Table(Schema = "polaris",Name = "techniquetirdescription")]
	public partial class TechniqueTirDescription : DataDescription<TechniqueTirModel> {
	}
	[Table(Schema = "polaris",Name = "techniquetirexemplar")]
	public partial class TechniqueTirExemplar : DataExemplaire<TechniqueTirModel> {
	}
}
