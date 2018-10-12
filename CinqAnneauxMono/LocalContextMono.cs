using CoreMono;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Contexts;
using CoreMono.UI;
using CinqAnneauxMono.FichesCandidates;

namespace CinqAnneauxMono
{
	public class LocalContextMono : IJdrContextMono
	{
		private List<AbsFicheCandidate> _fiches = new List<AbsFicheCandidate>();

		private IGlobalContext _context;
		public LocalContextMono(IGlobalContext context)
		{
			_context = context;

			_fiches.Add(new ClanFc());
			_fiches.Add(new AdvantageFc());
			_fiches.Add(new ObjectFc());
			_fiches.Add(new WeaponFc());
			_fiches.Add(new SkillFc()); 
			_fiches.Add(new KataFc());
			_fiches.Add(new KihoFc());
			_fiches.Add(new TatooFc());
			_fiches.Add(new SpellFc());
			_fiches.Add(new AncestorFc());
			_fiches.Add(new AlternativeSchoolFc());
			_fiches.Add(new AdvancedSchoolFc());
			_fiches.Add(new ShadowlandPowerFc());
			_fiches.Add(new HeroicOpportunityFc());
			_fiches.Add(new ConditionFc());
			_fiches.Add(new ActionFc());
			_fiches.Add(new StatusFc());
			_fiches.Add(new IntrigueFc());
			_fiches.Add(new CreatureFc());
		}

		public IEnumerable<object> FicheCandidates { get { return Fiches; } }

		public IEnumerable<AbsFicheCandidate> Fiches { get { return _fiches; } }

		public void ReportMessage(MessageType type, string Message)
		{
			throw new NotImplementedException();
		}

		public void ReportMessageRef(MessageType type, string reference, params object[] arguments)
		{
			throw new NotImplementedException();
		}
	}
}
