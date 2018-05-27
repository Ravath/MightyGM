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
	[Table(Schema = "polaris",Name = "competencemodel")]
	[CoreData]
	public partial class CompetenceModel : DataModel {

		private CompetenceDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CompetenceDescription> id = GetModelReferencer<CompetenceDescription>();
					if(id.Count() == 0) {
						_obj = new CompetenceDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _reservee;
		[Column(Storage = "Reservee",Name = "reservee")]
		public bool Reservee{
			get{ return _reservee;}
			set{_reservee = value;}
		}

		private bool _limitative;
		[Column(Storage = "Limitative",Name = "limitative")]
		public bool Limitative{
			get{ return _limitative;}
			set{_limitative = value;}
		}

		private bool _progNaturelle;
		[Column(Storage = "ProgNaturelle",Name = "prognaturelle")]
		public bool ProgNaturelle{
			get{ return _progNaturelle;}
			set{_progNaturelle = value;}
		}

		private bool _prerequis;
		[Column(Storage = "Prerequis",Name = "prerequis")]
		public bool Prerequis{
			get{ return _prerequis;}
			set{_prerequis = value;}
		}

		private bool _generale;
		[Column(Storage = "Generale",Name = "generale")]
		public bool Generale{
			get{ return _generale;}
			set{_generale = value;}
		}

		private bool _attributsVariables;
		[Column(Storage = "AttributsVariables",Name = "attributsvariables")]
		public bool AttributsVariables{
			get{ return _attributsVariables;}
			set{_attributsVariables = value;}
		}

		private Caracteristique _caracteristiqueI;
		[Column(Storage = "CaracteristiqueI",Name = "caracteristiquei")]
		public Caracteristique CaracteristiqueI{
			get{ return _caracteristiqueI;}
			set{_caracteristiqueI = value;}
		}

		private Caracteristique _caracteristiqueII;
		[Column(Storage = "CaracteristiqueII",Name = "caracteristiqueii")]
		public Caracteristique CaracteristiqueII{
			get{ return _caracteristiqueII;}
			set{_caracteristiqueII = value;}
		}

		private IEnumerable<Specialite> _specialites;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Specialites",OtherKey = "CompetenceModelId")]
		public IEnumerable <Specialite> Specialites{
			get{
				if( _specialites == null ){
					_specialites = LoadFromJointure<Specialite,CompetenceModelToSpecialite_Specialites>(false);
				}
				return _specialites;
			}
			set{
				SaveToJointure<Specialite, CompetenceModelToSpecialite_Specialites> (_specialites, value,false);
				_specialites = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<CompetenceModel,CompetenceModelToSpecialite_Specialites>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "competencedescription")]
	public partial class CompetenceDescription : DataDescription<CompetenceModel> {
	}
	[Table(Schema = "polaris",Name = "competenceexemplar")]
	public partial class CompetenceExemplar : DataExemplaire<CompetenceModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}

		private int _specialiteId;
		[Column(Storage = "SpecialiteId",Name = "fk_specialite_specialite")]
		[HiddenProperty]
		public int SpecialiteId{
			get{ return _specialiteId;}
			set{_specialiteId = value;}
		}

		private Specialite _specialite;
		public Specialite Specialite{
			get{
				if( _specialite == null)
					_specialite = LoadById<Specialite>(SpecialiteId);
				return _specialite;
			} set {
				if(_specialite == value){return;}
				_specialite = value;
				if( value != null)
					SpecialiteId = value.Id;
			}
		}
	}
}
