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
	[Table(Schema = "pathfinder",Name = "composantefocalisateur")]
	[CoreData]
	public partial class ComposanteFocalisateur : AbsComposanteSort {

		private int _sortId;
		[Column(Storage = "SortId",Name = "fk_sortmodel_sort")]
		[HiddenProperty]
		public int SortId{
			get{ return _sortId;}
			set{_sortId = value;}
		}

		private SortModel _sort;
		public SortModel Sort{
			get {
				if(_sort == null) {
					_sort = LoadById<SortModel>(SortId);
			       }
				return _sort;
			} set {
				if(value == _sort) { return; }
				_sort = value;
				if(_sort != null) {
					_sortId = _sort.Id;
				} else {
					_sortId = 0;
				}
			}
		}
	}
}
