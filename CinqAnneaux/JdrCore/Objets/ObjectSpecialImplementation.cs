using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CinqAnneaux.Data;

namespace CinqAnneaux.JdrCore.Objets
{
	public static class SpecialImplementation{
		public static ObjectSpecial Get(SpecialObjetExemplar spo)
		{
			switch (spo.Model.Tag)
			{
				default:
					return new ObjectSpecial(spo);
			}
		}
	}


	public class ObjectSpecial
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

		public ObjectSpecial(SpecialObjetExemplar spo)
		{
			Name = spo.Model.Name;
			Description = String.Format(spo.Model.Description.Description, spo.Complement.Split(';'));
		}

		public int GetInt(string compl, int index)
		{
			return int.Parse(compl.Split(';')[index]);
		}
		public RollAndKeep GetDice(string compl, int index)
		{
			string pool = compl.Split(';')[index];
			int roll=0, keep = 0;
			foreach (char sep in new char[] { 'k', 'g' })
			{
				if (pool.Contains(sep))
				{
					int.TryParse(pool.Split(sep)[0], out roll);
					int.TryParse(pool.Split(sep)[1], out keep);
					break;
				}
			}
			return new RollAndKeep(roll, keep);
		}
	}

	//TODO Special objects implementations
	internal class LightArmorMalus : ObjectSpecial
	{
		public LightArmorMalus(SpecialObjetExemplar spo) : base(spo) { }
	}
	internal class HeavyArmorMalus : ObjectSpecial
	{
		public HeavyArmorMalus(SpecialObjetExemplar spo) : base(spo) { }
	}
	internal class HeavyCavalryArmorMalus : ObjectSpecial
	{
		public HeavyCavalryArmorMalus(SpecialObjetExemplar spo) : base(spo) { }
	}

}
