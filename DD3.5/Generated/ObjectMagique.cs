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
	[Table(Schema = "dd35",Name = "objectmagiquemodel")]
	public abstract partial class ObjectMagiqueModel : ObjetModel {

		private UsageObjectMagique _usage;
		[Column(Storage = "Usage",Name = "usage")]
		public UsageObjectMagique Usage{
			get{ return _usage;}
			set{_usage = value;}
		}

		private int _prix;
		[Column(Storage = "prix",Name = "prix")]
		public int prix{
			get{ return _prix;}
			set{_prix = value;}
		}

		private EcoleMagie _ecoleAura;
		[Column(Storage = "EcoleAura",Name = "ecoleaura")]
		public EcoleMagie EcoleAura{
			get{ return _ecoleAura;}
			set{_ecoleAura = value;}
		}

		private PuissanceAura _puissanceAura;
		[Column(Storage = "PuissanceAura",Name = "puissanceaura")]
		public PuissanceAura PuissanceAura{
			get{ return _puissanceAura;}
			set{_puissanceAura = value;}
		}

		private int _nLS;
		[Column(Storage = "NLS",Name = "nls")]
		public int NLS{
			get{ return _nLS;}
			set{_nLS = value;}
		}

		private IEnumerable<SortModel> _sortsCreation;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "SortsCreation",OtherKey = "ObjectMagiqueModelId")]
		public IEnumerable <SortModel> SortsCreation{
			get{
				if( _sortsCreation == null ){
					_sortsCreation = LoadFromJointure<SortModel,ObjectMagiqueModelToSortModel_SortsCreation>(false);
				}
				return _sortsCreation;
			}
			set{
				SaveToJointure<SortModel, ObjectMagiqueModelToSortModel_SortsCreation> (_sortsCreation, value,false);
				_sortsCreation = value;
			}
		}
		public override void DeleteObject() {
			DeleteJoins<ObjectMagiqueModel,ObjectMagiqueModelToSortModel_SortsCreation>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "dd35",Name = "objectmagiquedescription")]
	public abstract partial class ObjectMagiqueDescription : ObjetDescription {
	}
	[Table(Schema = "dd35",Name = "objectmagiqueexemplar")]
	public abstract partial class ObjectMagiqueExemplar : ObjetExemplar {
	}
}
