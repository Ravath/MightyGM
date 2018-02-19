using Core.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinqAnneaux.JdrCore.Attributs {
	/// <summary>
	/// Used for Honneur, Gloire, Status and Souillure.
	/// </summary>
	public class RankedCarac : DerivedValue {

		Value _points;

		public RankedCarac(Value points) : base(points){
			_points = points;
        }
		/// <summary>
		/// Le rang de la caractéristique.
		/// </summary>
		public override int BaseValue {
			get {
				return _points.TotalValue / 10;
			}
		}

		public Value Points { get { return _points; } }
		public void AddRank( int mod ) {
			_points.BaseValue += mod * 10;
        }
		public void AddPoints( int mod ) {
			_points.BaseValue += mod;
		}
		public void SetRank(int rank, int points ) {
			_points.BaseValue = rank * 10 + points;
		}
		public void SetRank( RankedCarac rank ) {
			_points.BaseValue = rank._points.BaseValue;
		}
	}
}
