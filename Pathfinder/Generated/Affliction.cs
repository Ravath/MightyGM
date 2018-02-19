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
	[Table(Schema = "pathfinder",Name = "afflictionmodel")]
	[CoreData]
	public partial class AfflictionModel : DataModel {

		private AfflictionDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AfflictionDescription> id = GetModelReferencer<AfflictionDescription>();
					if(id.Count() == 0) {
						_obj = new AfflictionDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeAffliction _typeAffliction;
		[Column(Storage = "TypeAffliction",Name = "typeaffliction")]
		public TypeAffliction TypeAffliction{
			get{ return _typeAffliction;}
			set{_typeAffliction = value;}
		}

		private bool _blessure;
		[Column(Storage = "Blessure",Name = "blessure")]
		public bool Blessure{
			get{ return _blessure;}
			set{_blessure = value;}
		}

		private bool _contact;
		[Column(Storage = "Contact",Name = "contact")]
		public bool Contact{
			get{ return _contact;}
			set{_contact = value;}
		}

		private bool _ingestion;
		[Column(Storage = "Ingestion",Name = "ingestion")]
		public bool Ingestion{
			get{ return _ingestion;}
			set{_ingestion = value;}
		}

		private bool _inhalation;
		[Column(Storage = "Inhalation",Name = "inhalation")]
		public bool Inhalation{
			get{ return _inhalation;}
			set{_inhalation = value;}
		}

		private bool _piege;
		[Column(Storage = "Piege",Name = "piege")]
		public bool Piege{
			get{ return _piege;}
			set{_piege = value;}
		}

		private bool _sort;
		[Column(Storage = "Sort",Name = "sort")]
		public bool Sort{
			get{ return _sort;}
			set{_sort = value;}
		}

		private int _dD;
		[Column(Storage = "DD",Name = "dd")]
		public int DD{
			get{ return _dD;}
			set{_dD = value;}
		}

		private Sauvegarde _jetSauvegarde;
		[Column(Storage = "JetSauvegarde",Name = "jetsauvegarde")]
		public Sauvegarde JetSauvegarde{
			get{ return _jetSauvegarde;}
			set{_jetSauvegarde = value;}
		}

		private int _facteurFrequence;
		[Column(Storage = "FacteurFrequence",Name = "facteurfrequence")]
		public int FacteurFrequence{
			get{ return _facteurFrequence;}
			set{_facteurFrequence = value;}
		}

		private DureeSort _frequence;
		[Column(Storage = "Frequence",Name = "frequence")]
		public DureeSort Frequence{
			get{ return _frequence;}
			set{_frequence = value;}
		}

		private int _facteurIncubation;
		[Column(Storage = "FacteurIncubation",Name = "facteurincubation")]
		public int FacteurIncubation{
			get{ return _facteurIncubation;}
			set{_facteurIncubation = value;}
		}

		private DureeSort _incubation;
		[Column(Storage = "Incubation",Name = "incubation")]
		public DureeSort Incubation{
			get{ return _incubation;}
			set{_incubation = value;}
		}

		private int _facteurDureeMax;
		[Column(Storage = "FacteurDureeMax",Name = "facteurdureemax")]
		public int FacteurDureeMax{
			get{ return _facteurDureeMax;}
			set{_facteurDureeMax = value;}
		}

		private DureeSort _dureeMax;
		[Column(Storage = "DureeMax",Name = "dureemax")]
		public DureeSort DureeMax{
			get{ return _dureeMax;}
			set{_dureeMax = value;}
		}

		private int _guerisonJSConsecutifs;
		[Column(Storage = "GuerisonJSConsecutifs",Name = "guerisonjsconsecutifs")]
		public int GuerisonJSConsecutifs{
			get{ return _guerisonJSConsecutifs;}
			set{_guerisonJSConsecutifs = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "afflictiondescription")]
	public partial class AfflictionDescription : DataDescription<AfflictionModel> {
	}
	[Table(Schema = "pathfinder",Name = "afflictionexemplar")]
	public partial class AfflictionExemplar : DataExemplaire<AfflictionModel> {

		private int _tour;
		[Column(Storage = "Tour",Name = "tour")]
		public int Tour{
			get{ return _tour;}
			set{_tour = value;}
		}
	}
}
