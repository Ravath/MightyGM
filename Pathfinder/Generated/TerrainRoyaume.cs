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
	[Table(Schema = "pathfinder",Name = "terrainroyaumemodel")]
	[CoreData]
	public partial class TerrainRoyaumeModel : DataModel {

		private TerrainRoyaumeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TerrainRoyaumeDescription> id = GetModelReferencer<TerrainRoyaumeDescription>();
					if(id.Count() == 0) {
						_obj = new TerrainRoyaumeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _dureeExploration;
		[Column(Storage = "DureeExploration",Name = "dureeexploration")]
		public int DureeExploration{
			get{ return _dureeExploration;}
			set{_dureeExploration = value;}
		}

		private int _dureePreparation;
		[Column(Storage = "DureePreparation",Name = "dureepreparation")]
		public int DureePreparation{
			get{ return _dureePreparation;}
			set{_dureePreparation = value;}
		}

		private int _coutPreparation;
		[Column(Storage = "CoutPreparation",Name = "coutpreparation")]
		public int CoutPreparation{
			get{ return _coutPreparation;}
			set{_coutPreparation = value;}
		}

		private int _coutFerme;
		[Column(Storage = "CoutFerme",Name = "coutferme")]
		public int CoutFerme{
			get{ return _coutFerme;}
			set{_coutFerme = value;}
		}

		private int _coutRoute;
		[Column(Storage = "CoutRoute",Name = "coutroute")]
		public int CoutRoute{
			get{ return _coutRoute;}
			set{_coutRoute = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "terrainroyaumedescription")]
	public partial class TerrainRoyaumeDescription : DataDescription<TerrainRoyaumeModel> {
	}
	[Table(Schema = "pathfinder",Name = "terrainroyaumeexemplar")]
	public partial class TerrainRoyaumeExemplar : DataExemplaire<TerrainRoyaumeModel> {
	}
}
