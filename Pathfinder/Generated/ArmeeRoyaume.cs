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
	[Table(Schema = "pathfinder",Name = "armeeroyaumemodel")]
	[CoreData]
	public partial class ArmeeRoyaumeModel : DataModel {

		private ArmeeRoyaumeDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ArmeeRoyaumeDescription> id = GetModelReferencer<ArmeeRoyaumeDescription>();
					if(id.Count() == 0) {
						_obj = new ArmeeRoyaumeDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private IEnumerable<RessourceArmeeModel> _ressources;
		[Association(ThisKey = "Id",CanBeNull = false,Storage = "Ressources",OtherKey = "ArmeeRoyaumeModelId")]
		public IEnumerable <RessourceArmeeModel> Ressources{
			get{
				if( _ressources == null ){
					_ressources = LoadFromJointure<RessourceArmeeModel,ArmeeRoyaumeModelToRessourceArmeeModel_Ressources>(false);
				}
				return _ressources;
			}
			set{
				SaveToJointure<RessourceArmeeModel, ArmeeRoyaumeModelToRessourceArmeeModel_Ressources> (_ressources, value,false);
				_ressources = value;
			}
		}

		private CategorieTaille _taille;
		[Column(Storage = "Taille",Name = "taille")]
		public CategorieTaille Taille{
			get{ return _taille;}
			set{_taille = value;}
		}
		public override void DeleteObject() {
			DeleteJoins<ArmeeRoyaumeModel,ArmeeRoyaumeModelToRessourceArmeeModel_Ressources>(true);
			base.DeleteObject();
		}
	}
	[Table(Schema = "pathfinder",Name = "armeeroyaumedescription")]
	public partial class ArmeeRoyaumeDescription : DataDescription<ArmeeRoyaumeModel> {
	}
	[Table(Schema = "pathfinder",Name = "armeeroyaumeexemplar")]
	public partial class ArmeeRoyaumeExemplar : DataExemplaire<ArmeeRoyaumeModel> {
	}
}
