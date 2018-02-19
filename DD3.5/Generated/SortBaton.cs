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
	[Table(Schema = "dd35",Name = "sortbaton")]
	[CoreData]
	public partial class SortBaton : DataObject {

		private int _charge;
		[Column(Storage = "charge",Name = "charge")]
		public int charge{
			get{ return _charge;}
			set{_charge = value;}
		}

		private int _sortId;
		[Column(Storage = "SortId",Name = "fk_sortmodel_sort")]
		[HiddenProperty]
		public int SortId{
			get{ return _sortId;}
			set{_sortId = value;}
		}

		private SortModel _sort;
		public SortModel Sort{
			get{
				if( _sort == null)
					_sort = LoadById<SortModel>(SortId);
				return _sort;
			} set {
				if(_sort == value){return;}
				_sort = value;
				if( value != null)
					SortId = value.Id;
			}
		}
	}
}
