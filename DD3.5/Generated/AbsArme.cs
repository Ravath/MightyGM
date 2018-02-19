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
namespace DD3_5.Data {
	[Table(Schema = "dd35",Name = "absarmemodel")]
	public abstract partial class AbsArmeModel : ObjetModel {

		private int _nbrDDegats;
		[Column(Storage = "nbrDDegats",Name = "nbrddegats")]
		public int nbrDDegats{
			get{ return _nbrDDegats;}
			set{_nbrDDegats = value;}
		}

		private int _tailleDDegats;
		[Column(Storage = "TailleDDegats",Name = "tailleddegats")]
		public int TailleDDegats{
			get{ return _tailleDDegats;}
			set{_tailleDDegats = value;}
		}

		private int _facteurCritique;
		[Column(Storage = "FacteurCritique",Name = "facteurcritique")]
		public int FacteurCritique{
			get{ return _facteurCritique;}
			set{_facteurCritique = value;}
		}

		private int _zoneCritique;
		[Column(Storage = "ZoneCritique",Name = "zonecritique")]
		public int ZoneCritique{
			get{ return _zoneCritique;}
			set{_zoneCritique = value;}
		}

		private bool _allonge;
		[Column(Storage = "Allonge",Name = "allonge")]
		public bool Allonge{
			get{ return _allonge;}
			set{_allonge = value;}
		}

		private bool _degatsNonLetaux;
		[Column(Storage = "DegatsNonLetaux",Name = "degatsnonletaux")]
		public bool DegatsNonLetaux{
			get{ return _degatsNonLetaux;}
			set{_degatsNonLetaux = value;}
		}

		private TypeDegatArme _typeDegat;
		[Column(Storage = "TypeDegat",Name = "typedegat")]
		public TypeDegatArme TypeDegat{
			get{ return _typeDegat;}
			set{_typeDegat = value;}
		}

		private TypeDegatArme? _typeDegatComplementaire;
		[Column(Storage = "TypeDegatComplementaire",Name = "typedegatcomplementaire")]
		public TypeDegatArme? TypeDegatComplementaire{
			get{ return _typeDegatComplementaire;}
			set{_typeDegatComplementaire = value;}
		}

		private bool _typeDegatCplIsAlternative;
		[Column(Storage = "TypeDegatCplIsAlternative",Name = "typedegatcplisalternative")]
		public bool TypeDegatCplIsAlternative{
			get{ return _typeDegatCplIsAlternative;}
			set{_typeDegatCplIsAlternative = value;}
		}

		private IEnumerable<SpecialArmeModel> _specialArme;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SpecialArme",OtherKey = "AbsArmeModelId")]
		public IEnumerable <SpecialArmeModel> SpecialArme{
			get{
				if( _specialArme == null ){
					_specialArme = LoadFromJointure<SpecialArmeModel,AbsArmeModelToSpecialArmeModel_SpecialArme>(false);
				}
				return _specialArme;
			}
			set{
				SaveToJointure<SpecialArmeModel, AbsArmeModelToSpecialArmeModel_SpecialArme> (_specialArme, value,false);
				_specialArme = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<AbsArmeModel,AbsArmeModelToSpecialArmeModel_SpecialArme>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "absarmedescription")]
	public abstract partial class AbsArmeDescription : ObjetDescription {
	}
	[Table(Schema = "dd35",Name = "absarmeexemplar")]
	public abstract partial class AbsArmeExemplar : ObjetExemplar {
	}
}
