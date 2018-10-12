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
	public class DisplayNaturalPowers : Panel
	{
		private const float descHeight = 200f;
		private const float descPadding = 10f;

		private Agent _character;
		public Agent Character
		{
			get { return _character; }
			set
			{
				if (_character == value) { return; }

				if (_character != null)
					_character.OnModelChanged -= Powers_OnModelChanged;
				_character = value;
				if (_character != null)
					_character.OnModelChanged += Powers_OnModelChanged;

				Powers_OnModelChanged(value);
			}
		}

		private MgCompressedList _powers = new MgCompressedList() { Padding = Vector2.Zero };

		public DisplayNaturalPowers(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size ?? new Vector2(-1f),PanelSkin.Default, anchor, offset)
		{
			AddChild(_powers);
		}

		public void Powers_OnModelChanged(Agent agent)
		{
			//Clean Items
			_powers.RemoveAll();

			//Add new items
			float headerHeight = 0f;
			foreach (var item in agent.TraitsCreature.Traits)
			{
				//Create header
				Paragraph header;
				if (String.IsNullOrWhiteSpace(item.Complement))
					header = new MgParagraph(String.Format(" {0}", item.Name));
				else
					header = new MgParagraph(String.Format(" {0}({1})", item.Name, item.Complement));
				header.FillColor = Color.Gray;

				//Add to List
				_powers.AddItem(
					header,
					new MgDescription() { Text = item.Description, Size = new Vector2(0.0f, descHeight), Padding = new Vector2(descPadding) });

				//Stack header height
				header.CalcTextActualRectWithWrap();
				headerHeight += header.GetActualDestRect().Height + header.SpaceAfter.Y;
			}

			//Update Height
			Size = new Vector2(Size.X, headerHeight + descHeight + 2*Padding.Y);
		}
	}
}
