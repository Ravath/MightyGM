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
	[Table(Schema = "shadowrun5",Name = "firearmaccessorymodel")]
	[CoreData]
	public partial class FirearmAccessoryModel : ProductModel {

		private FirearmAccessoryDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FirearmAccessoryDescription> id = GetModelReferencer<FirearmAccessoryDescription>();
					if(id.Count() == 0) {
						_obj = new FirearmAccessoryDescription();
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

		private FirearmAccessoryMount? _mount;
		[Column(Storage = "Mount",Name = "mount")]
		public FirearmAccessoryMount? Mount{
			get{ return _mount;}
			set{_mount = value;}
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
	}
	[Table(Schema = "shadowrun5",Name = "firearmaccessorydescription")]
	public partial class FirearmAccessoryDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "firearmaccessoryexemplar")]
	public partial class FirearmAccessoryExemplar : ProductExemplar {

		private bool _integrated;
		[Column(Storage = "integrated",Name = "integrated")]
		public bool integrated{
			get{ return _integrated;}
			set{_integrated = value;}
		}

		private int _rating;
		[Column(Storage = "Rating",Name = "rating")]
		public int Rating{
			get{ return _rating;}
			set{_rating = value;}
		}

		private FirearmAccessoryMount _mounted;
		[Column(Storage = "Mounted",Name = "mounted")]
		public FirearmAccessoryMount Mounted{
			get{ return _mounted;}
			set{_mounted = value;}
		}
	}
}
