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
	[Table(Schema = "pathfinder",Name = "absoddtablemodel")]
	public abstract partial class AbsOddTableModel : DataModel {

		private int _chances;
		[Column(Storage = "Chances",Name = "chances")]
		public int Chances{
			get{ return _chances;}
			set{_chances = value;}
		}
	}
	[Table(Schema = "pathfinder",Name = "absoddtabledescription")]
	public abstract partial class AbsOddTableDescription : DataDescription<AbsOddTableModel> {
	}
	[Table(Schema = "pathfinder",Name = "absoddtableexemplar")]
	public abstract partial class AbsOddTableExemplar : DataExemplaire<AbsOddTableModel> {
	}
}
