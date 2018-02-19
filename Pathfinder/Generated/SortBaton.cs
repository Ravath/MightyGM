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
namespace Pathfinder.Data {
	[Table(Schema = "pathfinder",Name = "sortbaton")]
	[CoreData]
	public partial class SortBaton : DataObject {

		private int _batonId;
		[Column(Storage = "BatonId",Name = "fk_batonmodel_baton")]
		[HiddenProperty]
		public int BatonId{
			get{ return _batonId;}
			set{_batonId = value;}
		}

		private BatonModel _baton;
		public BatonModel Baton{
			get {
				if(_baton == null) {
					_baton = LoadById<BatonModel>(BatonId);
			       }
				return _baton;
			} set {
				if(value == _baton) { return; }
				_baton = value;
				if(_baton != null) {
					_batonId = _baton.Id;
				} else {
					_batonId = 0;
				}
			}
		}

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
