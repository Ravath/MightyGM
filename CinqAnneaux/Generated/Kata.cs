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
	[Table(Schema = "cinqanneaux",Name = "katamodel")]
	[CoreData]
	public partial class KataModel : DataModel {

		private KataDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<KataDescription> id = GetModelReferencer<KataDescription>();
					if(id.Count() == 0) {
						_obj = new KataDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private Anneau _anneau;
		[Column(Storage = "Anneau",Name = "anneau")]
		public Anneau Anneau{
			get{ return _anneau;}
			set{_anneau = value;}
		}

		private int _maitrise;
		[Column(Storage = "Maitrise",Name = "maitrise")]
		public int Maitrise{
			get{ return _maitrise;}
			set{_maitrise = value;}
		}

		private IEnumerable<EcoleModel> _ecoles;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Ecoles",OtherKey = "KataModelId")]
		public IEnumerable <EcoleModel> Ecoles{
			get{
				if( _ecoles == null ){
					_ecoles = LoadFromJointure<EcoleModel,KataModelToEcoleModel_Ecoles>(false);
				}
				return _ecoles;
			}
			set{
				SaveToJointure<EcoleModel, KataModelToEcoleModel_Ecoles> (_ecoles, value,false);
				_ecoles = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<KataModel,KataModelToEcoleModel_Ecoles>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "cinqanneaux",Name = "katadescription")]
	public partial class KataDescription : DataDescription<KataModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "kataexemplar")]
	public partial class KataExemplar : DataExemplaire<KataModel> {
	}
}
