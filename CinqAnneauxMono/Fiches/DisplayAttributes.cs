using CinqAnneaux.JdrCore.Attributs;
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
	public class DisplayAttributes : Entity
	{
		static float RingSize = 30f;
		private Attributs _attributs;

		//Physical Attributes
		private ValueReader _constitution = new ValueReader(null);
		private ValueReader _reflexes	  = new ValueReader(null);
		private ValueReader _agilite	  = new ValueReader(null);
		private ValueReader _force		  = new ValueReader(null);
		//Mental Attributes
		private ValueReader _volonte	  = new ValueReader(null);
		private ValueReader _intuition	  = new ValueReader(null);
		private ValueReader _intelligence = new ValueReader(null);
		private ValueReader _perception	  = new ValueReader(null);

		//Rings
		private ValueReader _earth  = new ValueReader(null, Anchor.TopLeft, new Vector2(0, RingSize)) { Size = new Vector2(0.2f, RingSize) };
		private ValueReader _air    = new ValueReader(null, Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize) };
		private ValueReader _fire   = new ValueReader(null, Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize) };
		private ValueReader _water  = new ValueReader(null, Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize) };
		private ValueReader _void   = new ValueReader(null, Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize) };

		public Attributs Attributs
		{
			get { return _attributs; }
			set
			{
				if (_attributs == value) { return; }
				_attributs = value;
				//attributs
				_agilite.Value = value.Agilite;
				_constitution.Value = value.Constitution;
				_reflexes.Value = value.Reflexes;
				_force.Value = value.Force;
				_intelligence.Value = value.Intelligence;
				_intuition.Value = value.Intuition;
				_perception.Value = value.Perception;
				_volonte.Value = value.Volonte;
				//anneaux
				_air.Value = value.Air;
				_earth.Value = value.Terre;
				_fire.Value = value.Feu;
				_water.Value = value.Eau;
				//vide
				// TODO When jauge display implemented
				_void.Value = value.Vide.Max;
			}
		}

		public DisplayAttributes(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null) : base(size, anchor, offset)
		{
			AddChild(new MgHeader("Terre",	Anchor.TopLeft)    { Size = new Vector2(0.2f, RingSize), FillColor = Color.Gold });
			AddChild(new MgHeader("Air",	Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize), FillColor = Color.Gold });
			AddChild(new MgHeader("Feu",	Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize), FillColor = Color.Gold });
			AddChild(new MgHeader("Eau",	Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize), FillColor = Color.Gold });
			AddChild(new MgHeader("Vide",	Anchor.AutoInline) { Size = new Vector2(0.2f, RingSize), FillColor = Color.Gold });

			AddChild(_earth);
			AddChild(_air);
			AddChild(_fire);
			AddChild(_water);
			AddChild(_void);

			AddChild(new ValueLabel("Constitution", _constitution,	new Vector2(0.2f, RingSize), Anchor.TopLeft, new Vector2(0f, 2*RingSize)){ TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Reflexes",		_reflexes,		new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Agilite",		_agilite,		new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Force",		_force,			new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });

			AddChild(new ValueLabel("Volonte",		 _volonte,		new Vector2(0.2f, RingSize), Anchor.TopLeft, new Vector2(0f, 3 * RingSize)) { TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Intuition",	 _intuition,	new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Intelligence",	 _intelligence,	new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });
			AddChild(new ValueLabel("Perception",	 _perception,	new Vector2(0.2f, RingSize), Anchor.AutoInline) { TextSize = 0.8f, Padding = new Vector2(20) });

			Size = new Vector2(Size.X, 5 * RingSize);
		}
	}
}
