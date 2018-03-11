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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "absobjetmodel")]
	public abstract partial class AbsObjetModel : DataModel {

		[Column(Name = "cout_val", Storage="CoutVal")]
		public int CoutVal{
			get{
				return Cout.Value;
			}
			set{
				Cout.Value = value;
			}
		}

		[Column(Name = "cout_unit", Storage="CoutUnit")]
		public Monnaie CoutUnit{
			get{
				return Cout.Unity;
			}
			set{
				Cout.Unity = value;
			}
		}

		private UnitValue<int,Monnaie> _cout = new UnitValue<int,Monnaie>();
		[HiddenProperty]
		public UnitValue<int,Monnaie> Cout{
			get{
				return _cout;
			}
			set{
				_cout = value;
			}
		}



		private IEnumerable<SpecialObjetExemplar> _special;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Special",OtherKey = "AbsObjetModelId")]
		public IEnumerable <SpecialObjetExemplar> Special{
			get{
				if( _special == null ){
					_special = LoadFromJointure<SpecialObjetExemplar,AbsObjetModelToSpecialObjetExemplar_Special>(false);
				}
				return _special;
			}
			set{
				SaveToJointure<SpecialObjetExemplar, AbsObjetModelToSpecialObjetExemplar_Special> (_special, value,false);
				_special = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsObjetModel,AbsObjetModelToSpecialObjetExemplar_Special>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absobjetdescription")]
	public abstract partial class AbsObjetDescription : DataDescription<AbsObjetModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "absobjetexemplar")]
	public abstract partial class AbsObjetExemplar : DataExemplaire<AbsObjetModel> {
	}
}
