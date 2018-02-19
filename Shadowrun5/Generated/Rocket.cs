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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "rocketmodel")]
	[CoreData]
	public partial class RocketModel : AbsGrenadeModel {

		private RocketDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RocketDescription> id = GetModelReferencer<RocketDescription>();
					if(id.Count() == 0) {
						_obj = new RocketDescription();
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
	[Table(Schema = "shadowrun5",Name = "rocketdescription")]
	public partial class RocketDescription : AbsGrenadeDescription {
	}
	[Table(Schema = "shadowrun5",Name = "rocketexemplar")]
	public partial class RocketExemplar : AbsGrenadeExemplar {

		private int _missileRating;
		[Column(Storage = "MissileRating",Name = "missilerating")]
		public int MissileRating{
			get{ return _missileRating;}
			set{_missileRating = value;}
		}
	}
}
