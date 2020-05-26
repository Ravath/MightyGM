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
	[Table(Schema = "core",Name = "tag")]
	[CoreData]
	public partial class Tag : DataObject {

		private string _label = "";
		[Column(Storage = "Label",Name = "label")]
		public string Label{
			get{ return _label;}
			set{_label = value;}
		}

		private bool _isFolder;
		[Column(Storage = "isFolder",Name = "isfolder")]
		public bool IsFolder{
			get{ return _isFolder;}
			set{_isFolder = value;}
		}
	}
}
