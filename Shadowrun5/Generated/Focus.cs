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
	[Table(Schema = "shadowrun5",Name = "focusmodel")]
	[CoreData]
	public partial class FocusModel : ProductModel {

		private FocusDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<FocusDescription> id = GetModelReferencer<FocusDescription>();
					if(id.Count() == 0) {
						_obj = new FocusDescription();
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

		private int _karmaCost;
		[Column(Storage = "KarmaCost",Name = "karmacost")]
		public int KarmaCost{
			get{ return _karmaCost;}
			set{_karmaCost = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "focusdescription")]
	public partial class FocusDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "focusexemplar")]
	public partial class FocusExemplar : ProductExemplar {

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}
	}
}
