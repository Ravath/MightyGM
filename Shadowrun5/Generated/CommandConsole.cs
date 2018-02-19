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
namespace Shadowrun5.Data {
	[Table(Schema = "shadowrun5",Name = "commandconsolemodel")]
	[CoreData]
	public partial class CommandConsoleModel : ElectronicModel {

		private CommandConsoleDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<CommandConsoleDescription> id = GetModelReferencer<CommandConsoleDescription>();
					if(id.Count() == 0) {
						_obj = new CommandConsoleDescription();
						_obj.Model = this;
						_obj.SaveObject();
						return _obj;
					} else {
						return id.ElementAt(0);
					}
				} else {
					return _obj;
				}
				
			}
		}

		private int _dataProcessing;
		[Column(Storage = "DataProcessing",Name = "dataprocessing")]
		public int DataProcessing{
			get{ return _dataProcessing;}
			set{_dataProcessing = value;}
		}

		private int _firewall;
		[Column(Storage = "Firewall",Name = "firewall")]
		public int Firewall{
			get{ return _firewall;}
			set{_firewall = value;}
		}
	}
	[Table(Schema = "shadowrun5",Name = "commandconsoledescription")]
	public partial class CommandConsoleDescription : ElectronicDescription {
	}
	[Table(Schema = "shadowrun5",Name = "commandconsoleexemplar")]
	public partial class CommandConsoleExemplar : ElectronicExemplar {
	}
}
