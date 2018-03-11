using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dice
{
	/// <summary>
	/// The interpretation of a rolled die.
	/// </summary>
	public class DiceResult
	{
		/// <summary>
		/// The result of the die.
		/// </summary>
		public int result;
		/// <summary>
		/// True if this die has to be used in the final result.
		/// </summary>
		public bool kept;
	}

	/// <summary>
	/// A pool and result of dice roll. used to implement a Decorator pattern for composing a roll formula.
	/// </summary>
	public interface IRoll
	{
		/// <summary>
		/// The number of faces the dice of the pool have.
		/// </summary>
		int NbrFace { get; }
		/// <summary>
		/// The final interpretation of the roll.
		/// </summary>
		int NetResult { get; }
		/// <summary>
		/// The raw result of the roll.
		/// </summary>
		IEnumerable<DiceResult> Result { get; }
		/// <summary>
		/// Throw the pool, and operate result.
		/// </summary>
		/// <returns></returns>
		List<DiceResult> Roll();
	}

	/// <summary>
	/// A Pool of dice to roll. The result is the sum of every kept die.
	/// </summary>
	public class Pool : IRoll
	{
		private List<DiceResult> _result = new List<DiceResult>();

		public IValue NbrDice { get; private set; }
		public int NbrFace { get; set; }
		public int NetResult { get { return _result.Sum(a => a.kept ? a.result : 0); } }
		public IEnumerable<DiceResult> Result { get { return _result; } }

		public Pool(IValue nbrDice, int nbrFace) { NbrDice = nbrDice; NbrFace = nbrFace; }
		public Pool(int nbrDice, int nbrFace) : this(new Value(nbrDice), nbrFace) { }

		public List<DiceResult> Roll()
		{
			_result.Clear();
			for (int i = 0; i < NbrDice.TotalValue; i++)
			{
				_result.Add(new DiceResult()
				{
					result = Dice.Roll.RollD(NbrFace),
					kept = true
				});
			}
			return _result;
		}
	}

	/// <summary>
	/// Decorator base class.
	/// </summary>
	public abstract class RollResult : IRoll
	{
		public IRoll Prev { get; set; }
		public int NbrFace { get { return Prev.NbrFace; } }
		public virtual int NetResult { get { return Prev.NetResult; } }
		public IEnumerable<DiceResult> Result { get { return Prev.Result; } }

		public RollResult(IRoll prev)
		{
			Prev = prev;
		}

		public virtual List<DiceResult> Roll() { return Prev.Roll(); }
	}

	public class CountOp : RollResult
	{
		public CountOp(IRoll prev) : base(prev) {}
		public override int NetResult { get { return Result.Count(r=>r.kept); } }
	}

	public class AddOp : RollResult
	{
		public Value Bonus { get; set; }
		public AddOp(IRoll prev, Value add) : base(prev) { Bonus = add; }
		public AddOp(IRoll prev, int add) : this(prev, new Value(add)) {}
		public override int NetResult { get { return Prev.NetResult+Bonus.TotalValue; } }
	}

	public abstract class IndividualFilterOp : RollResult
	{
		public IndividualFilterOp(IRoll prev) : base(prev){}

		public override List<DiceResult> Roll()
		{
			var res = Prev.Roll();
			foreach (var item in res)
			{
				if (item.kept)
				{
					item.kept = Keep(item);
				}
			}
			return res;
		}
		public abstract bool Keep(DiceResult result);
	}

	public abstract class KeepThreshold : IndividualFilterOp
	{
		public int Threshold { get; set; }
		public KeepThreshold(IRoll prev, int threshold) : base(prev){ Threshold = threshold; }
	}

	public class KeepHigherThan : KeepThreshold
	{
		public KeepHigherThan(IRoll prev, int threshold) : base(prev, threshold) { }
		public override bool Keep(DiceResult result)
		{
			return result.result >= Threshold;
		}
	}

	public class KeepLowerThan : KeepThreshold
	{
		public KeepLowerThan(IRoll prev, int threshold) : base(prev, threshold) { }
		public override bool Keep(DiceResult result)
		{
			return result.result <= Threshold;
		}
	}

	public abstract class GeneralFilterOp : RollResult
	{
		public GeneralFilterOp(IRoll prev) : base(prev) { }

		public override List<DiceResult> Roll()
		{
			var res = Prev.Roll();
			Filter(res.Where(r => r.kept == true).ToList());
			return res;
		}

		public abstract void Filter(IEnumerable<DiceResult> enumerable);
	}

	public abstract class KeepDiceNumber : GeneralFilterOp
	{
		public IValue Number { get; set; }
		public KeepDiceNumber(IRoll prev, IValue number) : base(prev) { Number = number; }
	}

	public class KeepHighestDice : KeepDiceNumber
	{
		public KeepHighestDice(IRoll prev, IValue number) : base(prev, number) {}

		public override void Filter(IEnumerable<DiceResult> enumerable)
		{
			var sorted = enumerable.OrderByDescending(r => r.result);
			for (int i = Number.TotalValue; i < sorted.Count(); i++)
			{
				sorted.ElementAt(i).kept = false;
			}
		}
	}

	public class KeepLowestDice : KeepDiceNumber
	{
		public KeepLowestDice(IRoll prev, IValue number) : base(prev, number) { }

		public override void Filter(IEnumerable<DiceResult> enumerable)
		{
			var sorted = enumerable.OrderBy(r => r.result);
			for (int i = Number.TotalValue; i < sorted.Count(); i++)
			{
				sorted.ElementAt(i).kept = false;
			}
		}
	}

	public abstract class ReRollOp : RollResult
	{
		public bool RerollOnce { get; set; }

		public ReRollOp(IRoll prev) : base(prev) { RerollOnce = false; }

		public override List<DiceResult> Roll()
		{
			List<DiceResult> res = Prev.Roll();
			int nbrdice = res.Count;
			for (int i = 0; i < (RerollOnce? nbrdice : res.Count); i++)
			{
				if (res[i].kept)
				{
					if (DoReroll(res[i]))
					{
						res[i].kept = false;
						res.Add(new DiceResult()
						{
							kept = true,
							result = Dice.Roll.RollD(NbrFace)
						});
					}
				}
			}
			return res;
		}

		public abstract bool DoReroll(DiceResult res);
	}

	public abstract class RerollThreshold : ReRollOp
	{
		public int Threshold { get; set; }
		public RerollThreshold(IRoll prev, int threshold) : base(prev) { Threshold = threshold; }
	}

	public class RerollHigherThan : RerollThreshold
	{
		public RerollHigherThan(IRoll prev, int threshold) : base(prev, threshold) {}
		public override bool DoReroll(DiceResult res){ return res.result >= Threshold; }
	}

	public class RerollLowerThan : RerollThreshold
	{
		public RerollLowerThan(IRoll prev, int threshold) : base(prev, threshold) { }
		public override bool DoReroll(DiceResult res) { return res.result <= Threshold; }
	}

	public abstract class ExplodeOp : RollResult
	{
		public bool RerollOnce { get; set; }

		public ExplodeOp(IRoll prev) : base(prev) { RerollOnce = false; }

		public override List<DiceResult> Roll()
		{
			List<DiceResult> res = Prev.Roll();
			int nbrdice = res.Count;
			for (int i = 0; i < nbrdice; i++)
			{
				if (res[i].kept)
				{
					int r = 0;
					int relance = res[i].result;

					while (DoReroll(relance, r) && (!RerollOnce||r==0))
					{
						relance = Dice.Roll.RollD(NbrFace);
						res[i].result += relance;
						r++;
					}
				}
			}
			return res;
		}

		public abstract bool DoReroll(int diceResult, int nbrofReroll);
	}

	public abstract class ExplodeThreshold : ExplodeOp
	{
		public int Threshold { get; set; }
		public ExplodeThreshold(IRoll prev, int threshold) : base(prev) { Threshold = threshold; }
	}
	public class ExplodeHigherThan : ExplodeThreshold
	{
		public ExplodeHigherThan(IRoll prev, int threshold) : base(prev, threshold) {}
		public override bool DoReroll(int diceResult, int nbrofReroll){ return diceResult >= Threshold; }
	}
	public class ExplodeLowerThan : ExplodeThreshold
	{
		public ExplodeLowerThan(IRoll prev, int threshold) : base(prev, threshold) { }
		public override bool DoReroll(int diceResult, int nbrofReroll) { return diceResult <= Threshold; }
	}

	/// <summary>
	/// Used in a succession of roll operations in order to skip some of them.
	/// </summary>
	public class OptionalOp : RollResult
	{
		public bool DoOp { get; set; }
		public IRoll Option { get; set; }

		public OptionalOp(IRoll prev, IRoll optionalOp) : base(prev) { Option = optionalOp; }

		public override List<DiceResult> Roll()
		{
			if (DoOp)
			{
				return Option.Roll();
			}
			else
			{
				return Prev.Roll();
			}
		}
	}
}