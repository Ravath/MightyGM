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
	[Table(Schema = "polaris",Name = "pouvoirpolarismodel")]
	[CoreData]
	public partial class PouvoirPolarisModel : DataModel {

		private PouvoirPolarisDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PouvoirPolarisDescription> id = GetModelReferencer<PouvoirPolarisDescription>();
					if(id.Count() == 0) {
						_obj = new PouvoirPolarisDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _zoneEffet;
		[Column(Storage = "ZoneEffet",Name = "zoneeffet")]
		public int ZoneEffet{
			get{ return _zoneEffet;}
			set{_zoneEffet = value;}
		}

		private int _porteeMax;
		[Column(Storage = "PorteeMax",Name = "porteemax")]
		public int PorteeMax{
			get{ return _porteeMax;}
			set{_porteeMax = value;}
		}

		[Column(Name = "duree_val", Storage="DureeVal")]
		public int DureeVal{
			get{
				return Duree.Value;
			}
			set{
				Duree.Value = value;
			}
		}

		[Column(Name = "duree_unit", Storage="DureeUnit")]
		public TimeUnity DureeUnit{
			get{
				return Duree.Unity;
			}
			set{
				Duree.Unity = value;
			}
		}

		private TimePeriod _duree = new TimePeriod();
		[HiddenProperty]
		public TimePeriod Duree{
			get{
				return _duree;
			}
			set{
				_duree = value;
			}
		}



		private int _autre;
		[Column(Storage = "Autre",Name = "autre")]
		public int Autre{
			get{ return _autre;}
			set{_autre = value;}
		}

		private int _nbrDDgts;
		[Column(Storage = "nbrDDgts",Name = "nbrddgts")]
		public int nbrDDgts{
			get{ return _nbrDDgts;}
			set{_nbrDDgts = value;}
		}

		private int _bonusDgts;
		[Column(Storage = "BonusDgts",Name = "bonusdgts")]
		public int BonusDgts{
			get{ return _bonusDgts;}
			set{_bonusDgts = value;}
		}

		private bool _d6Dgts;
		[Column(Storage = "D6Dgts",Name = "d6dgts")]
		public bool D6Dgts{
			get{ return _d6Dgts;}
			set{_d6Dgts = value;}
		}

		private int _nombreLocalisations;
		[Column(Storage = "NombreLocalisations",Name = "nombrelocalisations")]
		public int NombreLocalisations{
			get{ return _nombreLocalisations;}
			set{_nombreLocalisations = value;}
		}
	}
	[Table(Schema = "polaris",Name = "pouvoirpolarisdescription")]
	public partial class PouvoirPolarisDescription : DataDescription<PouvoirPolarisModel> {
	}
	[Table(Schema = "polaris",Name = "pouvoirpolarisexemplar")]
	public partial class PouvoirPolarisExemplar : DataExemplaire<PouvoirPolarisModel> {
	}
}
