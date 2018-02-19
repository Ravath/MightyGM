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
	[Table(Schema = "shadowrun5",Name = "gearmodel")]
	[CoreData]
	public partial class GearModel : ProductModel {

		private GearDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<GearDescription> id = GetModelReferencer<GearDescription>();
					if(id.Count() == 0) {
						_obj = new GearDescription();
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

		private GearType _type;
		[Column(Storage = "Type",Name = "type")]
		public GearType Type{
			get{ return _type;}
			set{_type = value;}
		}

		private int _minRating;
		[Column(Storage = "MinRating",Name = "minrating")]
		public int MinRating{
			get{ return _minRating;}
			set{_minRating = value;}
		}

		private int _maxRating;
		[Column(Storage = "MaxRating",Name = "maxrating")]
		public int MaxRating{
			get{ return _maxRating;}
			set{_maxRating = value;}
		}

		private bool _ratingPerAvail;
		[Column(Storage = "RatingPerAvail",Name = "ratingperavail")]
		public bool RatingPerAvail{
			get{ return _ratingPerAvail;}
			set{_ratingPerAvail = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "geardescription")]
	public partial class GearDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "gearexemplar")]
	public partial class GearExemplar : ProductExemplar {
	}
}
