using CoreMono.TableTop.Grid;
using CoreMono.TableTop.Grid.Shape;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Core.Map.Grid;

namespace CoreMono.Map.Sprites
{
	/// <summary>
	/// A predefined type of sprite, drawing a terrain with edges.
	/// the edges and a given square sprite depends on the neighbours, and is computed from a sub 3x3 grid for each square.
	/// Each subSquare is deduced from the square base sprite, subdivided in a 4x4 grid.
	/// </summary>
	public class GridComputedSprite : IGridShape<bool>
	{
		#region private Members
		/// <summary>
		/// Temporary File used for differing the loading of the Sprite
		/// </summary>
		private FileStream fileStream;

		private Rectangle _wall, _sample;

		//s: supérieur, i : inférieur, d : droite, g: gauche
		private Rectangle _ciid, _cisd, _cisg, _ciig;//coins internes
		private Rectangle _ceid, _cesd, _cesg, _ceig;//coins externes

		//straight walls : the side they are looking at. (the properties designate the side the wall is looking at => seem inversed)
		private Rectangle _wup, _wdown, _wright, _wleft;

		private Rectangle Wall { get { return _wall; } }
		private Rectangle Sample { get { return _sample; } }
		private Rectangle UpperLeftInnerCorner { get { return _cisg; } }
		private Rectangle LowerLeftInnerCorner { get { return _ciig; } }
		private Rectangle UpperRightInnerCorner { get { return _cisd; } }
		private Rectangle LowerRightInnerCorner { get { return _ciid; } }
		private Rectangle UpperLeftOuterCorner { get { return _cesg; } }
		private Rectangle LowerLeftOuterCorner { get { return _ceig; } }
		private Rectangle UpperRightOuterCorner { get { return _cesd; } }
		private Rectangle LowerRightOuterCorner { get { return _ceid; } }
		private Rectangle LowerWall { get { return _wup; } }
		private Rectangle UpperWall { get { return _wdown; } }
		private Rectangle RightWall { get { return _wleft; } }
		private Rectangle LeftWall { get { return _wright; } }
		#endregion

		#region Public Properties
		public Texture2D Sprite { get; private set; }
		public Color Tint { get; set; }

		public bool OutsideIsWall { get; set; }

		public Rectangle OuterCorner(bool right, bool upper)
		{
			if (right)
			{
				if (upper)
					return UpperRightOuterCorner;
				else
					return LowerRightOuterCorner;
			}
			else
				if (upper)
				return UpperLeftOuterCorner;
			else
				return LowerLeftOuterCorner;
		}
		public Rectangle InnerCorner(bool right, bool upper)
		{
			if (right)
			{
				if (upper)
					return UpperRightInnerCorner;
				else
					return LowerRightInnerCorner;
			}
			else
				if (upper)
				return UpperLeftInnerCorner;
			else
				return LowerLeftInnerCorner;
		}
		#endregion

		#region Init
		public GridComputedSprite(Texture2D sprite)
		{
			InitSprite(sprite);
		}

		public GridComputedSprite(FileStream fileStream)
		{
			this.fileStream = fileStream;
			Sprite = null;
		}

		private void InitSprite(Texture2D sprite)
		{
			Sprite = sprite;
			//TODO : get ride of assumptions
			//assume the sprite is square
			int s = sprite.Height / 4;
			_wall = new Rectangle(0, 0, s, s);
			_sample = new Rectangle(s, 0, 3 * s, s);
			_ciid = new Rectangle(2 * s, 2 * s, s, s);
			_cisd = new Rectangle(2 * s, 3 * s, s, s);
			_cisg = new Rectangle(3 * s, 3 * s, s, s);
			_ciig = new Rectangle(3 * s, 2 * s, s, s);
			_ceid = new Rectangle(1 * s, 3 * s, s, s);
			_cesd = new Rectangle(1 * s, 2 * s, s, s);
			_cesg = new Rectangle(0 * s, 2 * s, s, s);
			_ceig = new Rectangle(0 * s, 3 * s, s, s);
			_wdown = new Rectangle(0 * s, 1 * s, s, s);
			_wright = new Rectangle(1 * s, 1 * s, s, s);
			_wup = new Rectangle(2 * s, 1 * s, s, s);
			_wleft = new Rectangle(3 * s, 1 * s, s, s);
			Tint = Color.White;
		}
		#endregion

