using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataGenerator.Parser;

namespace DataGenerator.DataModel {
	public abstract class AbsAttribute : DataConstructor {
		public string Name { get; set; }

		public override void ToConsole() {
			Console.WriteLine("\t" + Name);
		}
	}

	public class EnumAttribute : AbsAttribute {
		public override bool CheckIntegrity() {/*nothing*/ return true; }
	}

	public class DiceAttribute : EnumAttribute {
		public int Odds { get; set; }

		public override bool CheckIntegrity() {
			if(Odds < 0) {
				ErrorManager.Error("The odds of " + Name + " are not positive.");
				return false;
			}
			return true;
		}
	}

	public enum Section {
		Model, Exemplar, Description, None
	}
	public enum Number {
		Opt = 0, One = 1, Many = 2
	}
	public enum Cardinalite {
		OneToOne, OneToMany, ManyToOne, ManyToMany
	}

	public class ValueAttribute : AbsAttribute {

		#region Members
		#endregion

		#region Properties
		public bool Optionnal {
			get { return CardMin == Number.Opt; }
		}
		public Section Section { get; private set; }
		public Number CardMin { get; private set; }
		public Number CardMax { get; private set; }
		public ValueType Type { get; set; }
		public bool IsReference {
			get { return Type.Type == AttributeTypeEnum.Ref || Type.Type == AttributeTypeEnum.Refex; }
		}
		public bool IsEnum {
			get { return Type.Type == AttributeTypeEnum.Enum; }
		}
		public bool IsManyToMany {
			get {
				if(!IsReference) { return false; }//if not reference, can only be one to one or one to many
				ReferenceType rf = Type as ReferenceType;
				if(rf == null)
					return false;
				return CardMax == Number.Many && rf.ReferencedAttribute.CardMax == Number.Many;
			}
		}
		#endregion

		#region Init
		public ValueAttribute() : base() { }
		public ValueAttribute( RawAttribute raw ) : this() {
			Number min = Cardinalite(raw.CardMin);
			Number max = Cardinalite(raw.CardMax);
			if((int)min > (int)max) {
				ErrorManager.Error("La cardinalité de " + raw.Name + " a été inversée.");
			}
			Section = GetDomain(raw.Section);
			CardMin = min;
			CardMax = max;
			Name = raw.Name;
		}
		#endregion

		public static Section GetDomain( string dom ) {
			if(string.IsNullOrWhiteSpace(dom))
				return Section.Model;
			switch(dom.ToLower()) {
				case "model":
				return Section.Model;
				case "exemplar":
				return Section.Exemplar;
				case "description":
				return Section.Description;
				default:
				return Section.Model;
			}
		}
		public static Number Cardinalite( string card ) {
			if(string.IsNullOrWhiteSpace(card))
				return Number.One;
			switch(card) {
				case "0":
				return Number.Opt;
				case "1":
				return Number.One;
				case "*":
				return Number.Many;
				default:
				return Number.One;
			}
		}

		public override bool CheckIntegrity() {
			bool integrity = true;
			if(CardMin == Number.Many || CardMax == Number.Opt) {
				Console.WriteLine("Error in Cardinality of " + Name);
				integrity = false;
			}
			return integrity;
		}
	}
}
