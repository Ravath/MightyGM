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
	[Table(Schema = "cinqanneaux",Name = "objetmodel")]
	[CoreData]
	public partial class ObjetModel : AbsObjetModel {

		private ObjetDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ObjetDescription> id = GetModelReferencer<ObjetDescription>();
					if(id.Count() == 0) {
						_obj = new ObjetDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int? _coutMax;
		[Column(Storage = "CoutMax",Name = "coutmax")]
		public int? CoutMax{
			get{ return _coutMax;}
			set{_coutMax = value;}
		}

		private bool _vetement;
		[Column(Storage = "Vetement",Name = "vetement")]
		public bool Vetement{
			get{ return _vetement;}
			set{_vetement = value;}
		}

		private bool _necessaireVoyage;
		[Column(Storage = "NecessaireVoyage",Name = "necessairevoyage")]
		public bool NecessaireVoyage{
			get{ return _necessaireVoyage;}
			set{_necessaireVoyage = value;}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "objetdescription")]
	public partial class ObjetDescription : AbsObjetDescription {
	}
	[Table(Schema = "cinqanneaux",Name = "objetexemplar")]
	public partial class ObjetExemplar : AbsObjetExemplar {
	}
}
