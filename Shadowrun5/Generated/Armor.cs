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
	[Table(Schema = "shadowrun5",Name = "armormodel")]
	[CoreData]
	public partial class ArmorModel : ProductModel {

		private ArmorDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmorDescription> id = GetModelReferencer<ArmorDescription>();
					if(id.Count() == 0) {
						_obj = new ArmorDescription();
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

		private int _armor;
		[Column(Storage = "Armor",Name = "armor")]
		public int Armor{
			get{ return _armor;}
			set{_armor = value;}
		}

		private bool _armorComplement;
		[Column(Storage = "ArmorComplement",Name = "armorcomplement")]
		public bool ArmorComplement{
			get{ return _armorComplement;}
			set{_armorComplement = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "armordescription")]
	public partial class ArmorDescription : ProductDescription {
	}
	[Table(Schema = "shadowrun5",Name = "armorexemplar")]
	public partial class ArmorExemplar : ProductExemplar {

		private IEnumerable<ArmorModificationExemplar> _modifications;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Modifications",OtherKey = "ArmorExemplarId")]
		public IEnumerable <ArmorModificationExemplar> Modifications{
			get{
				if( _modifications == null ){
					_modifications = LoadFromJointure<ArmorModificationExemplar,ArmorExemplarToArmorModificationExemplar_Modifications>(false);
				}
				return _modifications;
			}
			set{
				SaveToJointure<ArmorModificationExemplar, ArmorExemplarToArmorModificationExemplar_Modifications> (_modifications, value,false);
				_modifications = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmorExemplar,ArmorExemplarToArmorModificationExemplar_Modifications>(true);
			base.DeleteObject();
		}
	}
}
