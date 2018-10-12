using CinqAnneaux.JdrCore.Agent;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CinqAnneauxMono.Fiches
{
	public class DisplayLife : Entity
	{
		private const float ColumnWidth = 100f;
		private const float StatesWidth = 200f;
		private const float LineHeight = 1.0f/9;

		private MgGrid _grid = new MgGrid(
			new float[] { 0.2f, 0.1f, 0.2f, 0.5f },
			new float[] { LineHeight, LineHeight, LineHeight, LineHeight, LineHeight, LineHeight, LineHeight, LineHeight, LineHeight })
		{ Padding = Vector2.Zero };

		MgParagraph _tThresh;
		MgParagraph _tMalus;

		private Paragraph _malus;
		private Paragraph _slash;
		private ValueReader _wounds;
		private ValueReader _maxWounds;

		private List<Paragraph> _levels = new List<Paragraph>();
		private List<Paragraph> _levelMalus = new List<Paragraph>();
		private Paragraph[] _states = new Paragraph[]
		{
			new MgParagraph("Indemne")          { Anchor=Anchor.CenterLeft },
			new MgParagraph("Egratigné")        { Anchor=Anchor.CenterLeft },
			new MgParagraph("Légèrement Blessé"){ Anchor=Anchor.CenterLeft },
			new MgParagraph("Blessé")           { Anchor=Anchor.CenterLeft },
			new MgParagraph("Gravement Blessé") { Anchor=Anchor.CenterLeft },
			new MgParagraph("Impotent")         { Anchor=Anchor.CenterLeft },
			new MgParagraph("Epuisé")           { Anchor=Anchor.CenterLeft },
		};

		public DisplayLife(Anchor anchor = Anchor.Auto, Vector2? offset = null, Vector2? size = null) : base(size, anchor, offset)
		{

			// First Line : Lige jauge and malus => [ Wounds / Max  (-Malus) ]
			_wounds		= new ValueReader(null, Anchor.CenterRight);
			_slash		= new MgParagraph("/" , Anchor.Center);
			_maxWounds	= new ValueReader(null, Anchor.CenterLeft);
			_malus		= new MgParagraph(null, Anchor.CenterLeft) { ToolTipText = "Malus de Blessures" };

			_grid.AddEntity(0, 0, _wounds);
			_grid.AddEntity(1, 0, _slash);
			_grid.AddEntity(2, 0, _maxWounds);
			_grid.AddEntity(3, 0, _malus);

			// Second Line : Thresholds column names
			_tThresh = new MgParagraph("Paliers", Anchor.Center);
			_tMalus = new MgParagraph("Malus", Anchor.Center);

			_grid.AddEntity(0, 1, _tThresh);
			_grid.AddEntity(2, 1, _tMalus);

			// Completion
			TextSize = 0.8f;
			AddChild(_grid);
		}

		private float _textSize;
		public float TextSize
		{
			get { return _textSize; }
			set
			{
				_textSize = value;

				_tThresh.Scale = value;
				_tMalus.Scale = value;
				_malus.Scale = value;
				_slash.Scale = value;
				_wounds.TextSize = value;
				_maxWounds.TextSize = value;

				foreach (var item in _levelMalus.Union(_levels).Union(_states))
				{
					item.Scale = value;
				}
			}
		}

		private SeuilVie _life;

		public SeuilVie Life
		{
			get { return _life; }
			set
			{
				if (value == _life) { return; }

				//swap
				if (_life != null)
					_life.DegatsValue.ValueChanged -= DegatsValue_ValueChanged;
				_life = value;
				_life.DegatsValue.ValueChanged += DegatsValue_ValueChanged;

				//values
				_wounds.Value = _life.DegatsValue;
				_maxWounds.Value = _life.DeathThresholdValue;
				_malus.Text = "(" + _life.Malus + ")";

				//make array
				ClearArray();
				int stack = 2;
				foreach (var item in _life.Seuils)
				{
					_levels		.Add(new Paragraph(item.Item1.ToString(), Anchor.Center));
					_levelMalus .Add(new Paragraph(item.Item2.ToString(), Anchor.Center));
					stack++;
				}

				//add to display
				for (int i = 0; i < _levels.Count; i++)
				{
					_levels[i].Scale = _textSize;
					_levelMalus[i].Scale = _textSize;
					_states[i].Scale = _textSize;

					_grid.AddEntity(0, 2+i, _levels[i]);
					_grid.AddEntity(2, 2+i, _levelMalus[i]);
					_grid.AddEntity(3, 2+i, _states[i]);
				}

				//Display states names if not uses specific thresholds
				foreach (var item in _states)
				{
					item.Visible = !(value is SeuilVieCreature);
				}
			}
		}

		private void ClearArray()
		{
			foreach (var item in _states)
			{
				item.RemoveFromParent();
			}
			foreach (var item in _levelMalus.Union(_levels))
			{
				item.RemoveFromParent();
			}
			_levelMalus.Clear();
			_levels.Clear();
		}

		private void DegatsValue_ValueChanged(Core.Engine.IValue ival, int newValue, int oldValue)
		{
			_malus.Text = "(" + _life.Malus + ")";
		}
	}
}

