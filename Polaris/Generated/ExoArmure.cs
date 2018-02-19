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
	[Table(Schema = "polaris",Name = "exoarmuremodel")]
	[CoreData]
	public partial class ExoArmureModel : ObjectModel {

		private ExoArmureDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ExoArmureDescription> id = GetModelReferencer<ExoArmureDescription>();
					if(id.Count() == 0) {
						_obj = new ExoArmureDescription();
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

		private Echelle _echelle;
		[Column(Storage = "Echelle",Name = "echelle")]
		public Echelle Echelle{
			get{ return _echelle;}
			set{_echelle = value;}
		}

		private CategorieExoarmure _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieExoarmure Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private TypeExoarmure _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeExoarmure Type{
			get{ return _type;}
			set{_type = value;}
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

		private int _resistanceDommages;
		[Column(Storage = "ResistanceDommages",Name = "resistancedommages")]
		public int ResistanceDommages{
			get{ return _resistanceDommages;}
			set{_resistanceDommages = value;}
		}

		private int _blindage;
		[Column(Storage = "Blindage",Name = "blindage")]
		public int Blindage{
			get{ return _blindage;}
			set{_blindage = value;}
		}

		private ArchetectureExoarmure _architecture;
		[Column(Storage = "Architecture",Name = "architecture")]
		public ArchetectureExoarmure Architecture{
			get{ return _architecture;}
			set{_architecture = value;}
		}

		private int _modIntegrite;
		[Column(Storage = "ModIntegrite",Name = "modintegrite")]
		public int ModIntegrite{
			get{ return _modIntegrite;}
			set{_modIntegrite = value;}
		}

		private int _exoForce;
		[Column(Storage = "ExoForce",Name = "exoforce")]
		public int ExoForce{
			get{ return _exoForce;}
			set{_exoForce = value;}
		}

		private int _modDommages;
		[Column(Storage = "ModDommages",Name = "moddommages")]
		public int ModDommages{
			get{ return _modDommages;}
			set{_modDommages = value;}
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

		private int _initSsEau;
		[Column(Storage = "InitSsEau",Name = "initsseau")]
		public int InitSsEau{
			get{ return _initSsEau;}
			set{_initSsEau = value;}
		}

		private int _initATerre;
		[Column(Storage = "InitATerre",Name = "initaterre")]
		public int InitATerre{
			get{ return _initATerre;}
			set{_initATerre = value;}
		}
	}
	[Table(Schema = "polaris",Name = "exoarmuredescription")]
	public partial class ExoArmureDescription : ObjectDescription {
	}
	[Table(Schema = "polaris",Name = "exoarmureexemplar")]
	public partial class ExoArmureExemplar : ObjectExemplar {
	}
}
