using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Objets
{
	public static class OptEquipmentImplementation
	{
		public static OptEquipment Instanciate(EquipementOptionnelExemplar ex)
		{
			switch (ex.Model.Tag)
			{
				default:
					return new OptEquipment(ex);
			}
		}
	}

	public class OptEquipment
	{
		public OptEquipment(EquipementOptionnelExemplar ex)
		{
			Nombre = ex.nombre;
			Description = String.Format(ex.Model.Description.Description, Nombre);
		}

		public int Nombre { get; private set; }
		public string Description { get; private set; }
	}
}
