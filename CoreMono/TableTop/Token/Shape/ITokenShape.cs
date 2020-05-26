using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Token.Shape
{
	public interface ITokenShape
	{
		void Draw(SpriteBatch batch, Token token);
	}
}
