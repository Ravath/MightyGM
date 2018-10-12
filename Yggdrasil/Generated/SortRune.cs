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
	[Table(Schema = "yggdrasil",Name = "sortrunemodel")]
	[CoreData]
	public partial class SortRuneModel : DataModel {

		private SortRuneDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<SortRuneDescription> id = GetModelReferencer<SortRuneDescription>();
					if(id.Count() == 0) {
						_obj = new SortRuneDescription();
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
	}
	[Table(Schema = "yggdrasil",Name = "sortrunedescription")]
	public partial class SortRuneDescription : DataDescription<SortRuneModel> {

		private string _effetPositif = "";
		[LargeText]
		[Column(Storage = "EffetPositif",Name = "effetpositif")]
		public string EffetPositif{
			get{ return _effetPositif;}
			set{_effetPositif = value;}
		}

		private string _effetNegatif = "";
		[LargeText]
		[Column(Storage = "EffetNegatif",Name = "effetnegatif")]
		public string EffetNegatif{
			get{ return _effetNegatif;}
			set{_effetNegatif = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "sortruneexemplar")]
	public partial class SortRuneExemplar : DataExemplaire<SortRuneModel> {
	}
}
