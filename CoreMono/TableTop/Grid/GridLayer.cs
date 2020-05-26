using CoreMono.TableTop.Grid.Shape;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using CoreMono.UI;
using CoreMono.Map.Sprites;
using System.IO;

namespace CoreMono.TableTop.Grid
{
	public class GridLayer : TableLayer
	{
		public IGridShape Shape { get; set; }
		public bool[,] Map { get; private set; }
		public int Column { get { return Map.GetLength(0); } }
		public int Row { get { return Map.GetLength(1); } }
		public int SquareSize { get; set; }

		public GridLayer(int col, int row, IGridShape drawer, int squareSize = 30, Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{
			Map = new bool[col, row];
			Shape = drawer;
			SquareSize = squareSize;
		}

		protected override void DrawEntity(SpriteBatch spriteBatch, DrawPhase phase)
		{
			if (phase == DrawPhase.Base)
			{
				Shape?.Draw(spriteBatch, this);
			}
		}

		/// <summary>
		/// Initialize the whole array to the given value.
		/// </summary>
		/// <param name="setValue"></param>
		public void SetMap(Boolean setValue)
		{
			for (int i = 0; i < Column; i++)
			{
				for (int j = 0; j < Row; j++)
				{
					Map[i, j] = setValue;
				}
			}
		}

		/// <summary>
		/// Check if the given grid coordinates are within the grid.
		/// </summary>
		/// <param name="p">Grid coordinates.</param>
		/// <returns>True if is within the grid board.</returns>
		public bool Contains(Point p)
		{
			return !(p.X < 0 || p.Y < 0 || p.Y >= Row || p.X >= Column);
		}

		/// <summary>
		/// Converts a point on the screen to a grid coordinate.
		/// </summary>
		/// <param name="windowCoordinate">A point on the screen.</param>
		/// <param name="x">The Grid X axis convertion.</param>
		/// <param name="y">The Grid Y axis convertion.</param>
		/// <returns>True if the point is within the grid.</returns>
		public bool GetCoordinate(Point windowCoordinate, out int x, out int y)
		{
			x = (windowCoordinate.X - InternalDestRect.X) / SquareSize;
			y = (windowCoordinate.Y - InternalDestRect.Y) / SquareSize;
			return x < Column && y < Row && x >= 0 && y >= 0;
		}

		public override void DisplayProperties(PropertyDisplay displayer)
		{
			displayer.ClearChildren();
			AddGridShapesSelection(displayer);
			displayer.AddChild(new MgHeader("Shape"));
			displayer.AddObject(Shape);
			displayer.AddChild(new MgHeader("Dimensions"));
			displayer.AddProperty(typeof(GridLayer).GetProperty("Column"), this);
			displayer.AddProperty(typeof(GridLayer).GetProperty("Row"), this);
			displayer.AddProperty(typeof(GridLayer).GetProperty("SquareSize"), this);
		}

		private void AddGridShapesSelection(PropertyDisplay displayer)
		{
			DropDown sl = new DropDown();
			sl.AddItem(Enum.GetNames(typeof(GridShapeE)));
			
			if(Shape.GetType() == typeof(GridTint))
			{
				sl.SelectedIndex = (int)GridShapeE.Tint;
			}
			else if (Shape.GetType() == typeof(GridSprite))
			{
				sl.SelectedIndex = (int)GridShapeE.Sprite;
			}
			else if (Shape.GetType() == typeof(GridComputedSprite))
			{
				sl.SelectedIndex = (int)GridShapeE.ComputedSprite;
			}

			sl.OnValueChange = (e) =>
			{
				switch (sl.SelectedIndex)
				{
					case -1:
						return;
					case (int)GridShapeE.Tint:
						Shape = new GridTint(Color.Red);
						break;
					case (int)GridShapeE.Sprite:
						Shape = new GridSprite(File.OpenRead("Floor_II.jpg"), 4, 4);
						break;
					case (int)GridShapeE.ComputedSprite:
						Shape = new GridComputedSprite(File.OpenRead("TilesI_wb.png"));
						break;
					default:
						throw new Exception("Not implemented Grid Shape");
				}
				DisplayProperties(displayer);
			};
			displayer.AddChild(sl);
		}
	}
}
