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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "abssortmodel")]
	public abstract partial class AbsSortModel : DataModel {

		private ElementSort _element;
		[Column(Storage = "Element",Name = "element")]
		public ElementSort Element{
			get{ return _element;}
			set{_element = value;}
		}

		private int _maitrise;
		[Column(Storage = "Maitrise",Name = "maitrise")]
		public int Maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}

		private Portee _portee;
		[Column(Storage = "Portee",Name = "portee")]
		public Portee Portee{
			get{ return _portee;}
			set{_portee = value;}
		}

		private ZoneEffet _zoneEffet;
		[Column(Storage = "ZoneEffet",Name = "zoneeffet")]
		public ZoneEffet ZoneEffet{
			get{ return _zoneEffet;}
			set{_zoneEffet = value;}
		}

		private Duree _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public Duree Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private decimal _facteurPortee;
		[Column(Storage = "FacteurPortee",Name = "facteurportee")]
		public decimal FacteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private decimal _facteurZone;
		[Column(Storage = "FacteurZone",Name = "facteurzone")]
		public decimal FacteurZone{
			get{ return _facteurZone;}
			set{_facteurZone = value;}
		}

		private decimal _facteurDuree;
		[Column(Storage = "FacteurDuree",Name = "facteurduree")]
		public decimal FacteurDuree{
			get{ return _facteurDuree;}
			set{_facteurDuree = value;}
		}

		private bool _porteeXRang;
		[Column(Storage = "PorteeXRang",Name = "porteexrang")]
		public bool PorteeXRang{
			get{ return _porteeXRang;}
			set{_porteeXRang = value;}
		}

		private bool _zoneXRang;
		[Column(Storage = "ZoneXRang",Name = "zonexrang")]
		public bool ZoneXRang{
			get{ return _zoneXRang;}
			set{_zoneXRang = value;}
		}

		private bool _dureeXRang;
		[Column(Storage = "DureeXRang",Name = "dureexrang")]
		public bool DureeXRang{
			get{ return _dureeXRang;}
			set{_dureeXRang = value;}
		}

		private IEnumerable<AugmentationSort> _augmentations;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Augmentations",OtherKey = "AbsSortModelId")]
		public IEnumerable <AugmentationSort> Augmentations{
			get{
				if( _augmentations == null ){
					_augmentations = LoadFromJointure<AugmentationSort,AbsSortModelToAugmentationSort_Augmentations>(false);
				}
				return _augmentations;
			}
			set{
				SaveToJointure<AugmentationSort, AbsSortModelToAugmentationSort_Augmentations> (_augmentations, value,false);
				_augmentations = value;
			}
		}


		private IEnumerable < MotClefSort > _motClefs;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "MotClefs",OtherKey = "AbsSortModel")]
		public IEnumerable <MotClefSort> MotClefs{
			get{
				if( _motClefs == null ){
					_motClefs = LoadFromDataValue<MotClefsFromAbsSortModel, MotClefSort>();
				}
				return _motClefs;
			}
			set{
				SaveDataValue<MotClefsFromAbsSortModel, MotClefSort>(_motClefs, value);
			}
		}

		private bool _concentration;
		[Column(Storage = "Concentration",Name = "concentration")]
		public bool Concentration{
			get{ return _concentration;}
			set{_concentration = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsSortModel,AbsSortModelToAugmentationSort_Augmentations>(true);
			DeleteDataValue<MotClefsFromAbsSortModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "abssortdescription")]
	public abstract partial class AbsSortDescription : DataDescription<AbsSortModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "abssortexemplar")]
	public abstract partial class AbsSortExemplar : DataExemplaire<AbsSortModel> {
	}
}
