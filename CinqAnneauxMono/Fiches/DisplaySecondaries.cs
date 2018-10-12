using CinqAnneaux.Data;
using CinqAnneaux.JdrCore.Agent;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxMono.Fiches
{
	/// <summary>
	/// Display initiative and armor values
	/// </summary>
	public class DisplaySecondaries : Entity
	{
		public Agent _character;
		public Agent Character
		{
			get { return _character; }
			set
			{
				if(_character == value) { return; }

				_character = value;
				_nd.Value = value.Armures.ND;
				_red.Value = value.Armures.Reduction;
				_init.Roll = value.Initiative;
			}
		}

		private RollAndKeepReader _init = new RollAndKeepReader(null, Anchor.CenterLeft, size:new Vector2(70,0.0f));
		private ValueReader _nd  = new ValueReader(null, Anchor.CenterLeft, size: new Vector2(60, 0.0f));
		private ValueReader _red = new ValueReader(null, Anchor.CenterLeft, size: new Vector2(60, 0.0f));

		public DisplaySecondaries(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			MgGrid grid = new MgGrid(2, 3) { Padding = Vector2.Zero };
			grid.AddEntity(0, 0, new MgParagraph("Initiative", Anchor.Center));
			grid.AddEntity(0, 1, new MgParagraph("ND d'Armure", Anchor.Center));
			grid.AddEntity(0, 2, new MgParagraph("Réduction", Anchor.Center));
			grid.AddEntity(1, 0, _init);
			grid.AddEntity(1, 1, _nd);
			grid.AddEntity(1, 2, _red);

			AddChild(grid);
		}
	}
}
