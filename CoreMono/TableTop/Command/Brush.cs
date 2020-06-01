using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Command
{
	public enum BrushShape
	{
		Circle, Rectangle, Diamond
	}
	public class Brush<T> where T : struct, IConvertible
	{
		private T _radius;
		public T Radius
		{
			get { return _radius; }
			set { _radius = value; }
		}
		public BrushShape Shape { get; set; }
	}
}
