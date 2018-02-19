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
	[Table(Schema = "pathfinder",Name = "ameliorationterrainmodel")]
	[CoreData]
	public partial class AmeliorationTerrainModel : DataModel {

		private AmeliorationTerrainDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<AmeliorationTerrainDescription> id = GetModelReferencer<AmeliorationTerrainDescription>();
					if(id.Count() == 0) {
						_obj = new AmeliorationTerrainDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private bool _superposable;
		[Column(Storage = "Superposable",Name = "superposable")]
		public bool Superposable{
			get{ return _superposable;}
			set{_superposable = value;}
		}

		private int _prixPC;
		[Column(Storage = "PrixPC",Name = "prixpc")]
		public int PrixPC{
			get{ return _prixPC;}
			set{_prixPC = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "ameliorationterraindescription")]
	public partial class AmeliorationTerrainDescription : DataDescription<AmeliorationTerrainModel> {

		private string _terrain = "";
		[LargeText]
		[Column(Storage = "Terrain",Name = "terrain")]
		public string Terrain{
			get{ return _terrain;}
			set{_terrain = value;}
		}

		private string _effet = "";
		[LargeText]
		[Column(Storage = "Effet",Name = "effet")]
		public string Effet{
			get{ return _effet;}
			set{_effet = value;}
		}

		private string _prix = "";
		[LargeText]
		[Column(Storage = "Prix",Name = "prix")]
		public string Prix{
			get{ return _prix;}
			set{_prix = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "ameliorationterrainexemplar")]
	public partial class AmeliorationTerrainExemplar : DataExemplaire<AmeliorationTerrainModel> {
	}
}
