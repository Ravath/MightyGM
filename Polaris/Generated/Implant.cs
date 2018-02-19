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
	[Table(Schema = "polaris",Name = "implantmodel")]
	[CoreData]
	public partial class ImplantModel : MaterielModel {

		private ImplantDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ImplantDescription> id = GetModelReferencer<ImplantDescription>();
					if(id.Count() == 0) {
						_obj = new ImplantDescription();
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

		private AttributImplant? _attribut;
		[Column(Storage = "Attribut",Name = "attribut")]
		public AttributImplant? Attribut{
			get{ return _attribut;}
			set{_attribut = value;}
		}

		private bool _artificiel;
		[Column(Storage = "Artificiel",Name = "artificiel")]
		public bool Artificiel{
			get{ return _artificiel;}
			set{_artificiel = value;}
		}
	}
	[Table(Schema = "polaris",Name = "implantdescription")]
	public partial class ImplantDescription : MaterielDescription {
	}
	[Table(Schema = "polaris",Name = "implantexemplar")]
	public partial class ImplantExemplar : MaterielExemplar {
	}
}
