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
	[Table(Schema = "dd35",Name = "enchantementobjetmodel")]
	public abstract partial class EnchantementObjetModel : DataModel {

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}

		private EcoleMagie _ecoleAura;
		[Column(Storage = "EcoleAura",Name = "ecoleaura")]
		public EcoleMagie EcoleAura{
			get{ return _ecoleAura;}
			set{_ecoleAura = value;}
		}

		private PuissanceAura _puissanceAura;
		[Column(Storage = "PuissanceAura",Name = "puissanceaura")]
		public PuissanceAura PuissanceAura{
			get{ return _puissanceAura;}
			set{_puissanceAura = value;}
		}

		private int _nLS;
		[Column(Storage = "NLS",Name = "nls")]
		public int NLS{
			get{ return _nLS;}
			set{_nLS = value;}
		}

		private IEnumerable<SortModel> _sortsCreation;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsCreation",OtherKey = "EnchantementObjetModelId")]
		public IEnumerable <SortModel> SortsCreation{
			get{
				if( _sortsCreation == null ){
					_sortsCreation = LoadFromJointure<SortModel,EnchantementObjetModelToSortModel_SortsCreation>(false);
				}
				return _sortsCreation;
			}
			set{
				SaveToJointure<SortModel, EnchantementObjetModelToSortModel_SortsCreation> (_sortsCreation, value,false);
				_sortsCreation = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<EnchantementObjetModel,EnchantementObjetModelToSortModel_SortsCreation>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "enchantementobjetdescription")]
	public abstract partial class EnchantementObjetDescription : DataDescription<EnchantementObjetModel> {
	}
	[Table(Schema = "dd35",Name = "enchantementobjetexemplar")]
	public abstract partial class EnchantementObjetExemplar : DataExemplaire<EnchantementObjetModel> {
	}
}
