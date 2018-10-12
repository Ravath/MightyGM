using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Competences
{
	public static class CompetenceOptionnelleInstaciator
	{
		public static CompetenceOptionnelle Instanciate(ApprentissageOptionnelExemplar ex)
		{
			switch (ex.Model.Tag)
			{
				default:
					return new CompetenceOptionnelle(ex);
			}
		}
	}
}
