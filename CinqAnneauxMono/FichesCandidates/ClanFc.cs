using CinqAnneaux.Data;
using CinqAnneauxMono.Fiches;
using Core.Contexts;
using CoreMono;
using CoreMono.UI;
using GeonBit.UI;
using GeonBit.UI.Entities;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneauxMono.FichesCandidates
{
	public class ClanFc : AbsFicheCandidate
	{
		private DataList<ClanModel> clanList;
		private DataList<FamilleModel> familyList;
		private DataList<EcoleModel> schoolList;

		private FicheClan _fClan;
		private FicheSchool _fSchool;
		private FicheFamily _fFamily;
		private List<EcoleModel> _schools;
		private List<FamilleModel> _families;

		public ClanFc() : base("Clan")
		{
			const float topHeight = 0.4f;
			const float listWidth = 0.2f;
			//The actual percentage of width size available
			float actualScale = 1f / UserInterface.Active.GlobalScale;

			//INIT ENTITIES
			clanList = new DataList<ClanModel>(new Vector2(0f), Anchor.Center) { Padding = new Vector2(0) };
			familyList = new DataList<FamilleModel>(new Vector2(0f), Anchor.Center) { Padding = new Vector2(0) };
			schoolList = new DataList<EcoleModel>(new Vector2(0f), Anchor.Center) { Padding = new Vector2(0) };
			_fClan = new FicheClan(new Vector2(0f), Anchor.Center);
			_fSchool = new FicheSchool(new Vector2(0f), Anchor.Center);
			_fFamily = new FicheFamily(new Vector2(0f), Anchor.Center);	

			MgSplitEntity splitClan = new MgSplitEntity(new Vector2(0f, topHeight), Anchor.AutoInline)
			{
				MinLeftWidth = 200,
				MaxLeftWidth = 300,
				LeftWidth = listWidth,
				LeftPanel = clanList,
				RightPanel = _fClan
			};
			
			MgSplitEntity splitFamily = new MgSplitEntity(new Vector2(actualScale / 5 * 2, actualScale - topHeight), Anchor.AutoInline)
			{
				MinLeftWidth = 200,
				MaxLeftWidth = 300,
				LeftWidth = listWidth,
				LeftPanel = familyList,
				RightPanel = _fFamily
			};
			
			MgSplitEntity splitSchool = new MgSplitEntity(new Vector2(actualScale / 5 * 3, actualScale - topHeight), Anchor.AutoInline)
			{
				MinLeftWidth = 200,
				MaxLeftWidth = 300,
				LeftWidth = listWidth+0.1f,
				LeftPanel = schoolList,
				RightPanel = _fSchool
			};

			//ADD PANELS
			AddChild(splitClan);
			AddChild(splitFamily);
			AddChild(splitSchool);

			//ADD EVENTS
			clanList.OnItemChanged += ClanList_OnItemChanged;
			familyList.OnItemChanged += FamilyList_OnItemChanged;
			schoolList.OnItemChanged += SchoolList_OnItemChanged;
		}

		public override void LoadData(IJdrContext context)
		{
			clanList.Data = context.UpperContext.Data.GetTable<ClanModel>().OrderBy(n => n.Tag).ToList();
			_families = context.UpperContext.Data.GetTable<FamilleModel>().OrderBy(n => n.Tag).ToList();
			_schools = context.UpperContext.Data.GetTable<EcoleModel>().OrderBy(n => n.Tag).ToList();
		}

		private void ClanList_OnItemChanged(DataList<ClanModel> sender)
		{
			_fClan.SetDisplayedModel(sender.SelectedItem);
			familyList.Data = _families.Where(a => sender.SelectedItem.Id == a.ClanId);
			schoolList.Data = _schools.Where(a => sender.SelectedItem.Id == a.ClanId);
		}

		private void FamilyList_OnItemChanged(DataList<FamilleModel> sender)
		{
			_fFamily.SetDisplayedModel(sender.SelectedItem);
		}

		private void SchoolList_OnItemChanged(DataList<EcoleModel> sender)
		{
			_fSchool.SetDisplayedModel(sender.SelectedItem);
		}
	}
}
