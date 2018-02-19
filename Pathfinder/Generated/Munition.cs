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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "munitionmodel")]
	[CoreData]
	public partial class MunitionModel : ObjetModel {

		private MunitionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MunitionDescription> id = GetModelReferencer<MunitionDescription>();
					if(id.Count() == 0) {
						_obj = new MunitionDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _quantite;
		[Column(Storage = "Quantite",Name = "quantite")]
		public int Quantite{
			get{ return _quantite;}
			set{_quantite = value;}
		}

		private int _armeId;
		[Column(Storage = "ArmeId",Name = "fk_armemodel_arme")]
		[HiddenProperty]
		public int ArmeId{
			get{ return _armeId;}
			set{_armeId = value;}
		}

		private ArmeModel _arme;
		public ArmeModel Arme{
			get {
				if(_arme == null) {
					_arme = LoadById<ArmeModel>(ArmeId);
			       }
				return _arme;
			} set {
				if(value == _arme) { return; }
				_arme = value;
				if(_arme != null) {
					_armeId = _arme.Id;
				} else {
					_armeId = 0;
				}
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "munitiondescription")]
	public partial class MunitionDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "munitionexemplar")]
	public partial class MunitionExemplar : ObjetExemplar {

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}

		private IEnumerable<EnchantementArmeExemplar> _enchantements;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Enchantements",OtherKey = "MunitionExemplarId")]
		public IEnumerable <EnchantementArmeExemplar> Enchantements{
			get{
				if( _enchantements == null ){
					_enchantements = LoadFromJointure<EnchantementArmeExemplar,MunitionExemplarToEnchantementArmeExemplar_Enchantements>(false);
				}
				return _enchantements;
			}
			set{
				SaveToJointure<EnchantementArmeExemplar, MunitionExemplarToEnchantementArmeExemplar_Enchantements> (_enchantements, value,false);
				_enchantements = value;
			}
		}

		private int _stock;
		[Column(Storage = "Stock",Name = "stock")]
		public int Stock{
			get{ return _stock;}
			set{_stock = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<MunitionExemplar,MunitionExemplarToEnchantementArmeExemplar_Enchantements>(true);
			base.DeleteObject();
		}
	}
}
