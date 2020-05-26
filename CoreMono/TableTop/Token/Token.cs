using CoreMono.TableTop.Token.Shape;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.TableTop.Token
{
	public class Token : Entity
	{
		public ITokenShape Shape { get; set; }

		public Object Object { get; set; }

		public Token()
		{
			Draggable = true;
			//TODO debug : when dragging, mouse event is propaging to TableMap.
			//ClickThrough = true;
		}
		
		protected override void DrawEntity(SpriteBatch spriteBatch, DrawPhase phase)
		{
			if(phase == DrawPhase.Base)
			{
				Shape?.Draw(spriteBatch, this);
			}
		}
	}
}
