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
	[Table(Schema = "shadowrun5",Name = "cyberdeckmodel")]
	[CoreData]
	public partial class CyberdeckModel : ElectronicModel {

		private CyberdeckDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CyberdeckDescription> id = GetModelReferencer<CyberdeckDescription>();
					if(id.Count() == 0) {
						_obj = new CyberdeckDescription();
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

		private int _ratingI;
		[Column(Storage = "RatingI",Name = "ratingi")]
		public int RatingI{
			get{ return _ratingI;}
			set{_ratingI = value;}
		}

		private int _ratingII;
		[Column(Storage = "RatingII",Name = "ratingii")]
		public int RatingII{
			get{ return _ratingII;}
			set{_ratingII = value;}
		}

		private int _ratingIII;
		[Column(Storage = "RatingIII",Name = "ratingiii")]
		public int RatingIII{
			get{ return _ratingIII;}
			set{_ratingIII = value;}
		}

		private int _ratingIV;
		[Column(Storage = "RatingIV",Name = "ratingiv")]
		public int RatingIV{
			get{ return _ratingIV;}
			set{_ratingIV = value;}
		}

		private int _programs;
		[Column(Storage = "Programs",Name = "programs")]
		public int Programs{
			get{ return _programs;}
			set{_programs = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "cyberdeckdescription")]
	public partial class CyberdeckDescription : ElectronicDescription {
	}
	[Table(Schema = "shadowrun5",Name = "cyberdeckexemplar")]
	public partial class CyberdeckExemplar : ElectronicExemplar {
	}
}
