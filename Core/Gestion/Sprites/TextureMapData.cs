using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Core.Gestion.Sprites
{
	[Table(Schema = "sprites", Name = "texture_map")]
	public class TextureMapData : DataObject
	{
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("texture_map_id_seq")]
		[HiddenProperty]
		public new int Id { get; set; }

		[Column(Name = "path")]
		public string Name { get; set; }

		[Column(Name = "is_grid")]
		public bool IsGrid { get; set; }

		private int _row;
		[Column(Name = "nb_row")]
		public int Row {
			get { return _row; }
			set { _row = Math.Max(value, 0); }
		}

		private int _col;
		[Column(Name = "nb_column")]
		public int Column
		{
			get { return _col; }
			set { _col = Math.Max(value, 0); }
		}

		public override string ToString()
		{
			return Name;
		}
	}
}