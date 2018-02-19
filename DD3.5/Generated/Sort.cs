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
	[Table(Schema = "dd35",Name = "sortmodel")]
	[CoreData]
	public partial class SortModel : DataModel {

		private SortDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortDescription> id = GetModelReferencer<SortDescription>();
					if(id.Count() == 0) {
						_obj = new SortDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private EcoleMagie _ecole;
		[Column(Storage = "Ecole",Name = "ecole")]
		public EcoleMagie Ecole{
			get{ return _ecole;}
			set{_ecole = value;}
		}

		private BrancheMagie? _branche;
		[Column(Storage = "Branche",Name = "branche")]
		public BrancheMagie? Branche{
			get{ return _branche;}
			set{_branche = value;}
		}


		private IEnumerable < int > _registres;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Registres",OtherKey = "SortModel")]
		public IEnumerable < int > Registres{
			get{
				if( _registres == null ){
					_registres = LoadFromDataValue<RegistresFromSortModel, int>();
				}
				return _registres;
			}
			set{
				SaveDataValue<RegistresFromSortModel, int>(_registres, value);
			}
		}


		private IEnumerable < int > _composantes;
		[Association(ThisKey = "Id",CanBeNull = true,Storage = "Composantes",OtherKey = "SortModel")]
		public IEnumerable < int > Composantes{
			get{
				if( _composantes == null ){
					_composantes = LoadFromDataValue<ComposantesFromSortModel, int>();
				}
				return _composantes;
			}
			set{
				SaveDataValue<ComposantesFromSortModel, int>(_composantes, value);
			}
		}

		private TempsIncantation _tempsIncantation;
		[Column(Storage = "TempsIncantation",Name = "tempsincantation")]
		public TempsIncantation TempsIncantation{
			get{ return _tempsIncantation;}
			set{_tempsIncantation = value;}
		}

		private PorteeSort _portee;
		[Column(Storage = "Portee",Name = "portee")]
		public PorteeSort Portee{
			get{ return _portee;}
			set{_portee = value;}
		}

		private int? _metresPortee;
		[Column(Storage = "MetresPortee",Name = "metresportee")]
		public int? MetresPortee{
			get{ return _metresPortee;}
			set{_metresPortee = value;}
		}

		private string _cibles = "";
		[Column(Storage = "Cibles",Name = "cibles")]
		public string Cibles{
			get{ return _cibles;}
			set{_cibles = value;}
		}

		private string _effets;
		[Column(Storage = "Effets",Name = "effets")]
		public string Effets{
			get{ return _effets;}
			set{_effets = value;}
		}

		private EffetKeyWord? _effetType;
		[Column(Storage = "EffetType",Name = "effettype")]
		public EffetKeyWord? EffetType{
			get{ return _effetType;}
			set{_effetType = value;}
		}

		private string _zone;
		[Column(Storage = "Zone",Name = "zone")]
		public string Zone{
			get{ return _zone;}
			set{_zone = value;}
		}

		private ZoneKeyWord? _zoneType;
		[Column(Storage = "ZoneType",Name = "zonetype")]
		public ZoneKeyWord? ZoneType{
			get{ return _zoneType;}
			set{_zoneType = value;}
		}

		private DureeSort _duree;
		[Column(Storage = "Duree",Name = "duree")]
		public DureeSort Duree{
			get{ return _duree;}
			set{_duree = value;}
		}

		private string _dureePrecision;
		[Column(Storage = "DureePrecision",Name = "dureeprecision")]
		public string DureePrecision{
			get{ return _dureePrecision;}
			set{_dureePrecision = value;}
		}

		private Sauvegarde? _testSauvegarde;
		[Column(Storage = "TestSauvegarde",Name = "testsauvegarde")]
		public Sauvegarde? TestSauvegarde{
			get{ return _testSauvegarde;}
			set{_testSauvegarde = value;}
		}

		private bool _rM;
		[Column(Storage = "RM",Name = "rm")]
		public bool RM{
			get{ return _rM;}
			set{_rM = value;}
		}
		public override void DeleteObject() {
			DeleteDataValue<RegistresFromSortModel>();
			DeleteDataValue<ComposantesFromSortModel>();
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "sortdescription")]
	public partial class SortDescription : DataDescription<SortModel> {

		private string _courteDescription = "";
		[LargeText]
		[Column(Storage = "CourteDescription",Name = "courtedescription")]
		public string CourteDescription{
			get{ return _courteDescription;}
			set{_courteDescription = value;}
		}
	}
	[Table(Schema = "dd35",Name = "sortexemplar")]
	public partial class SortExemplar : DataExemplaire<SortModel> {
	}
}
