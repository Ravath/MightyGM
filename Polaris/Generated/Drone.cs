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
	[Table(Schema = "polaris",Name = "dronemodel")]
	[CoreData]
	public partial class DroneModel : ObjectModel {

		private DroneDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<DroneDescription> id = GetModelReferencer<DroneDescription>();
					if(id.Count() == 0) {
						_obj = new DroneDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _gabarit;
		[Column(Storage = "Gabarit",Name = "gabarit")]
		public int Gabarit{
			get{ return _gabarit;}
			set{_gabarit = value;}
		}

		private Echelle _echelle;
		[Column(Storage = "Echelle",Name = "echelle")]
		public Echelle Echelle{
			get{ return _echelle;}
			set{_echelle = value;}
		}

		private int _blindage;
		[Column(Storage = "Blindage",Name = "blindage")]
		public int Blindage{
			get{ return _blindage;}
			set{_blindage = value;}
		}

		private int _resistangeDgts;
		[Column(Storage = "ResistangeDgts",Name = "resistangedgts")]
		public int ResistangeDgts{
			get{ return _resistangeDgts;}
			set{_resistangeDgts = value;}
		}

		private int _modIntegrite;
		[Column(Storage = "ModIntegrite",Name = "modintegrite")]
		public int ModIntegrite{
			get{ return _modIntegrite;}
			set{_modIntegrite = value;}
		}

		private int _blindageIEM;
		[Column(Storage = "BlindageIEM",Name = "blindageiem")]
		public int BlindageIEM{
			get{ return _blindageIEM;}
			set{_blindageIEM = value;}
		}

		private int _autonomie;
		[Column(Storage = "Autonomie",Name = "autonomie")]
		public int Autonomie{
			get{ return _autonomie;}
			set{_autonomie = value;}
		}

		private int _profondeurOperationelle;
		[Column(Storage = "ProfondeurOperationelle",Name = "profondeuroperationelle")]
		public int ProfondeurOperationelle{
			get{ return _profondeurOperationelle;}
			set{_profondeurOperationelle = value;}
		}

		private int _vitesse;
		[Column(Storage = "Vitesse",Name = "vitesse")]
		public int Vitesse{
			get{ return _vitesse;}
			set{_vitesse = value;}
		}
	}
	[Table(Schema = "polaris",Name = "dronedescription")]
	public partial class DroneDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "droneexemplar")]
	public partial class DroneExemplar : ObjectExemplar {
	}
}
