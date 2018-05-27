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
	[Table(Schema = "polaris",Name = "villemodel")]
	[CoreData]
	public partial class VilleModel : DataModel {

		private VilleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<VilleDescription> id = GetModelReferencer<VilleDescription>();
					if(id.Count() == 0) {
						_obj = new VilleDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _population;
		[Column(Storage = "Population",Name = "population")]
		public int Population{
			get{ return _population;}
			set{_population = value;}
		}

		[Column(Name="profondeur_min", Storage="ProfondeurMin")]
		public int ProfondeurMin{
			get{
				return Profondeur.Min;
			}
			set{
				Profondeur.Min = value;
			}
		}

		[Column(Name="profondeur_max", Storage="ProfondeurMax")]
		public int ProfondeurMax{
			get{
				return Profondeur.Max;
			}
			set{
				Profondeur.Max = value;
			}
		}

		private Range _profondeur = new Range();
		[HiddenProperty]
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
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Complexes",OtherKey = "VilleModelId")]
		public IEnumerable <Complexes> Complexes{
			get{
				if( _complexes == null ){
					_complexes = LoadFromJointure<Complexes,VilleModelToComplexes_Complexes>(false);
				}
				return _complexes;
			}
			set{
				SaveToJointure<Complexes, VilleModelToComplexes_Complexes> (_complexes, value,false);
				_complexes = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<VilleModel,VilleModelToComplexes_Complexes>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "polaris",Name = "villedescription")]
	public partial class VilleDescription : DataDescription<VilleModel> {
	}
	[Table(Schema = "polaris",Name = "villeexemplar")]
	public partial class VilleExemplar : DataExemplaire<VilleModel> {
	}
}
