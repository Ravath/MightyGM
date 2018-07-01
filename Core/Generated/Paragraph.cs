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
	[Table(Schema = "core",Name = "paragraph")]
	[CoreData]
	public partial class Paragraph : Ressource {

		private string _title = "";
		[Column(Storage = "Title",Name = "title")]
		public string Title{
			get{ return _title;}
			set{_title = value;}
		}

		private string _text = "";
		[LargeText]
		[Column(Storage = "Text",Name = "text")]
		public string Text{
			get{ return _text;}
			set{_text = value;}
		}
	}
}
