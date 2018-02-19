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
	[Table(Schema = "dd35",Name = "piegemodel")]
	[CoreData]
	public partial class PiegeModel : DataModel {

		private PiegeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PiegeDescription> id = GetModelReferencer<PiegeDescription>();
					if(id.Count() == 0) {
						_obj = new PiegeDescription();
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

		private int _fP;
		[Column(Storage = "FP",Name = "fp")]
		public int FP{
			get{ return _fP;}
			set{_fP = value;}
		}

		private TypePiege _type;
		[Column(Storage = "Type",Name = "type")]
		public TypePiege Type{
			get{ return _type;}
			set{_type = value;}
		}

		private DeclencheurPiege _declencheur;
		[Column(Storage = "Declencheur",Name = "declencheur")]
		public DeclencheurPiege Declencheur{
			get{ return _declencheur;}
			set{_declencheur = value;}
		}

		private RemisePiege _remise;
		[Column(Storage = "Remise",Name = "remise")]
		public RemisePiege Remise{
			get{ return _remise;}
			set{_remise = value;}
		}

		private int _dDFouille;
		[Column(Storage = "DDFouille",Name = "ddfouille")]
		public int DDFouille{
			get{ return _dDFouille;}
			set{_dDFouille = value;}
		}

		private int _dDDesamorcage;
		[Column(Storage = "DDDesamorcage",Name = "dddesamorcage")]
		public int DDDesamorcage{
			get{ return _dDDesamorcage;}
			set{_dDDesamorcage = value;}
		}

		private int _prix;
		[Column(Storage = "Prix",Name = "prix")]
		public int Prix{
			get{ return _prix;}
			set{_prix = value;}
		}
	}
	[Table(Schema = "dd35",Name = "piegedescription")]
	public partial class PiegeDescription : DataDescription<PiegeModel> {
	}
	[Table(Schema = "dd35",Name = "piegeexemplar")]
	public partial class PiegeExemplar : DataExemplaire<PiegeModel> {
	}
}
