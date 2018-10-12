using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class MgGrid : Entity
	{
		private Entity[,] _array;
		private float[] _width;
		private float[] _height;

		public int GridWidth { get { return _width.Length; } }
		public int GridHeight { get { return _height.Length; } }

		public MgGrid(int arrayWidth, int arrayHeight, Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			SetProportionnal(arrayWidth, arrayHeight);
		}
		public MgGrid(float[] arrayWidth, float[] arrayHeight, Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			SetProportions(arrayWidth, arrayHeight);
		}

		public void SetProportionnal(int arrayWidth, int arrayHeight)
		{
			if(_width == null || _width.Length != arrayWidth)
				_width = new float[arrayWidth];
			if(_height == null || _height.Length != arrayHeight)
				_height = new float[arrayHeight];

			for (int i = 0; i < _width.Length; i++)
			{
				_width[i] = 1.0f / _width.Length;
			}
			for (int i = 0; i < _height.Length; i++)
			{
				_height[i] = 1.0f / _height.Length;
			}

			SetSize();
		}

		public void SetProportions(float[] width, float[] height)
		{
			_width = width;
			_height = height;

			if (Math.Abs( 1 - _width.Sum()) > 0.05)
				throw new ArgumentException("The present implementation can't support a sum size different from 1. Current sum : " + _width.Sum());
			if (Math.Abs(1 - _height.Sum()) > 0.05)
				throw new ArgumentException("The present implementation can't support a sum size different from 1. Current sum : " + _height.Sum());
			foreach (float item in _width.Union(_height))
			{
				if(item>1.0)
					throw new ArgumentException("The present implementation can't support a size greater than 1. Current size : " +item);
			}

			SetSize();
		}

		private void SetSize()
		{
			if(_array == null)
			{
				//cheat in order to ease the algorithm
				_array = new Entity[0, 0];
			}

			//remove previous children  (if any)
			ClearChildren();

			//create new array of children, and keep previous if exists
			Entity[,] newArray = new Entity[GridHeight, GridWidth];
			for (int i = 0; i < Math.Max(_array.GetLength(0), GridHeight); i++)
			{
				for (int j = 0; j < Math.Max(_array.GetLength(1), GridWidth); j++)
				{
					//The 2x2 posible cases computed in boolen
					bool alreadyExists = j < _array.GetLength(1) && i < _array.GetLength(0);
					bool neededToNewOne = j < newArray.GetLength(1) && i < newArray.GetLength(0);

					//gestion of the 2x2 cases
					if (alreadyExists && neededToNewOne)
					{
						newArray[i, j] = _array[i, j];
						newArray[i, j].Size = new Vector2(_width[j], _height[i]);
					}
					else if (alreadyExists && !neededToNewOne)
					{
						/* nothing, because already removed from parent */
					}
					else if (!alreadyExists && neededToNewOne)
					{
						newArray[i, j] = new PanelBase(new Vector2(_width[j], _height[i]), PanelSkin.None, Anchor.AutoInline)
						{
							Padding = Vector2.Zero,
							SpaceAfter = Vector2.Zero
						};
					}
					else if (!alreadyExists && !neededToNewOne)
					{
						/* will never happen */
					}
				}
			}
			_array = newArray;
			
			//Add children
			foreach (Entity item in _array)
			{
				AddChild(item);
			}
		}

		public void AddEntity(int posx, int posy, Entity newChild)
		{
			_array[posy, posx].ClearChildren();
			_array[posy, posx].AddChild(newChild);
		}
	}
}
