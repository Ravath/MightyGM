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
namespace Yggdrasil.Data {
	[Table(Schema = "yggdrasil",Name = "sortsejdrmodel")]
	[CoreData]
	public partial class SortSejdrModel : DataModel {

		private SortSejdrDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortSejdrDescription> id = GetModelReferencer<SortSejdrDescription>();
					if(id.Count() == 0) {
						_obj = new SortSejdrDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _categorieId;
		[Column(Storage = "CategorieId",Name = "fk_domainesejdrmodel_categorie")]
		[HiddenProperty]
		public int CategorieId{
			get{ return _categorieId;}
			set{_categorieId = value;}
		}

		private DomaineSejdrModel _categorie;
		public DomaineSejdrModel Categorie{
			get{
				if( _categorie == null)
					_categorie = LoadById<DomaineSejdrModel>(CategorieId);
				return _categorie;
			} set {
				if(_categorie == value){return;}
				_categorie = value;
				if( value != null)
					CategorieId = value.Id;
			}
		}

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}

		private int _malus;
		[Column(Storage = "Malus",Name = "malus")]
		public int Malus{
			get{ return _malus;}
			set{_malus = value;}
		}

		[Column(Name = "incantation_val", Storage="IncantationVal")]
		public int IncantationVal{
			get{
				return Incantation.Value;
			}
			set{
				Incantation.Value = value;
			}
		}

		[Column(Name = "incantation_unit", Storage="IncantationUnit")]
		public DureeSort IncantationUnit{
			get{
				return Incantation.Unity;
			}
			set{
				Incantation.Unity = value;
			}
		}

		private UnitValue<int,DureeSort> _incantation = new UnitValue<int,DureeSort>();
		[HiddenProperty]
		public UnitValue<int,DureeSort> Incantation{
			get{
				return _incantation;
			}
			set{
				_incantation = value;
			}
		}



		[Column(Name = "dureeeffet_val", Storage="DureeEffetVal")]
		public int DureeEffetVal{
			get{
				return DureeEffet.Value;
			}
			set{
				DureeEffet.Value = value;
			}
		}

		[Column(Name = "dureeeffet_unit", Storage="DureeEffetUnit")]
		public DureeSort DureeEffetUnit{
			get{
				return DureeEffet.Unity;
			}
			set{
				DureeEffet.Unity = value;
			}
		}

		private UnitValue<int,DureeSort> _dureeEffet = new UnitValue<int,DureeSort>();
		[HiddenProperty]
		public UnitValue<int,DureeSort> DureeEffet{
			get{
				return _dureeEffet;
			}
			set{
				_dureeEffet = value;
			}
		}



		private string _zoneEffet = "";
		[LargeText]
		[Column(Storage = "ZoneEffet",Name = "zoneeffet")]
		public string ZoneEffet{
			get{ return _zoneEffet;}
			set{_zoneEffet = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "sortsejdrdescription")]
	public partial class SortSejdrDescription : DataDescription<SortSejdrModel> {

		private string _effetNegatif = "";
		[LargeText]
		[Column(Storage = "EffetNegatif",Name = "effetnegatif")]
		public string EffetNegatif{
			get{ return _effetNegatif;}
			set{_effetNegatif = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "sortsejdrexemplar")]
	public partial class SortSejdrExemplar : DataExemplaire<SortSejdrModel> {
	}
}
