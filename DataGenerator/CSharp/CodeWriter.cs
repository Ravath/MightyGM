using System.Text;

namespace DataGenerator.CSharp
{
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
		/// <summary>
		/// Add some text after the necessary indentation and return to a new line.
		/// </summary>
		/// <param name="line">Text to Add.</param>
		/// <returns></returns>
		public CodeWriter AddIndLine( string line ) {
			sb.AppendLine(ic + line);
			return this;
		}
		/// <summary>
		/// Add some text after the necessary indentation.
		/// </summary>
		/// <param name="line">Text to Add.</param>
		/// <returns></returns>
		public CodeWriter AddInd( string line ) {
			sb.Append(ic + line);
			return this;
		}
		/// <summary>
		/// Add text.
		/// </summary>
		/// <param name="line">Text to Add.</param>
		/// <returns></returns>
		public CodeWriter Add( string line ) {
			sb.Append(line);
			return this;
		}
		/// <summary>
		/// Add text and return to a new line.
		/// </summary>
		/// <param name="line">Text to Add.</param>
		/// <returns></returns>
		public CodeWriter AddLine( string line ) {
			sb.AppendLine(line);
			return this;
		}
		/// <summary>
		/// New Line.
		/// </summary>
		/// <returns></returns>
		public CodeWriter nl() {
			sb.AppendLine();
			return this;
		}
		/// <summary>
		/// New Line and increase Tabulation.
		/// </summary>
		/// <returns></returns>
		public CodeWriter nlt() {
			sb.AppendLine();
			ic.Count++;
			return this;
		}
		/// <summary>
		/// New Line and decrease Tabulation.
		/// </summary>
		/// <returns></returns>
		public CodeWriter nlut() {
			sb.AppendLine();
			ic.Count--;
			return this;
		}
		/// <summary>
		/// Decrease Tabulation.
		/// </summary>
		/// <returns></returns>
		public CodeWriter ut() {
			ic.Count--;
			return this;
		}
		/// <summary>
		/// Increase Tabulation.
		/// </summary>
		/// <returns></returns>
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
