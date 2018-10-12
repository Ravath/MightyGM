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
	[Table(Schema = "yggdrasil",Name = "poisonmodel")]
	[CoreData]
	public partial class PoisonModel : DataModel {

		private PoisonDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<PoisonDescription> id = GetModelReferencer<PoisonDescription>();
					if(id.Count() == 0) {
						_obj = new PoisonDescription();
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

		private bool _ingestion;
		[Column(Storage = "Ingestion",Name = "ingestion")]
		public bool Ingestion{
			get{ return _ingestion;}
			set{_ingestion = value;}
		}

		private bool _contact;
		[Column(Storage = "Contact",Name = "contact")]
		public bool Contact{
			get{ return _contact;}
			set{_contact = value;}
		}

		private bool _injection;
		[Column(Storage = "Injection",Name = "injection")]
		public bool Injection{
			get{ return _injection;}
			set{_injection = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "poisondescription")]
	public partial class PoisonDescription : DataDescription<PoisonModel> {
	}
	[Table(Schema = "yggdrasil",Name = "poisonexemplar")]
	public partial class PoisonExemplar : DataExemplaire<PoisonModel> {
	}
}
