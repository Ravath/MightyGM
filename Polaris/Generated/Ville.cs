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
	[Table(Schema = "polaris",Name = "ville")]
	[CoreData]
	public partial class Ville : DataObject {

		private string _nom = "";
		[Column(Storage = "Nom",Name = "nom")]
		public string Nom{
			get{ return _nom;}
			set{_nom = value;}
		}

		private int _population;
		[Column(Storage = "Population",Name = "population")]
		public int Population{
			get{ return _population;}
			set{_population = value;}
		}

		[Column(Name="profondeur_min", Storage="ProfondeurMin")]
		[HiddenProperty]
		public int ProfondeurMin{
			get{
				return Profondeur.Min;
			}
			set{
				Profondeur.Min = value;
			}
		}

		[Column(Name="profondeur_max", Storage="ProfondeurMax")]
		[HiddenProperty]
		public int ProfondeurMax{
			get{
				return Profondeur.Max;
			}
			set{
				Profondeur.Max = value;
			}
		}

		private Range _profondeur = new Range();
		public Range Profondeur{
			get{
				return _profondeur;
			}
			set{
				_profondeur = value;
			}
		}



		private int _popFeconde;
		[Column(Storage = "PopFeconde",Name = "popfeconde")]
		public int PopFeconde{
			get{ return _popFeconde;}
			set{_popFeconde = value;}
		}

		private int _popMutante;
		[Column(Storage = "PopMutante",Name = "popmutante")]
		public int PopMutante{
			get{ return _popMutante;}
			set{_popMutante = value;}
		}

		private IEnumerable<Complexes> _complexes;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Complexes",OtherKey = "VilleId")]
		public IEnumerable <Complexes> Complexes{
			get{
				if( _complexes == null ){
					_complexes = LoadFromJointure<Complexes,VilleToComplexes_Complexes>(false);
				}
				return _complexes;
			}
			set{
				SaveToJointure<Complexes, VilleToComplexes_Complexes> (_complexes, value,false);
				_complexes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<Ville,VilleToComplexes_Complexes>(true);
			base.DeleteObject();
		}
	}
}
