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
	[Table(Schema = "polaris",Name = "abscompetencemodel")]
	public abstract partial class AbsCompetenceModel : DataModel {

		private AcquisitionCompetence _acquisition;
		[Column(Storage = "Acquisition",Name = "acquisition")]
		public AcquisitionCompetence Acquisition{
			get{ return _acquisition;}
			set{_acquisition = value;}
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

		private IEnumerable<CompetenceExemplar> _prerequis;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Prerequis",OtherKey = "AbsCompetenceModelId")]
		public IEnumerable <CompetenceExemplar> Prerequis{
			get{
				if( _prerequis == null ){
					_prerequis = LoadFromJointure<CompetenceExemplar,AbsCompetenceModelToCompetenceExemplar_Prerequis>(false);
				}
				return _prerequis;
			}
			set{
				SaveToJointure<CompetenceExemplar, AbsCompetenceModelToCompetenceExemplar_Prerequis> (_prerequis, value,false);
				_prerequis = value;
			}
		}

		private bool _attributsVariables;
		[Column(Storage = "AttributsVariables",Name = "attributsvariables")]
		public bool AttributsVariables{
			get{ return _attributsVariables;}
			set{_attributsVariables = value;}
		}

		private CategorieCompetence _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieCompetence Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
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
		public override void DeleteObject() {
			DeleteJoins<AbsCompetenceModel,AbsCompetenceModelToCompetenceExemplar_Prerequis>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "abscompetencedescription")]
	public abstract partial class AbsCompetenceDescription : DataDescription<AbsCompetenceModel> {
	}
	[Table(Schema = "polaris",Name = "abscompetenceexemplar")]
	public abstract partial class AbsCompetenceExemplar : DataExemplaire<AbsCompetenceModel> {

		private int _rang;
		[Column(Storage = "Rang",Name = "rang")]
		public int Rang{
			get{ return _rang;}
			set{_rang = value;}
		}
	}
}
