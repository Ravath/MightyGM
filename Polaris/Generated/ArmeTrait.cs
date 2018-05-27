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
	[Table(Schema = "polaris",Name = "armetraitmodel")]
	[CoreData]
	public partial class ArmeTraitModel : ObjectModel {

		private ArmeTraitDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeTraitDescription> id = GetModelReferencer<ArmeTraitDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeTraitDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nbrDDegats;
		[Column(Storage = "nbrDDegats",Name = "nbrddegats")]
		public int nbrDDegats{
			get{ return _nbrDDegats;}
			set{_nbrDDegats = value;}
		}

		private bool _dgtsD6;
		[Column(Storage = "dgtsD6",Name = "dgtsd6")]
		public bool dgtsD6{
			get{ return _dgtsD6;}
			set{_dgtsD6 = value;}
		}

		private int _plus;
		[Column(Storage = "Plus",Name = "plus")]
		public int Plus{
			get{ return _plus;}
			set{_plus = value;}
		}

		private int _penalite;
		[Column(Storage = "Penalite",Name = "penalite")]
		public int Penalite{
			get{ return _penalite;}
			set{_penalite = value;}
		}

		private int _force;
		[Column(Storage = "Force",Name = "force")]
		public int Force{
			get{ return _force;}
			set{_force = value;}
		}

		private int _init;
		[Column(Storage = "Init",Name = "init")]
		public int Init{
			get{ return _init;}
			set{_init = value;}
		}

		private int _allonge;
		[Column(Storage = "Allonge",Name = "allonge")]
		public int Allonge{
			get{ return _allonge;}
			set{_allonge = value;}
		}

		private int _munitions;
		[Column(Storage = "Munitions",Name = "munitions")]
		public int Munitions{
			get{ return _munitions;}
			set{_munitions = value;}
		}

		private int _coutMunitions;
		[Column(Storage = "CoutMunitions",Name = "coutmunitions")]
		public int CoutMunitions{
			get{ return _coutMunitions;}
			set{_coutMunitions = value;}
		}

		private bool _chargeHoraire;
		[Column(Storage = "ChargeHoraire",Name = "chargehoraire")]
		public bool ChargeHoraire{
			get{ return _chargeHoraire;}
			set{_chargeHoraire = value;}
		}

		private int _porteePortant;
		[Column(Storage = "PorteePortant",Name = "porteeportant")]
		public int PorteePortant{
			get{ return _porteePortant;}
			set{_porteePortant = value;}
		}

		private int _porteeCourte;
		[Column(Storage = "PorteeCourte",Name = "porteecourte")]
		public int PorteeCourte{
			get{ return _porteeCourte;}
			set{_porteeCourte = value;}
		}

		private int _porteeMoyenne;
		[Column(Storage = "PorteeMoyenne",Name = "porteemoyenne")]
		public int PorteeMoyenne{
			get{ return _porteeMoyenne;}
			set{_porteeMoyenne = value;}
		}

		private int _porteeLongue;
		[Column(Storage = "PorteeLongue",Name = "porteelongue")]
		public int PorteeLongue{
			get{ return _porteeLongue;}
			set{_porteeLongue = value;}
		}

		private int _porteeExtreme;
		[Column(Storage = "PorteeExtreme",Name = "porteeextreme")]
		public int PorteeExtreme{
			get{ return _porteeExtreme;}
			set{_porteeExtreme = value;}
		}

		private ModeTir _modeTir;
		[Column(Storage = "ModeTir",Name = "modetir")]
		public ModeTir ModeTir{
			get{ return _modeTir;}
			set{_modeTir = value;}
		}
	}
	[Table(Schema = "polaris",Name = "armetraitdescription")]
	public partial class ArmeTraitDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "armetraitexemplar")]
	public partial class ArmeTraitExemplar : ObjectExemplar {
	}
}
