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
	[Table(Schema = "polaris",Name = "vehiculemodel")]
	[CoreData]
	public partial class VehiculeModel : ObjectModel {

		private VehiculeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VehiculeDescription> id = GetModelReferencer<VehiculeDescription>();
					if(id.Count() == 0) {
						_obj = new VehiculeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private Echelle _echelle;
		[Column(Storage = "Echelle",Name = "echelle")]
		public Echelle Echelle{
			get{ return _echelle;}
			set{_echelle = value;}
		}

		private int _longueur;
		[Column(Storage = "Longueur",Name = "longueur")]
		public int Longueur{
			get{ return _longueur;}
			set{_longueur = value;}
		}

		private int _diametre;
		[Column(Storage = "Diametre",Name = "diametre")]
		public int Diametre{
			get{ return _diametre;}
			set{_diametre = value;}
		}

		private int _equipage;
		[Column(Storage = "Equipage",Name = "equipage")]
		public int Equipage{
			get{ return _equipage;}
			set{_equipage = value;}
		}

		private int _passagers;
		[Column(Storage = "Passagers",Name = "passagers")]
		public int Passagers{
			get{ return _passagers;}
			set{_passagers = value;}
		}

		private int _poidsFret;
		[Column(Storage = "PoidsFret",Name = "poidsfret")]
		public int PoidsFret{
			get{ return _poidsFret;}
			set{_poidsFret = value;}
		}

		private int _volumeFret;
		[Column(Storage = "VolumeFret",Name = "volumefret")]
		public int VolumeFret{
			get{ return _volumeFret;}
			set{_volumeFret = value;}
		}

		private int _profOperationelle;
		[Column(Storage = "ProfOperationelle",Name = "profoperationelle")]
		public int ProfOperationelle{
			get{ return _profOperationelle;}
			set{_profOperationelle = value;}
		}

		private int _profLimite;
		[Column(Storage = "ProfLimite",Name = "proflimite")]
		public int ProfLimite{
			get{ return _profLimite;}
			set{_profLimite = value;}
		}

		private int _profEcrasement;
		[Column(Storage = "ProfEcrasement",Name = "profecrasement")]
		public int ProfEcrasement{
			get{ return _profEcrasement;}
			set{_profEcrasement = value;}
		}

		private int _autonomie;
		[Column(Storage = "Autonomie",Name = "autonomie")]
		public int Autonomie{
			get{ return _autonomie;}
			set{_autonomie = value;}
		}

		private int _gabarit;
		[Column(Storage = "Gabarit",Name = "gabarit")]
		public int Gabarit{
			get{ return _gabarit;}
			set{_gabarit = value;}
		}

		private int _resistanceDommages;
		[Column(Storage = "ResistanceDommages",Name = "resistancedommages")]
		public int ResistanceDommages{
			get{ return _resistanceDommages;}
			set{_resistanceDommages = value;}
		}

		private ArchitectureExoarmure _architecture;
		[Column(Storage = "Architecture",Name = "architecture")]
		public ArchitectureExoarmure Architecture{
			get{ return _architecture;}
			set{_architecture = value;}
		}

		private int _modIntegrite;
		[Column(Storage = "ModIntegrite",Name = "modintegrite")]
		public int ModIntegrite{
			get{ return _modIntegrite;}
			set{_modIntegrite = value;}
		}

		private int _blindage;
		[Column(Storage = "Blindage",Name = "blindage")]
		public int Blindage{
			get{ return _blindage;}
			set{_blindage = value;}
		}

		private int _manoeuvrabilite;
		[Column(Storage = "Manoeuvrabilite",Name = "manoeuvrabilite")]
		public int Manoeuvrabilite{
			get{ return _manoeuvrabilite;}
			set{_manoeuvrabilite = value;}
		}

		private int _vitesse;
		[Column(Storage = "Vitesse",Name = "vitesse")]
		public int Vitesse{
			get{ return _vitesse;}
			set{_vitesse = value;}
		}

		private int _vIT;
		[Column(Storage = "VIT",Name = "vit")]
		public int VIT{
			get{ return _vIT;}
			set{_vIT = value;}
		}

		private int _ponts;
		[Column(Storage = "Ponts",Name = "ponts")]
		public int Ponts{
			get{ return _ponts;}
			set{_ponts = value;}
		}

		private int _cloisonsEtanches;
		[Column(Storage = "CloisonsEtanches",Name = "cloisonsetanches")]
		public int CloisonsEtanches{
			get{ return _cloisonsEtanches;}
			set{_cloisonsEtanches = value;}
		}

		private int _ecoutilles;
		[Column(Storage = "Ecoutilles",Name = "ecoutilles")]
		public int Ecoutilles{
			get{ return _ecoutilles;}
			set{_ecoutilles = value;}
		}

		private int _portesExternes;
		[Column(Storage = "PortesExternes",Name = "portesexternes")]
		public int PortesExternes{
			get{ return _portesExternes;}
			set{_portesExternes = value;}
		}
	}
	[Table(Schema = "polaris",Name = "vehiculedescription")]
	public partial class VehiculeDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "vehiculeexemplar")]
	public partial class VehiculeExemplar : ObjectExemplar {
	}
}
