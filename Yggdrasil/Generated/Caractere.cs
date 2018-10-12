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
	[Table(Schema = "yggdrasil",Name = "caracteremodel")]
	[CoreData]
	public partial class CaractereModel : DataModel {

		private CaractereDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CaractereDescription> id = GetModelReferencer<CaractereDescription>();
					if(id.Count() == 0) {
						_obj = new CaractereDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _monstrueux;
		[Column(Storage = "Monstrueux",Name = "monstrueux")]
		public bool Monstrueux{
			get{ return _monstrueux;}
			set{_monstrueux = value;}
		}

		private int _conflitOffensif;
		[Column(Storage = "ConflitOffensif",Name = "conflitoffensif")]
		public int ConflitOffensif{
			get{ return _conflitOffensif;}
			set{_conflitOffensif = value;}
		}

		private int _conflitDefensif;
		[Column(Storage = "ConflitDefensif",Name = "conflitdefensif")]
		public int ConflitDefensif{
			get{ return _conflitDefensif;}
			set{_conflitDefensif = value;}
		}

		private int _relationnel;
		[Column(Storage = "Relationnel",Name = "relationnel")]
		public int Relationnel{
			get{ return _relationnel;}
			set{_relationnel = value;}
		}

		private int _physique;
		[Column(Storage = "Physique",Name = "physique")]
		public int Physique{
			get{ return _physique;}
			set{_physique = value;}
		}

		private int _mental;
		[Column(Storage = "Mental",Name = "mental")]
		public int Mental{
			get{ return _mental;}
			set{_mental = value;}
		}

		private int _mystiqueActif;
		[Column(Storage = "MystiqueActif",Name = "mystiqueactif")]
		public int MystiqueActif{
			get{ return _mystiqueActif;}
			set{_mystiqueActif = value;}
		}

		private int _mystiquePassif;
		[Column(Storage = "MystiquePassif",Name = "mystiquepassif")]
		public int MystiquePassif{
			get{ return _mystiquePassif;}
			set{_mystiquePassif = value;}
		}

		private int _vitalite;
		[Column(Storage = "Vitalite",Name = "vitalite")]
		public int Vitalite{
			get{ return _vitalite;}
			set{_vitalite = value;}
		}
	}
	[Table(Schema = "yggdrasil",Name = "caracteredescription")]
	public partial class CaractereDescription : DataDescription<CaractereModel> {
	}
	[Table(Schema = "yggdrasil",Name = "caractereexemplar")]
	public partial class CaractereExemplar : DataExemplaire<CaractereModel> {

		private string _precisions = "";
		[Column(Storage = "Precisions",Name = "precisions")]
		public string Precisions{
			get{ return _precisions;}
			set{_precisions = value;}
		}
	}
}
