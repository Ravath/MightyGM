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
	[Table(Schema = "cinqanneaux",Name = "tableheritagemodel")]
	[CoreData]
	public partial class TableHeritageModel : DataModel {

		private TableHeritageDescription _obj;
		public override IDataDescription Description{
			get{
				if(_obj == null){
					IEnumerable<TableHeritageDescription> id = GetModelReferencer<TableHeritageDescription>();
					if(id.Count() == 0) {
						_obj = new TableHeritageDescription();
						_obj.Model = this;
						_obj.SaveObject();
					} else {
						_obj = id.ElementAt(0);
					}
				}
				return _obj;
				
			}
		}

		private int _clanId;
		[Column(Storage = "ClanId",Name = "fk_clanmodel_clan")]
		[HiddenProperty]
		public int ClanId{
			get{ return _clanId;}
			set{_clanId = value;}
		}

		private ClanModel _clan;
		public ClanModel Clan{
			get {
				if(_clan == null) {
					_clan = LoadById<ClanModel>(ClanId);
			       }
				return _clan;
			} set {
				if(value == _clan) { return; }
				_clan = value;
				if(_clan != null) {
					_clanId = _clan.Id;
				} else {
					_clanId = 0;
				}
			}
		}

		private int _chances;
		[Column(Storage = "Chances",Name = "chances")]
		public int Chances{
			get{ return _chances;}
			set{_chances = value;}
		}

		private IEnumerable<TableHeritageConsequencesModel> _consequences;
		public IEnumerable <TableHeritageConsequencesModel> Consequences{
			get{
				if( _consequences == null ){
					_consequences = LoadByForeignKey<TableHeritageConsequencesModel>(p => p.TableHeritageId, Id);
				}
				return _consequences;
			}
			set{
				foreach( TableHeritageConsequencesModel item in _consequences ){
					item.TableHeritage = null;

				}
				_consequences = value;
				foreach( TableHeritageConsequencesModel item in value ){
					item.TableHeritage = this;
					item.SaveObject();
				}
			}
		}
	}
	[Table(Schema = "cinqanneaux",Name = "tableheritagedescription")]
	public partial class TableHeritageDescription : DataDescription<TableHeritageModel> {
	}
	[Table(Schema = "cinqanneaux",Name = "tableheritageexemplar")]
	public partial class TableHeritageExemplar : DataExemplaire<TableHeritageModel> {
	}
}
