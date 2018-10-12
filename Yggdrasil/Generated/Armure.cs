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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "armuremodel")]
	[CoreData]
	public partial class ArmureModel : ObjetModel {

		private ArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureDescription> id = GetModelReferencer<ArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _protection;
		[Column(Storage = "Protection",Name = "protection")]
		public int Protection{
			get{ return _protection;}
			set{_protection = value;}
		}

		private CategorieArmure _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieArmure Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "armuredescription")]
	public partial class ArmureDescription : ObjetDescription {
	}
	[Table(Schema = "yggdrasil",Name = "armureexemplar")]
	public partial class ArmureExemplar : ObjetExemplar {

		private int _soliditeRestante;
		[Column(Storage = "SoliditeRestante",Name = "soliditerestante")]
		public int SoliditeRestante{
			get{ return _soliditeRestante;}
			set{_soliditeRestante = value;}
		}
	}
}
