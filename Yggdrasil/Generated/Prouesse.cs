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
	[Table(Schema = "yggdrasil",Name = "prouessemodel")]
	[CoreData]
	public partial class ProuesseModel : DataModel {

		private ProuesseDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ProuesseDescription> id = GetModelReferencer<ProuesseDescription>();
					if(id.Count() == 0) {
						_obj = new ProuesseDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _niveau;
		[Column(Storage = "Niveau",Name = "niveau")]
		public int Niveau{
			get{ return _niveau;}
			set{_niveau = value;}
		}

		private int _niveauMin;
		[Column(Storage = "NiveauMin",Name = "niveaumin")]
		public int NiveauMin{
			get{ return _niveauMin;}
			set{_niveauMin = value;}
		}

		private TypeProuesse _type;
		[Column(Storage = "Type",Name = "type")]
		public TypeProuesse Type{
			get{ return _type;}
			set{_type = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "prouessedescription")]
	public partial class ProuesseDescription : DataDescription<ProuesseModel> {
	}
	[Table(Schema = "yggdrasil",Name = "prouesseexemplar")]
	public partial class ProuesseExemplar : DataExemplaire<ProuesseModel> {
	}
}
