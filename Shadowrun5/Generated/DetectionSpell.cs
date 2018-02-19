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
	[Table(Schema = "shadowrun5",Name = "detectionspellmodel")]
	[CoreData]
	public partial class DetectionSpellModel : SpellModel {

		private DetectionSpellDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DetectionSpellDescription> id = GetModelReferencer<DetectionSpellDescription>();
					if(id.Count() == 0) {
						_obj = new DetectionSpellDescription();
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

		private bool _active;
		[Column(Storage = "Active",Name = "active")]
		public bool Active{
			get{ return _active;}
			set{_active = value;}
		}

		private bool _extended;
		[Column(Storage = "Extended",Name = "extended")]
		public bool Extended{
			get{ return _extended;}
			set{_extended = value;}
		}

		private DetectionSpellArea _area;
		[Column(Storage = "Area",Name = "area")]
		public DetectionSpellArea Area{
			get{ return _area;}
			set{_area = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "detectionspelldescription")]
	public partial class DetectionSpellDescription : SpellDescription {
	}
	[Table(Schema = "shadowrun5",Name = "detectionspellexemplar")]
	public partial class DetectionSpellExemplar : SpellExemplar {
	}
}
