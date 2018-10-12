using CinqAnneaux.JdrCore.Agent;
using CinqAnneaux.JdrCore.Objets;
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
	public class DisplayAttacks : Entity
	{
		private Agent _character;
		public Agent Character
		{
			get { return _character; }
			set
			{
				if (_character == value) { return; }

				if(_character != null)
					_character.OnModelChanged -= Weapons_OnModelChanged;
				_character = value;
				if (_character != null)
					_character.OnModelChanged += Weapons_OnModelChanged;

				Weapons_OnModelChanged(value);
			}
		}

		private Paragraph _naturalWeapons = new MgTextInsert("", Anchor.TopLeft);

		public DisplayAttacks(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			AddChild(_naturalWeapons);
		}

		private void Weapons_OnModelChanged(Agent agent)
		{
			if(agent == null)
			{
				_naturalWeapons.Text = "";
			}
			else
			{
				StringBuilder sb = new StringBuilder("Attaques Naturelles");
				foreach (var item in agent.Armes.NaturalAttacks)
				{
					sb.AppendFormat("\n - {0} {1} {2} Degats : {3}", item.Name, item.Action, item.JetAttaque.ToString(), item.Degats.ToString());
				}
				_naturalWeapons.Text = sb.ToString();
			}
		}
	}
}
