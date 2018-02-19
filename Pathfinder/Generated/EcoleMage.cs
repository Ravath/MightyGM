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
	[Table(Schema = "pathfinder",Name = "ecolemagemodel")]
	[CoreData]
	public partial class EcoleMageModel : PouvoirSpecialModel {

		private EcoleMageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<EcoleMageDescription> id = GetModelReferencer<EcoleMageDescription>();
					if(id.Count() == 0) {
						_obj = new EcoleMageDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _capacite1Id;
		[Column(Storage = "Capacite1Id",Name = "fk_pouvoirspecialmodel_capacite1")]
		[HiddenProperty]
		public int Capacite1Id{
			get{ return _capacite1Id;}
			set{_capacite1Id = value;}
		}

		private PouvoirSpecialModel _capacite1;
		public PouvoirSpecialModel Capacite1{
			get{
				if( _capacite1 == null)
					_capacite1 = LoadById<PouvoirSpecialModel>(Capacite1Id);
				return _capacite1;
			} set {
				if(_capacite1 == value){return;}
				_capacite1 = value;
				if( value != null)
					Capacite1Id = value.Id;
			}
		}

		private int _capacite2Id;
		[Column(Storage = "Capacite2Id",Name = "fk_pouvoirspecialmodel_capacite2")]
		[HiddenProperty]
		public int Capacite2Id{
			get{ return _capacite2Id;}
			set{_capacite2Id = value;}
		}

		private PouvoirSpecialModel _capacite2;
		public PouvoirSpecialModel Capacite2{
			get{
				if( _capacite2 == null)
					_capacite2 = LoadById<PouvoirSpecialModel>(Capacite2Id);
				return _capacite2;
			} set {
				if(_capacite2 == value){return;}
				_capacite2 = value;
				if( value != null)
					Capacite2Id = value.Id;
			}
		}

		private int _capaciteLvl8Id;
		[Column(Storage = "CapaciteLvl8Id",Name = "fk_pouvoirspecialmodel_capacitelvl8")]
		[HiddenProperty]
		public int CapaciteLvl8Id{
			get{ return _capaciteLvl8Id;}
			set{_capaciteLvl8Id = value;}
		}

		private PouvoirSpecialModel _capaciteLvl8;
		public PouvoirSpecialModel CapaciteLvl8{
			get{
				if( _capaciteLvl8 == null)
					_capaciteLvl8 = LoadById<PouvoirSpecialModel>(CapaciteLvl8Id);
				return _capaciteLvl8;
			} set {
				if(_capaciteLvl8 == value){return;}
				_capaciteLvl8 = value;
				if( value != null)
					CapaciteLvl8Id = value.Id;
			}
		}
	}
	[Table(Schema = "pathfinder",Name = "ecolemagedescription")]
	public partial class EcoleMageDescription : PouvoirSpecialDescription {
	}
	[Table(Schema = "pathfinder",Name = "ecolemageexemplar")]
	public partial class EcoleMageExemplar : PouvoirSpecialExemplar {
	}
}
