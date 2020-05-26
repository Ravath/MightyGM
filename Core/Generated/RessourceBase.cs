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
	[Table(Schema = "core",Name = "ressourcebase")]
	[CoreData]
	public partial class RessourceBase : DataObject {

		private string _path = "";
		[Column(Storage = "Path",Name = "path")]
		public string Path{
			get{ return _path;}
			set{_path = value;}
		}

		private string _defaultMiscPath = "";
		[Column(Storage = "DefaultMiscPath",Name = "defaultmiscpath")]
		public string DefaultMiscPath{
			get{ return _defaultMiscPath;}
			set{_defaultMiscPath = value;}
		}

		private string _defaultTextPath = "";
		[Column(Storage = "DefaultTextPath",Name = "defaulttextpath")]
		public string DefaultTextPath{
			get{ return _defaultTextPath;}
			set{_defaultTextPath = value;}
		}

		private string _defaultImagePath = "";
		[Column(Storage = "DefaultImagePath",Name = "defaultimagepath")]
		public string DefaultImagePath{
			get{ return _defaultImagePath;}
			set{_defaultImagePath = value;}
		}

		private string _defaultSoundtrackPath = "";
		[Column(Storage = "DefaultSoundtrackPath",Name = "defaultsoundtrackpath")]
		public string DefaultSoundtrackPath{
			get{ return _defaultSoundtrackPath;}
			set{_defaultSoundtrackPath = value;}
		}
	}
}
