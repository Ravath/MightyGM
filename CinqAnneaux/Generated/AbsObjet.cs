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
	[Table(Schema = "cinqanneaux",Name = "absobjetmodel")]
	public abstract partial class AbsObjetModel : DataModel {

		private Monnaie _monnaie;
		[Column(Storage = "Monnaie",Name = "monnaie")]
		public Monnaie Monnaie{
			get{ return _monnaie;}
			set{_monnaie = value;}
		}

		private int _cout;
		[Column(Storage = "Cout",Name = "cout")]
		public int Cout{
			get{ return _cout;}
			set{_cout = value;}
		}

		private int _specialId;
		[Column(Storage = "SpecialId",Name = "fk_specialobjet_special")]
		[HiddenProperty]
		public int SpecialId{
			get{ return _specialId;}
			set{_specialId = value;}
		}

		private SpecialObjet _special;
		public SpecialObjet Special{
			get{
				if( _special == null)
					_special = LoadById<SpecialObjet>(SpecialId);
				return _special;
			} set {
				if(_special == value){return;}
				_special = value;
				if( value != null)
					SpecialId = value.Id;
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "absobjetdescription")]
	public abstract partial class AbsObjetDescription : DataDescription<AbsObjetModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "absobjetexemplar")]
	public abstract partial class AbsObjetExemplar : DataExemplaire<AbsObjetModel> {
	}
}
