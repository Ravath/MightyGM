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
	[Table(Schema = "yggdrasil",Name = "runemodel")]
	[CoreData]
	public partial class RuneModel : DataModel {

		private RuneDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<RuneDescription> id = GetModelReferencer<RuneDescription>();
					if(id.Count() == 0) {
						_obj = new RuneDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private AettRune _aett;
		[Column(Storage = "Aett",Name = "aett")]
		public AettRune Aett{
			get{ return _aett;}
			set{_aett = value;}
		}

		private NatureRune _nature;
		[Column(Storage = "Nature",Name = "nature")]
		public NatureRune Nature{
			get{ return _nature;}
			set{_nature = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "runedescription")]
	public partial class RuneDescription : DataDescription<RuneModel> {

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
	[Table(Schema = "yggdrasil",Name = "runeexemplar")]
	public partial class RuneExemplar : DataExemplaire<RuneModel> {

		private bool _isPositif;
		[Column(Storage = "isPositif",Name = "ispositif")]
		public bool isPositif{
			get{ return _isPositif;}
			set{_isPositif = value;}
		}
	}
}
