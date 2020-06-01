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
using Core.Map.Grid;

namespace CoreMono.TableTop.Grid
{
	public class GridLayer<T> : Layer
	{
		public IGridShape<T> Shape { get; set; }
		public SquareGrid<T> Grid { get; private set; }
		public int Column { get { return Grid.Column; } }
		public int Row { get { return Grid.Row; } }

		public GridLayer(int col, int row, IGridShape<T> drawer, Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{
			Grid = new SquareGrid<T>(col, row);
			Shape = drawer;
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
		public void SetMap(T setValue)
		{
			Grid.SetMap(setValue);
		}

		/// <summary>
		/// Check if the given grid coordinates are within the grid.
		/// Index starts at 0.
		/// </summary>
		/// <param name="p">Grid coordinates.</param>
		/// <returns>True if is within the grid board.</returns>
		public bool Contains(Point p)
		{
			return Grid.Contains(p.X, p.Y);
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
			x = (int)((windowCoordinate.X - MapScale.OffsetX) / MapScale.SquareSize);
			y = (int)((windowCoordinate.Y - MapScale.OffsetY) / MapScale.SquareSize);
			return Grid.Contains(x,y);
		}

		public override void Resize(int col, int row)
		{
			Grid.Resize(col, row);
		}

		#region Display Properties
		public override void DisplayProperties(PropertyDisplay displayer)
		{
			displayer.ClearChildren();
			AddGridShapesSelection(displayer);
			displayer.AddChild(new MgHeader("Shape"));
			displayer.AddObject(Shape);
			displayer.AddChild(new MgHeader("Dimensions"));
			displayer.AddProperty(typeof(GridLayer<T>).GetProperty("Column"), this);
			displayer.AddProperty(typeof(GridLayer<T>).GetProperty("Row"), this);
		}

		private void AddGridShapesSelection(PropertyDisplay displayer)
		{
			// TODO do gestion of multiple values types
			// Can only to 'boolean' for now
			if (typeof(T) != typeof(bool))
				return;

			DropDown sl = new DropDown();
			sl.AddItem(Enum.GetNames(typeof(GridShapeE)));

			if (Shape.GetType() == typeof(GridTint))
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
			else if (Shape.GetType() == typeof(GridShape<bool>))
			{
				sl.SelectedIndex = (int)GridShapeE.Grid;
			}

			sl.OnValueChange = (e) =>
			{
				switch (sl.SelectedIndex)
				{
					case -1:
						return;
					case (int)GridShapeE.Grid:
						Shape = (IGridShape<T>)new GridShape<bool>(Color.Black);
						break;
					case (int)GridShapeE.Tint:
						Shape = (IGridShape<T>)new GridTint(Color.Red);
						break;
					case (int)GridShapeE.Sprite:
						Shape = (IGridShape<T>)new GridSprite(File.OpenRead("Floor_II.jpg"), 4, 4);
						break;
					case (int)GridShapeE.ComputedSprite:
						Shape = (IGridShape<T>)new GridComputedSprite(File.OpenRead("TilesI_wb.png"));
						break;
					default:
						throw new Exception("Not implemented Grid Shape");
				}
				DisplayProperties(displayer);
			};
			displayer.AddChild(sl);
		}
		#endregion
	}
}
