//using Core.Dice;
//using Core.Engine;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DD3OpenGL.Engine {

//	public enum DD {
//		FOR, DEX, CON, INT, SAG, CHA
//	}

//	public class DDAttributes : Attributes {
//		public DDAttributes() : base(typeof(DD), 10) {

//		}

//		public int Modificateur( DD Attribute ) {
//			return GetModificateur(this[Attribute]);
//		}

//		public static int GetModificateur(int Value ) {
//			return (int)Math.Floor((((float)Value - 9.5) / 2));
//		}
//	}

//	public class DefaultAttributeGenerator : IAttributesGenerator {
//		public void GenerateValues( Attributes attributes ) {
//			Pool p = new Pool(3, 6);
//			foreach(DD a in Enum.GetValues(typeof(DD))) {
//				attributes[a] = Roll.Sum(p);
//			}
//		}
//	}
//	public class PJDefaultAttributeGenerator : IAttributesGenerator {
//		public void GenerateValues( Attributes attributes ) {
//			Pool p = new Pool(4, 6);
//			foreach(DD a in Enum.GetValues(typeof(DD))) {
//				attributes[a] = Roll.RollAndKeep(p,3);
//			}
//		}
//	}
//	public class HeroicAttributeGenerator : IAttributesGenerator {
//		public void GenerateValues( Attributes attributes ) {
//			Pool p = new Pool(5, 6);
//			foreach(DD a in Enum.GetValues(typeof(DD))) {
//				attributes[a] = Roll.RollAndKeep(p, 3);
//			}
//		}
//	}
//}
