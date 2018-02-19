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
	[Table(Schema = "polaris",Name = "armuremodel")]
	[CoreData]
	public partial class ArmureModel : ObjectModel {

		private ArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmureDescription> id = GetModelReferencer<ArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ArmureDescription();
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

		private int _protection;
		[Column(Storage = "Protection",Name = "protection")]
		public int Protection{
			get{ return _protection;}
			set{_protection = value;}
		}

		private int? _choc;
		[Column(Storage = "Choc",Name = "choc")]
		public int? Choc{
			get{ return _choc;}
			set{_choc = value;}
		}

		private bool _parNiveau;
		[Column(Storage = "ParNiveau",Name = "parniveau")]
		public bool ParNiveau{
			get{ return _parNiveau;}
			set{_parNiveau = value;}
		}

		private bool _tete;
		[Column(Storage = "Tete",Name = "tete")]
		public bool Tete{
			get{ return _tete;}
			set{_tete = value;}
		}

		private bool _corps;
		[Column(Storage = "Corps",Name = "corps")]
		public bool Corps{
			get{ return _corps;}
			set{_corps = value;}
		}

		private bool _bras;
		[Column(Storage = "Bras",Name = "bras")]
		public bool Bras{
			get{ return _bras;}
			set{_bras = value;}
		}

		private bool _jambes;
		[Column(Storage = "Jambes",Name = "jambes")]
		public bool Jambes{
			get{ return _jambes;}
			set{_jambes = value;}
		}

		private CategorieArmure _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieArmure Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}
	}
	[Table(Schema = "polaris",Name = "armuredescription")]
	public partial class ArmureDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "armureexemplar")]
	public partial class ArmureExemplar : ObjectExemplar {
	}
}
