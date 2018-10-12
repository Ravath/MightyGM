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
namespace CinqAnneaux.Data {
	[Table(Schema = "cinqanneaux",Name = "clanmodel")]
	[CoreData]
	public partial class ClanModel : DataModel {

		private ClanDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<ClanDescription> id = GetModelReferencer<ClanDescription>();
					if(id.Count() == 0) {
						_obj = new ClanDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private TypeClan _typeClan;
		[Column(Storage = "TypeClan",Name = "typeclan")]
		public TypeClan TypeClan{
			get{ return _typeClan;}
			set{_typeClan = value;}
		}

		private IEnumerable<FamilleModel> _familles;
		public IEnumerable <FamilleModel> Familles{
			get{
				if( _familles == null ){
					_familles = LoadByForeignKey<FamilleModel>(p => p.ClanId, Id);
				}
				return _familles;
			}
			set{
				foreach( FamilleModel item in _familles ){
					item.Clan = null;

				}
				_familles = value;
				foreach( FamilleModel item in value ){
					item.Clan = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<EcoleModel> _ecoles;
		public IEnumerable <EcoleModel> Ecoles{
			get{
				if( _ecoles == null ){
					_ecoles = LoadByForeignKey<EcoleModel>(p => p.ClanId, Id);
				}
				return _ecoles;
			}
			set{
				foreach( EcoleModel item in _ecoles ){
					item.Clan = null;

				}
				_ecoles = value;
				foreach( EcoleModel item in value ){
					item.Clan = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<TableHeritageModel> _heritages;
		public IEnumerable <TableHeritageModel> Heritages{
			get{
				if( _heritages == null ){
					_heritages = LoadByForeignKey<TableHeritageModel>(p => p.ClanId, Id);
				}
				return _heritages;
			}
			set{
				foreach( TableHeritageModel item in _heritages ){
					item.Clan = null;

				}
				_heritages = value;
				foreach( TableHeritageModel item in value ){
					item.Clan = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "clandescription")]
	public partial class ClanDescription : DataDescription<ClanModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "clanexemplar")]
	public partial class ClanExemplar : DataExemplaire<ClanModel> {
	}
}
