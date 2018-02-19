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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "armuremodel")]
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
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _bonusCA;
		[Column(Storage = "BonusCA",Name = "bonusca")]
		public int BonusCA{
			get{ return _bonusCA;}
			set{_bonusCA = value;}
		}

		private int _malusTests;
		[Column(Storage = "MalusTests",Name = "malustests")]
		public int MalusTests{
			get{ return _malusTests;}
			set{_malusTests = value;}
		}

		private int _dexMax;
		[Column(Storage = "DexMax",Name = "dexmax")]
		public int DexMax{
			get{ return _dexMax;}
			set{_dexMax = value;}
		}

		private int _echecSorts;
		[Column(Storage = "EchecSorts",Name = "echecsorts")]
		public int EchecSorts{
			get{ return _echecSorts;}
			set{_echecSorts = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}
	}
	[Table(Schema = "dd35",Name = "armuredescription")]
	public partial class ArmureDescription : ObjetDescription {
	}
	[Table(Schema = "dd35",Name = "armureexemplar")]
	public partial class ArmureExemplar : ObjetExemplar {
	}
}
