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
	[Table(Schema = "pathfinder",Name = "armedesiegemodel")]
	[CoreData]
	public partial class ArmeDeSiegeModel : ObjetModel {

		private ArmeDeSiegeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeDeSiegeDescription> id = GetModelReferencer<ArmeDeSiegeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeDeSiegeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _nbrDesDgts;
		[Column(Storage = "NbrDesDgts",Name = "nbrdesdgts")]
		public int NbrDesDgts{
			get{ return _nbrDesDgts;}
			set{_nbrDesDgts = value;}
		}

		private int _typeDesDgts;
		[Column(Storage = "TypeDesDgts",Name = "typedesdgts")]
		public int TypeDesDgts{
			get{ return _typeDesDgts;}
			set{_typeDesDgts = value;}
		}

		private int _zoneCritique;
		[Column(Storage = "ZoneCritique",Name = "zonecritique")]
		public int ZoneCritique{
			get{ return _zoneCritique;}
			set{_zoneCritique = value;}
		}

		private int _facteurPortee;
		[Column(Storage = "FacteurPortee",Name = "facteurportee")]
		public int FacteurPortee{
			get{ return _facteurPortee;}
			set{_facteurPortee = value;}
		}

		private int _porteeMin;
		[Column(Storage = "PorteeMin",Name = "porteemin")]
		public int PorteeMin{
			get{ return _porteeMin;}
			set{_porteeMin = value;}
		}

		private int _serviteurs;
		[Column(Storage = "Serviteurs",Name = "serviteurs")]
		public int Serviteurs{
			get{ return _serviteurs;}
			set{_serviteurs = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "armedesiegedescription")]
	public partial class ArmeDeSiegeDescription : ObjetDescription {
	}
	[Table(Schema = "pathfinder",Name = "armedesiegeexemplar")]
	public partial class ArmeDeSiegeExemplar : ObjetExemplar {
	}
}
