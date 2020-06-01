using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreMono.UI;

namespace CoreMono.TableTop.Token
{
	public class TokenLayer : Layer
	{
		private List<Token> _tokens = new List<Token>();

		public TokenLayer(Vector2? size = null, Anchor anchor = Anchor.Center, Vector2? offset = null) : base(size, anchor, offset)
		{

		}

		public void AddToken(Token newToken)
		{
			_tokens.Add(newToken);
			AddChild(newToken); 
		}

		public override void DisplayProperties(PropertyDisplay displayer)
		{
			displayer.ClearChildren();
			displayer.AddChild(new MgHeader("Token Layer"));
		}

		public override void Resize(int col, int row)
		{
			/* Nothing to do */
		}
	}
}