		#region SpriteBatch Drawing Local Scope
		/// <summary>
		/// The currently used Sprite Batch where the sprites are drawn.
		/// </summary>
		private SpriteBatch _batch;
		/// <summary>
		/// The map from which the square to draw are deduced.
		/// </summary>
		private SquareGrid<bool> _map;
		/// <summary>
		/// The mobile viewport used to tell where to draw the sub-sprites.
		/// </summary>
		private Rectangle _drawScope;
		/// <summary>
		/// The size of a full square.
		/// </summary>
		private int squareSize;
		/// <summary>
		/// Position of the upper left corner of the grid.
		/// </summary>
		private int offsetX, offsetY;

		private void SetBatch(SpriteBatch batch, GridLayer<bool> grid)
		{
			_batch = batch;
			_map = grid.Grid;
			squareSize = (int)grid.MapScale.SquareSize;
			offsetX = grid.MapScale.OffsetX;
			offsetY = grid.MapScale.OffsetY;
			_drawScope = new Rectangle(0, 0, squareSize / 3, squareSize / 3);
		}
		private void DrawBatch(Rectangle from, int toX, int toY, int subx, int suby)
		{
			_drawScope.X = (squareSize * toX) + (subx * _drawScope.Width)  + offsetX;
			_drawScope.Y = (squareSize * toY) + (suby * _drawScope.Height) + offsetY;
			_batch.Draw(Sprite, _drawScope, from, Tint);
		}
		private bool IsWall(int x, int y)
		{
			// If outside boundaries
			if (x < 0 || y < 0 || x >= _map.Column || y >= _map.Row)
				return OutsideIsWall;
			// Else grid value
			return _map[x, y];
		}
		#endregion

		#region Drawing
		public void Draw(SpriteBatch batch, GridLayer<bool> grid)
		{
			if(Sprite == null)
			{
				InitSprite(Texture2D.FromStream(batch.GraphicsDevice, fileStream));
				fileStream = null;
			}

			SetBatch(batch, grid);
			for (int i = 0; i < grid.Column; i++)
			{
				for (int j = 0; j < grid.Row; j++)
				{
					if (grid.Grid[i, j])
					{
						//coins
						DrawCornerSprite(i, j, true, false);
						DrawCornerSprite(i, j, true, true);
						DrawCornerSprite(i, j, false, false);
						DrawCornerSprite(i, j, false, true);
						//centre
						DrawBatch(Wall, i, j, 1, 1);
						//murs droits
						DrawBatch(IsWall(i, j - 1) ? Wall : LowerWall, i, j, 1, 0);// en haut
						DrawBatch(IsWall(i, j + 1) ? Wall : UpperWall, i, j, 1, 2);// en bas
						DrawBatch(IsWall(i - 1, j) ? Wall : RightWall, i, j, 0, 1);// a droite
						DrawBatch(IsWall(i + 1, j) ? Wall : LeftWall, i, j, 2, 1);// a gauche
					}
				}
			}
		}
		private void DrawCornerSprite(int i, int j, bool right, bool up)
		{
			DrawBatch(GetCornerSprite(i, j, right, up), i, j, right ? 2 : 0, up ? 0 : 2);
		}
		private Rectangle GetCornerSprite(int x, int y, bool right, bool up)
		{
			bool side = IsWall(x + (right ? 1 : -1), y);//gauche ou droite
			bool front = IsWall(x, y + (up ? -1 : 1));//haut ou bas
			bool diag = IsWall(x + (right ? 1 : -1), y + (up ? -1 : 1));//diagonale
			if (!side && !front)
			{//outer corner
				return OuterCorner(right, up);
			}
			else if (side && front)
			{
				if (diag)
				{
					return Wall;
				}
				else
				{//inner corner
					return InnerCorner(right, up);
				}
			}
			else
			{//straight walls
				if (side)
				{//!front
					if (up)
						return LowerWall;
					else
						return UpperWall;
				}
				else
				{//front && !side
					if (right)
						return LeftWall;
					else
						return RightWall;
				}
			}
		} 
		#endregion
	}
}
