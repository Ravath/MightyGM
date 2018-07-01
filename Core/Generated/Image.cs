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
	[Table(Schema = "core",Name = "image")]
	[CoreData]
	public partial class Image : Ressource {

		private string _filePath = "";
		[Column(Storage = "FilePath",Name = "filepath")]
		public string FilePath{
			get{ return _filePath;}
			set{_filePath = value;}
		}
	}
}
