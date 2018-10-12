using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreMono.UI
{
	public class MgFont
	{
		public static SpriteFont SpriteFont;
		public static string Clean(string toClean)
		{
			if(toClean == null) { return ""; }
			string work = toClean
				.Replace('é', 'e')
				.Replace('É', 'E')
				.Replace('è', 'e')
				.Replace('È', 'E')
				.Replace('ê', 'e')
				.Replace('Ê', 'E')
				.Replace('ë', 'e')
				.Replace('Ë', 'E')
				.Replace('ï', 'i')
				.Replace('Ï', 'I')
				.Replace('î', 'i')
				.Replace('Î', 'I')
				.Replace('ö', 'o')
				.Replace('Ö', 'O')
				.Replace('ô', 'o')
				.Replace('Ô', 'O')
				.Replace('ü', 'u')
				.Replace('Ü', 'U')
				.Replace('û', 'u')
				.Replace('Û', 'U')
				.Replace('ù', 'u')
				.Replace('Ù', 'U')
				.Replace('ä', 'a')
				.Replace('Ä', 'A')
				.Replace('â', 'a')
				.Replace('Â', 'A')
				.Replace('à', 'a')
				.Replace('À', 'A')
				.Replace('ç', 'c')
				.Replace('Ç', 'C')
				.Replace("œ", "oe")
				.Replace("Œ", "Oe")
				.Replace("…", "...")
				.Replace('`', '\'')
				.Replace('’', '\'')
				.Replace('«', '\"')
				.Replace('»', '\"')
				.Replace('‘', '\'')
				.Replace('’', '\'')
				.Replace(' ', ' ');//Non-breaking space (half-space before ':' and the like)
			if (SpriteFont != null)
			{
				foreach (char c in work)
				{
					if( c == '\n' || c == '\r' | c == '\t') { continue; }
					if (!SpriteFont.Characters.Contains(c))
					{
#if DEBUG
						throw new ArgumentException("Character \'" + c + "\' can not be resolved by this SpriteFont");
#endif
					}
				}
			}
			return work;
		}
	}
}
