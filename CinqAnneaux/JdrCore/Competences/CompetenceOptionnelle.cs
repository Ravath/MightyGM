using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Competences
{
	/// <summary>
	/// An optionnal skill from a school at character creation.
	/// </summary>
	public class CompetenceOptionnelle
	{

		public CompetenceOptionnelle(ApprentissageOptionnelExemplar ex)
		{
			Nombre = ex.nombre;
			Description = ex.Model.Description.Description;
		}

		public int Nombre { get; private set; }
		public String Description { get; private set; }
	}
}
