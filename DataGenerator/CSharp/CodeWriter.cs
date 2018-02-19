using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGenerator.CSharp {
	/// <summary>
	/// Sort of specialized string builder for writing code, with indentations (see 't' and 'ut')
	/// </summary>
	public class CodeWriter {
		private StringBuilder sb;
		IndentationCount ic;
		public CodeWriter(StringBuilder sb, IndentationCount ic) {
			this.sb = sb;
			this.ic = ic;
		}

		public CodeWriter AddIndLine( string line ) {
			sb.AppendLine(ic + line);
			return this;
		}
		public CodeWriter AddInd( string line ) {
			sb.Append(ic + line);
			return this;
		}
		public CodeWriter Add( string line ) {
			sb.Append(line);
			return this;
		}
		public CodeWriter AddLine( string line ) {
			sb.AppendLine(line);
			return this;
		}
		public CodeWriter nl() {
			sb.AppendLine();
			return this;
		}
		public CodeWriter nlt() {
			sb.AppendLine();
			ic.Count++;
			return this;
		}
		public CodeWriter nlut() {
			sb.AppendLine();
			ic.Count--;
			return this;
		}
		public CodeWriter ut() {
			ic.Count--;
			return this;
		}
		public CodeWriter t() {
			ic.Count++;
			return this;
		}
		public CodeWriter EndBlock() {
			ic.Count--;
			sb.Append(ic + "}");
			return this;
		}
		private CodeWriter NamedBlockStart( string name ) {
			sb.AppendLine(ic + name + "{");
			ic.Count++;
			return this;
		}
		private CodeWriter NamedBlockStart( string name, string parenthese ) {
			sb.AppendLine(ic + name + "( " + parenthese + " ){");
			ic.Count++;
			return this;
		}
        private CodeWriter NamedBlock( string name, string block ) {
			NamedBlockStart(name);
			AddBlock(block);
			return EndBlock();
        }
		private CodeWriter NamedBlock(string name, string parenthese, string block ) {
			NamedBlockStart(name, parenthese);
			AddBlock(block);
			return EndBlock();
		}
		public CodeWriter AddBlock( string block ) {
			sb.AppendLine(ic + block.Replace("\n", "\n" + ic));
			return this;
		}
		public CodeWriter If( string condition, string block ) {
			return NamedBlock("if", condition, block);
		}
		public CodeWriter ElseIf( string condition, string block ) {
			return NamedBlock("else if", condition, block);
		}

		public CodeWriter Else( string block ) {
			return NamedBlock("else", block);
		}
		public CodeWriter Property(string type, string name, string getBlock, string setBlock ) {
			PropertyStart(type,name);
			Get(getBlock).nl();
			Set(setBlock);
			return nl().EndBlock().nl();
		}
		public CodeWriter PropertyStart( string type, string name ) {
			return NamedBlockStart("public " + type + " " + name);
		}
		public CodeWriter Foreach( string parenthese, string block ) {
			ForeachStart(parenthese);
			return AddBlock(block).nl().EndBlock().nl();
            //return NamedBlock("foreach",parenthese, block);
		}
		public CodeWriter ForeachStart( string parenthese ) {
			return NamedBlockStart("foreach", parenthese );
		}
		public CodeWriter GetStart() {
			return NamedBlockStart("get");
		}
		public CodeWriter SetStart() {
			return NamedBlockStart("set");
		}
		public CodeWriter Get( string block ) {
			return NamedBlock("get", block);
		}
		public CodeWriter Set( string block ) {
			return NamedBlock("set", block);
		}
	}
}
