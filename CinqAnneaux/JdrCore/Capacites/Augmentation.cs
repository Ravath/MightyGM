using CinqAnneaux.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Capacites
{
	public class Augmentation
	{
		public string Description { get; set; }
		public int Cout { get; set; }

		public Augmentation(AugmentationSortExemplar ae)
		{
			Cout = 1;
			object[] args = GetComplement(new FiveRingsComplementParser(ae.Complement));
			Description = String.Format(ae.Model.Description.Description, args);
		}

		public virtual object[] GetComplement(FiveRingsComplementParser cp)
		{
			return cp.Values;
		}

		public static Augmentation GetImplementation(AugmentationSortExemplar ae)
		{
			switch (ae.Model.Tag)
			{
				case "AGS0001":
					return new PorteeAugmentation(ae);
				case "AGS0002":
					return new DureeAugmentation(ae);
				case "AGS0003":
					return new ZoneAugmentation(ae);
				case "AGS0004":
					return new CibleAugmentation(ae);
				case "AGS0005":
					return new DommageAugmentation(ae);
				case "AGS0013":
					return new CiblerAutruiSupplementaireAugmentation(ae);
				case "AGS0016":
					return new CiblerAutruiAugmentation(ae);
				case "AGS0023":
					return new AnneauAugmentation(ae);
				case "AGS0024":
					return new OppositionAugmentation(ae);
				case "AGS0040":
					return new JourAugmentation(ae);
				default:
					return new Augmentation(ae);
			}
		}
	}

	public class PorteeAugmentation : Augmentation
	{
		public double Bonus { get; set; }
		public PorteeAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Bonus = cp.GetDouble(0, 1.5);
			Cout = cp.GetInt(1, 1);
			return new object[] { Bonus, Cout };
		}
	}

	public class DureeAugmentation : Augmentation
	{
		public int Duree { get; set; }
		public DureeAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Duree = cp.GetInt(0, 1);
			Cout = cp.GetInt(1, 1);
			return new object[] { Duree, Cout };
		}
	}

	public class JourAugmentation : DureeAugmentation
	{
		public JourAugmentation(AugmentationSortExemplar ae) : base(ae) { }
	}

	public class ZoneAugmentation : Augmentation
	{
		public double Zone { get; set; }
		public ZoneAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Zone = cp.GetDouble(0, 1.5);
			Cout = cp.GetInt(1, 1);
			return new object[] { Zone, Cout };
		}
	}

	public class CibleAugmentation : Augmentation
	{
		public int Cible { get; set; }
		public CibleAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Cible = cp.GetInt(0, 1);
			Cout = cp.GetInt(1, 1);
			return new object[] { Cible, Cout };
		}
	}

	public class DommageAugmentation : Augmentation
	{
		public RollAndKeep Dommages{ get; set; }
		public DommageAugmentation(AugmentationSortExemplar ae) : base(ae){}

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Dommages = cp.GetPool(0);
			Cout = cp.GetInt(1, 1);
			return new object[] { Dommages, Cout };
		}
	}

	public class NDAugmentation : Augmentation
	{
		public int ND { get; set; }
		public NDAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			ND = cp.GetInt(0, 5);
			return new object[] { ND };
		}
	}

	public abstract class AugmentationCostOnly : Augmentation
	{
		public AugmentationCostOnly(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			Cout = cp.GetInt(0, 1);
			return new object[] { Cout };
		}
	}

	public class CiblerAutruiAugmentation : AugmentationCostOnly
	{
		public CiblerAutruiAugmentation(AugmentationSortExemplar ae) : base(ae) { }
	}
	
	public class CiblerAutruiSupplementaireAugmentation : AugmentationCostOnly
	{
		public CiblerAutruiSupplementaireAugmentation(AugmentationSortExemplar ae) : base(ae) { }
	}

	public class AnneauAugmentation : Augmentation
	{
		public int BonusAnneau { get; set; }
		public Anneau Anneau { get; set; }

		public AnneauAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			BonusAnneau = cp.GetInt(0, 1);
			Anneau = cp.GetEnum<Anneau>(1);
			Cout = cp.GetInt(2, 1);
			return new object[] { BonusAnneau, Anneau, Cout };
		}
	}

	public class OppositionAugmentation : Augmentation
	{
		public RollAndKeep OppositionBonus { get; set; }
		public OppositionAugmentation(AugmentationSortExemplar ae) : base(ae) { }

		public override object[] GetComplement(FiveRingsComplementParser cp)
		{
			OppositionBonus = cp.GetPool(0);
			Cout = cp.GetInt(1, 1);
			return new object[] { OppositionBonus, Cout };
		}
	}
}
