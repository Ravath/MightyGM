using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QUT.Gppg;
using System.IO;

namespace DataGenerator.Parser {
	internal partial class Parser {
		#region Properties
		public RawData RawData = new RawData();
		#endregion

		/// <summary>
		/// Constructeur par défaut
		/// </summary>
		internal Parser() : base(null) { }

		/// <summary>
		/// Concatène avec des virgules.
		/// </summary>
		/// <param name="lst"></param>
		/// <returns></returns>
		public string ToList( IEnumerable<string> lst ) {
			StringBuilder sb = new StringBuilder();
			if(lst.Count() >= 1)
				sb.Append(lst.ElementAt(0));
			for(int i = 1; i < lst.Count(); i++) {
				sb.AppendFormat(",{0}", lst.ElementAt(i));
			}
			return sb.ToString();
		}
		/// <summary>
		/// Ecrit les données brutes prélevées dans un fichier.
		/// </summary>
		/// <param name="filePath"></param>
		public void ExtractRawToFile( string filePath ) {
			StringBuilder sb = new StringBuilder();
			sb.AppendLine("Database " + RawData.DatabaseName);
			foreach(RawTable tab in RawData.RawTables) {
				sb.AppendFormat("{0} {1} [{2}]&[{3}](\n", tab.Type, tab.Name, tab.MajorTag, ToList(tab.MinorTags));
				foreach(RawAttribute att in tab.Attributes) {
					sb.AppendFormat("\t{0} ({1}:{6}) {2} [{3};{4}] {5}\n", att.Section, att.Type, att.Name, att.CardMin, att.CardMax, att.Target, att.TypeTag);
				}
				sb.AppendLine(")");
			}
			FileStream fs = new FileStream(filePath, FileMode.Create);
			StreamWriter tw = new StreamWriter(fs);
			tw.Write(sb);
			tw.Close();
		}
		internal class Lexer : QUT.Gppg.AbstractScanner<ValueType, LexLocation> {
			private System.IO.TextReader reader;
			/// <summary>
			/// Constructeur trivial.
			/// </summary>
			/// <param name="reader">Le texte à parser.</param>
			public Lexer( System.IO.TextReader reader ) {
				this.reader = reader;
			}
			/// <summary>
			/// Traitement d'un caractère unique.
			/// </summary>
			/// <returns>Le code du caractere suivant.</returns>
			public override int yylex() {
				{
					char ch;
					int ord = reader.Read();

					//traitement des commentaires à la volée
					if(ord == '/' && reader.Peek() == '/') {//si 2 slashs d'affilée
						do {
							ord = reader.Read();
                        } while(ord != '\n' && ord != -1);//terminer la ligne (ou le fichier)
					}//commentaires multilignes
					else if (ord == '/' && reader.Peek() == '*') {
						do {
							ord = reader.Read();
						} while(ord != -1 && (ord != '*' || reader.Peek() != '/'));//terminer la ligne (ou le fichier)
						if(ord != -1) {//not EOF => '*/'
							reader.Read();//get '/' 
							ord = reader.Read();
						}
					}
					//
					// Must check for EOF
					//
					if(ord == -1)
						return (int)Tokens.EOF;
					else
						ch = (char)ord;
#if DEBUG
					Console.Write(ch);
#endif

					//SPACE
					if(ch == '\n' || ch == '\t' || char.IsWhiteSpace(ch)) {
						return (int)Tokens.SPACE;
					} //DIGIT
					else if(char.IsDigit(ch)) {
						yylval.sVal = char.ConvertFromUtf32(ch);
						return (int)Tokens.LETTER;
					} //LETTER
					else if((ch >= 'a' && ch <= 'z') ||
							(ch >= 'A' && ch <= 'Z')) {
						yylval.sVal = char.ConvertFromUtf32(ch);// char.ToLower(ch));
						return (int)Tokens.LETTER;
					}//OTHER
					else
						switch(ch) {
							case '(':
							case ')':
							case ',':
							case '_':
							case ';':
							case '%':
							case ':':
							case '[':
							case ']':
							case '*':
							case '-':
							case '&':
							return ch;
							default:
							Console.Error.WriteLine("Illegal character '{0}'", ch);
							return yylex();
						}
				}
			}
			/// <summary>
			/// En cas d'erreur, affiche le message dans la console.
			/// </summary>
			/// <param name="format"></param>
			/// <param name="args"></param>
			public override void yyerror( string format, params object[] args ) {
				Console.Error.WriteLine(format, args);
			}
		}

		private class ParserException : Exception {
			public ParserException( string mess ) : base(mess) { }
		}
	}

}
