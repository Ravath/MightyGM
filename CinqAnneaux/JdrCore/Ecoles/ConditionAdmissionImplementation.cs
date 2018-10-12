using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Ecoles
{
	public static class ConditionAdmissionImplementation
	{
		public static ConditionAdmission Instanciate(ConditionAdmissionExemplar spo)
		{
			switch (spo.Model.Tag)
			{
				default:
					return new ConditionAdmission(spo);
			}
		}
	}


	public class ConditionAdmission
	{
		private string _name;
		private string _desc;

		#region Prop
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		public string Description
		{
			get { return _desc; }
			set { _desc = value; }
		}
		#endregion

		public ConditionAdmission(ConditionAdmissionExemplar spo)
		{
			Name = spo.Model.Name;
			Description = String.Format(spo.Model.Description.Description, spo.Valeurs.Split(';'));
		}
	}
}
