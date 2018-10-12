﻿using CoreMono.UI;
using System.Linq;
using Core.Contexts;
using CinqAnneaux.Data;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using CinqAnneauxMono.Fiches;
using System.Collections.Generic;

namespace CinqAnneauxMono.FichesCandidates
{
	public class AdvancedSchoolFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<EcoleAvanceeModel> _schools;

		private DataList<EcoleAvanceeModel> _listSchool;
		private FicheAdvancedSchool _ficheSchool;

		public AdvancedSchoolFc() : base("Ecole Avancee")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_listSchool = new DataList<EcoleAvanceeModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listSchool.TextSize = 0.8f;

			_ficheSchool = new FicheAdvancedSchool(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listSchool);
			AddChild(_ficheSchool);

			_listSchool.OnItemChanged += (DataList<EcoleAvanceeModel> sender) => { _ficheSchool.SetDisplayedModel(sender.SelectedItem); };
		}

		public override void LoadData(IJdrContext context)
		{
			_schools = context.UpperContext.Data.GetTable<EcoleAvanceeModel>().OrderBy(t => t.Tag);
			_listSchool.Data = _schools;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheSchool.Size = new Vector2(ficheWidth, 0.8f);
			return ret;
		}

		private float ComputeFicheWidth(float destinationWidth)
		{
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;
			return (destinationWidth * actualScale) - 2 * leftpadding - listWidth;
		}
	}
}