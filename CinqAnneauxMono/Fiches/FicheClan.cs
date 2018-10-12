using CinqAnneaux.Data;
using CoreMono.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;

namespace CinqAnneauxMono.Fiches
{
	public class FicheClan : FicheModel<ClanModel>
	{
		private Header _clanName = new MgHeader();
		private Paragraph _clanDescription = new MgParagraph();

		public FicheClan(Vector2? size = null, Anchor anchor = Anchor.Auto, Vector2? offset = null)
			: base(size, anchor, offset)
		{
			AddChild(_clanName);
			AddChild(_clanDescription);
		}

		protected override void SetModel(ClanModel clan)
		{
			_clanName.Text = clan.Name;
			_clanDescription.Text = clan.Description.Description;
		}

		protected override void SetNoObject()
		{
			_clanName.Text = "Clan";
			_clanDescription.Text = "";
		}
	}
}
