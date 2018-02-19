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
	[Table(Schema = "pathfinder",Name = "enchantementobjetmodel")]
	public abstract partial class EnchantementObjetModel : DataModel {

		private int _alteration;
		[Column(Storage = "Alteration",Name = "alteration")]
		public int Alteration{
			get{ return _alteration;}
			set{_alteration = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
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

		private IEnumerable<RequisExemplar> _requisPort;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "RequisPort",OtherKey = "EnchantementObjetModelId")]
		public IEnumerable <RequisExemplar> RequisPort{
			get{
				if( _requisPort == null ){
					_requisPort = LoadFromJointure<RequisExemplar,EnchantementObjetModelToRequisExemplar_RequisPort>(false);
				}
				return _requisPort;
			}
			set{
				SaveToJointure<RequisExemplar, EnchantementObjetModelToRequisExemplar_RequisPort> (_requisPort, value,false);
				_requisPort = value;
			}
		}

		private IEnumerable<RequisExemplar> _requisCreation;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "RequisCreation",OtherKey = "EnchantementObjetModelId")]
		public IEnumerable <RequisExemplar> RequisCreation{
			get{
				if( _requisCreation == null ){
					_requisCreation = LoadFromJointure<RequisExemplar,EnchantementObjetModelToRequisExemplar_RequisCreation>(false);
				}
				return _requisCreation;
			}
			set{
				SaveToJointure<RequisExemplar, EnchantementObjetModelToRequisExemplar_RequisCreation> (_requisCreation, value,false);
				_requisCreation = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<EnchantementObjetModel,EnchantementObjetModelToSortModel_SortsCreation>(true);
			DeleteJoins<EnchantementObjetModel,EnchantementObjetModelToRequisExemplar_RequisPort>(true);
			DeleteJoins<EnchantementObjetModel,EnchantementObjetModelToRequisExemplar_RequisCreation>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "enchantementobjetdescription")]
	public abstract partial class EnchantementObjetDescription : DataDescription<EnchantementObjetModel> {
	}
	[Table(Schema = "pathfinder",Name = "enchantementobjetexemplar")]
	public abstract partial class EnchantementObjetExemplar : DataExemplaire<EnchantementObjetModel> {

		private string _value = "";
		[Column(Storage = "Value",Name = "value")]
		public string Value{
			get{ return _value;}
			set{_value = value;}
		}
	}
}
