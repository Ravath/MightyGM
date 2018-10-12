using Core.Contexts;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public abstract class AbsFicheCandidate : Panel
	{
		public AbsFicheCandidate(string name)
			: base(new Vector2(0,0), PanelSkin.Default, Anchor.Center, null)
		{
			Name = name;
			Padding = new Vector2(0, 0);
		}

		public string Name{ get; protected set; }
		
		public abstract void LoadData(IJdrContext context);
	}
}
