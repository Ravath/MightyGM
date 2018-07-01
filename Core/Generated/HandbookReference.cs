using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Types;
using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
namespace Core.Data {
	[Table(Schema = "core",Name = "handbookreference")]
	[CoreData]
	public partial class HandbookReference : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private int _bookId;
		[Column(Storage = "BookId",Name = "fk_handbook_book")]
		[HiddenProperty]
		public int BookId{
			get{ return _bookId;}
			set{_bookId = value;}
		}

		private Handbook _book;
		public Handbook Book{
			get{
				if( _book == null)
					_book = LoadById<Handbook>(BookId);
				return _book;
			} set {
				if(_book == value){return;}
				_book = value;
				if( value != null)
					BookId = value.Id;
			}
		}

		private int _page;
		[Column(Storage = "Page",Name = "page")]
		public int Page{
			get{ return _page;}
			set{_page = value;}
		}
	}
}
