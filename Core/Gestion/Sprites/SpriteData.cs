using Core.Data;
using Core.Data.Schema;
using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Gestion.Sprites
{
	[Table(Schema = "sprites", Name = "sprite")]
	public class SpriteData : DataObject
	{
		[PrimaryKey, Identity, Column(Name = "id"), SequenceName("sprite_id_seq")]
		[HiddenProperty]
		public new int Id { get; set; }

		[Column(Name = "sprname")]
		public string Name { get; set; }

		[Column(Name = "fk_texture_map")]
		[HiddenProperty]
		public int TextureMapId { get; set; }

		private TextureMapData _textureMap;
		public TextureMapData TextureMap
		{
			get
			{
				if (_textureMap == null)
				{
					var q = from s in Database.GlobalDataBase.GetTable<TextureMapData>()
							where s.Id == TextureMapId
							select s;
					_textureMap = q.SingleOrDefault();
				}
				return _textureMap;
			}
			set
			{
				_textureMap = value;
				if (value == null)
					TextureMapId = 0;
				else
					TextureMapId = value.Id;
			}
		}

		[Column(Name = "use_grid")]
		public bool UseGrid{ get; set; }

		private int _top;
		[Column(Name = "top_i")]
		public int Top {
			get { return _top; }
			set {
				_top = Math.Max(value, 0);
				if (_textureMap != null)
				{
					_top = Math.Min(_top, _textureMap.Row);
				}
			}
		}

		private int _bottom;
		[Column(Name = "bottom_i")]
		public int Bottom
		{
			get { return _bottom; }
			set {
				_bottom = Math.Max(Top, value);
				if (_textureMap != null)
				{
					_bottom = Math.Min(_bottom, _textureMap.Row);
				}
			}
		}

		private int _left;
		[Column(Name = "left_i")]
		public int Left
		{
			get { return _left; }
			set {
				_left = Math.Max(value, 0);
				if (_textureMap != null)
				{
					_left = Math.Min(_left, _textureMap.Column);
				}
			}
		}

		private int _right;
		[Column(Name = "right_i")]
		public int Right {
			get { return _right; }
			set {
				_right = Math.Max(Left, value);
				if (_textureMap != null)
				{
					_right = Math.Min(_right, _textureMap.Column);
				}
			}
		}

		[Column(Name = "size_factor")]
		public int SizeFactor { get; set; }

		[Column(Name = "type")]
		public SpriteType Type { get; set; }

		public override string ToString()
		{
			return this.Name;
		}
	}
}