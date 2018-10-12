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
	[Table(Schema = "yggdrasil",Name = "maladiemodel")]
	[CoreData]
	public partial class MaladieModel : DataModel {

		private MaladieDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<MaladieDescription> id = GetModelReferencer<MaladieDescription>();
					if(id.Count() == 0) {
						_obj = new MaladieDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private CategorieAffection _categorie;
		[Column(Storage = "Categorie",Name = "categorie")]
		public CategorieAffection Categorie{
			get{ return _categorie;}
			set{_categorie = value;}
		}

		private int _seuil;
		[Column(Storage = "Seuil",Name = "seuil")]
		public int Seuil{
			get{ return _seuil;}
			set{_seuil = value;}
		}

		[Column(Name = "periode_val", Storage="PeriodeVal")]
		public int PeriodeVal{
			get{
				return Periode.Value;
			}
			set{
				Periode.Value = value;
			}
		}

		[Column(Name = "periode_unit", Storage="PeriodeUnit")]
		public TimeUnity PeriodeUnit{
			get{
				return Periode.Unity;
			}
			set{
				Periode.Unity = value;
			}
		}

		private TimePeriod _periode = new TimePeriod();
		[HiddenProperty]
		public TimePeriod Periode{
			get{
				return _periode;
			}
			set{
				_periode = value;
			}
		}


	}
	[Table(Schema = "yggdrasil",Name = "maladiedescription")]
	public partial class MaladieDescription : DataDescription<MaladieModel> {
	}
	[Table(Schema = "yggdrasil",Name = "maladieexemplar")]
	public partial class MaladieExemplar : DataExemplaire<MaladieModel> {

		private int _avancement;
		[Column(Storage = "Avancement",Name = "avancement")]
		public int Avancement{
			get{ return _avancement;}
			set{_avancement = value;}
		}
	}
}
