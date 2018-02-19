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
namespace StarWars.Data {
	[Table(Schema = "starwars",Name = "arborescence")]
	public abstract partial class Arborescence : DataObject {

		private string _name = "";
		[Column(Storage = "Name",Name = "name")]
		public string Name{
			get{ return _name;}
			set{_name = value;}
		}

		private IEnumerable<CaseArborescence> _cases;
		public IEnumerable <CaseArborescence> Cases{
			get{
				if( _cases == null ){
					_cases = LoadByForeignKey<CaseArborescence>(p => p.ArborescenceId, Id);
				}
				return _cases;
			}
			set{
				foreach( CaseArborescence item in _cases ){
					item.Arborescence = null;

				}
				_cases = value;
				foreach( CaseArborescence item in value ){
					item.Arborescence = this;
					item.SaveObject();
				}
			}
		}

		private IEnumerable<BrancheArborescence> _links;
		public IEnumerable <BrancheArborescence> Links{
			get{
				if( _links == null ){
					_links = LoadByForeignKey<BrancheArborescence>(p => p.ArborescenceId, Id);
				}
				return _links;
			}
			set{
				foreach( BrancheArborescence item in _links ){
					item.Arborescence = null;

				}
				_links = value;
				foreach( BrancheArborescence item in value ){
					item.Arborescence = this;
					item.SaveObject();
				}
			}
		}
	}
}
