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
	[Table(Schema = "yggdrasil",Name = "sortgaldrmodel")]
	[CoreData]
	public partial class SortGaldrModel : DataModel {

		private SortGaldrDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortGaldrDescription> id = GetModelReferencer<SortGaldrDescription>();
					if(id.Count() == 0) {
						_obj = new SortGaldrDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _domaineId;
		[Column(Storage = "DomaineId",Name = "fk_domainegaldrmodel_domaine")]
		[HiddenProperty]
		public int DomaineId{
			get{ return _domaineId;}
			set{_domaineId = value;}
		}

		private DomaineGaldrModel _domaine;
		public DomaineGaldrModel Domaine{
			get{
				if( _domaine == null)
					_domaine = LoadById<DomaineGaldrModel>(DomaineId);
				return _domaine;
			} set {
				if(_domaine == value){return;}
				_domaine = value;
				if( value != null)
					DomaineId = value.Id;
			}
		}

		private int _sD;
		[Column(Storage = "SD",Name = "sd")]
		public int SD{
			get{ return _sD;}
			set{_sD = value;}
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



		private string _cibles = "";
		[LargeText]
		[Column(Storage = "Cibles",Name = "cibles")]
		public string Cibles{
			get{ return _cibles;}
			set{_cibles = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "sortgaldrdescription")]
	public partial class SortGaldrDescription : DataDescription<SortGaldrModel> {
	}
	[Table(Schema = "yggdrasil",Name = "sortgaldrexemplar")]
	public partial class SortGaldrExemplar : DataExemplaire<SortGaldrModel> {
	}
}
