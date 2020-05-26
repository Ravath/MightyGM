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
	[Table(Schema = "polaris",Name = "accessoirearmemodel")]
	[CoreData]
	public partial class AccessoireArmeModel : DataModel {

		private AccessoireArmeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AccessoireArmeDescription> id = GetModelReferencer<AccessoireArmeDescription>();
					if(id.Count() == 0) {
						_obj = new AccessoireArmeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _specialId;
		[Column(Storage = "SpecialId",Name = "fk_specialarmeexemplar_special")]
		[HiddenProperty]
		public int SpecialId{
			get{ return _specialId;}
			set{_specialId = value;}
		}

		private SpecialArmeExemplar _special;
		public SpecialArmeExemplar Special{
			get{
				if( _special == null)
					_special = LoadById<SpecialArmeExemplar>(SpecialId);
				return _special;
			} set {
				if(_special == value){return;}
				_special = value;
				if( value != null)
					SpecialId = value.Id;
			}
		}
	}
	[Table(Schema = "polaris",Name = "accessoirearmedescription")]
	public partial class AccessoireArmeDescription : DataDescription<AccessoireArmeModel> {
	}
	[Table(Schema = "polaris",Name = "accessoirearmeexemplar")]
	public partial class AccessoireArmeExemplar : DataExemplaire<AccessoireArmeModel> {
	}
}
