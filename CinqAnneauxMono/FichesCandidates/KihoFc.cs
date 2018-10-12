using CoreMono.UI;
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
	public class KihoFc : AbsFicheCandidate
	{
		private const float listWidth = 300;
		private const float leftpadding = 20;

		private IEnumerable<KihoModel> _kihos;

		private DropDown _dropDown;
		private DataList<KihoModel> _listKiho;
		private FicheKiho _ficheKiho;

		public KihoFc() : base("Kiho")
		{
			float ficheWidth = ComputeFicheWidth(/*Arbitrary value*/ 1000);

			_dropDown = new DropDown() { Anchor = Anchor.TopCenter };
			foreach (var item in typeof(Anneau).GetEnumValues())
			{
				_dropDown.AddItem(item.ToString());
			}
			_dropDown.SelectList.Size = new Vector2(_dropDown.SelectList.Size.X, 300);

			_listKiho = new DataList<KihoModel>(new Vector2(listWidth, 0.8f), Anchor.CenterLeft, new Vector2(leftpadding, 0)) { Padding = new Vector2(0) };
			_listKiho.TextSize = 0.8f;

			_ficheKiho = new FicheKiho(new Vector2(ficheWidth, 0.8f), Anchor.AutoInline);

			AddChild(_listKiho);
			AddChild(_ficheKiho);
			AddChild(_dropDown);

			_listKiho.OnItemChanged += (DataList<KihoModel> sender) => { _ficheKiho.SetDisplayedModel(sender.SelectedItem); };
			_dropDown.OnValueChange = (Entity entity) =>
			{
				Anneau ring = (Anneau)typeof(Anneau).GetEnumValues().GetValue(_dropDown.SelectedIndex);
				_listKiho.Data = _kihos.Where(k => k.Anneau == ring);
			};
		}

		public override void LoadData(IJdrContext context)
		{
			_kihos = context.UpperContext.Data.GetTable<KihoModel>().OrderBy(t => t.Tag);
			_dropDown.SelectedIndex = 0;
		}

		public override Rectangle CalcInternalRect()
		{
			Rectangle ret = base.CalcInternalRect();
			float ficheWidth = ComputeFicheWidth(ret.Width);
			_ficheKiho.Size = new Vector2(ficheWidth, 0.8f);
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
