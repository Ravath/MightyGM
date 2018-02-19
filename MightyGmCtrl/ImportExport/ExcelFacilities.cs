using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.ImportExport
{
	public static class ExcelFacilities
	{
		public static object ConvertFromType(this ICell currentCell, Type t)
		{
			if (currentCell == null)
				return null;
			if (t.IsAssignableFrom(typeof(int)))
			{
				if (currentCell.CellType == CellType.Numeric)
					return (int)currentCell.NumericCellValue;
				else
				{
					if (int.TryParse(currentCell.StringCellValue, out int res))
					{
						return res;
					}
					else
					{
						return null;
					}
				}
			}
			else if (t.IsAssignableFrom(typeof(char)))
			{
				if (currentCell.CellType == CellType.Numeric)
					return (char)currentCell.NumericCellValue;
				else
				{
					if (char.TryParse(currentCell.StringCellValue, out char res))
					{
						return res;
					}
					else
					{
						return null;
					}
				}
			}
			else if (t.IsAssignableFrom(typeof(double)))
			{
				if (currentCell.CellType == CellType.Numeric)
					return (double)currentCell.NumericCellValue;
				else
				{
					if (double.TryParse(currentCell.StringCellValue, out double res))
					{
						return res;
					}
					else
					{
						return null;
					}
				}
			}
			else if (t.IsAssignableFrom(typeof(float)))
			{
				if (currentCell.CellType == CellType.Numeric)
					return (float)currentCell.NumericCellValue;
				else
				{
					if (float.TryParse(currentCell.StringCellValue, out float res))
					{
						return res;
					}
					else
					{
						return null;
					}
				}
			}
			else if (t.IsAssignableFrom(typeof(decimal)))
			{
				if (currentCell.CellType == CellType.Numeric)
					return (decimal)currentCell.NumericCellValue;
				else
				{
					if (decimal.TryParse(currentCell.StringCellValue, out decimal res))
					{
						return res;
					}
					else
					{
						return null;
					}
				}
			}
			else if (t.IsAssignableFrom(typeof(string)))
			{
				return currentCell.StringCellValue;
			}
			else if (t.IsEnum)
			{
				string stringEnum = currentCell.StringCellValue;
				if (string.IsNullOrEmpty(stringEnum))
					return null;
				object enumVal = null;
				try { enumVal = Enum.Parse(t, stringEnum); } catch { }
				return enumVal;
			}
			else if (t.IsAssignableFrom(typeof(bool)))
			{
				return ConvertCellToBoolean(currentCell);
			}
			else
			{
				//Console.WriteLine("Propriété non convertible.");
				return null;
			}
		}

		public static Boolean? ConvertCellToBoolean(this ICell currentCell)
		{
			Boolean? boolVal = null;
			if (currentCell.CellType == CellType.Boolean)
			{
				boolVal = currentCell.BooleanCellValue;
			}
			else if (currentCell.CellType == CellType.Numeric)
			{
				if (currentCell.NumericCellValue <= 0)
					boolVal = false;
				else
					boolVal = true;
			}
			else if (currentCell.CellType == CellType.Blank
				  || currentCell.CellType == CellType.Error
				  || currentCell.CellType == CellType.Unknown)
			{
				boolVal = null;
			}
			else
			{
				if (currentCell.CellType == CellType.String)
					boolVal = (bool)currentCell.StringCellValue.ConvertFromType(typeof(bool));
				else
				{ // is a formula
					string stringBool = currentCell.CellFormula.ToLower();
					if (stringBool.StartsWith("="))
					{
						stringBool = stringBool.Remove(0, 1);
					}
					if (stringBool.EndsWith("()"))
					{
						stringBool = stringBool.Remove(stringBool.Length - 2);
					}
					boolVal = (bool)stringBool.ConvertFromType(typeof(bool));
				}
			}
			return boolVal;
		}

		public static object ConvertFromType(this string str, Type t)
		{
			if (t.IsAssignableFrom(typeof(int)))
			{
				if (int.TryParse(str, out int res))
				{
					return res;
				}
				else
				{
					return null;
				}
			}
			else if (t.IsAssignableFrom(typeof(char)))
			{
				if (char.TryParse(str, out char res))
				{
					return res;
				}
				else
				{
					return null;
				}
			}
			else if (t.IsAssignableFrom(typeof(double)))
			{
				if (double.TryParse(str, out double res))
				{
					return res;
				}
				else
				{
					return null;
				}
			}
			else if (t.IsAssignableFrom(typeof(float)))
			{
				if (float.TryParse(str, out float res))
				{
					return res;
				}
				else
				{
					return null;
				}
			}
			else if (t.IsAssignableFrom(typeof(decimal)))
			{
				if (decimal.TryParse(str, out decimal res))
				{
					return res;
				}
				else
				{
					return null;
				}
			}
			else if (t.IsAssignableFrom(typeof(string)))
			{
				return str;
			}
			else if (t.IsEnum)
			{
				object enumVal = null;
				try { enumVal = Enum.Parse(t, str); } catch { }
				return enumVal;
			}
			else if (t.IsAssignableFrom(typeof(bool)))
			{
				switch (str)
				{
					case "true":
					case "vrai":
					case "oui":
					case "yes":
						return true;
					case "false":
					case "faux":
					case "non":
					case "no":
						return false;
					default: // Console.WriteLine("Pb de conversion de la string '{0}' en bool. false par défaut.", stringBool);
						break;
				}
			}

			//Console.WriteLine("Propriété non convertible.");
			return null;
		}

		public static int FindCell(this IRow header, string pattern)
		{
			for (int i = 0; i <= header.LastCellNum; i++)
			{
				if (pattern == header.GetCell(i)?.StringCellValue)
				{
					return i;
				}
			}
			return -1;
		}

		public static int FindFirstCellStartingWith(this IRow header, string pattern)
		{
			for (int i = 0; i <= header.LastCellNum; i++)
			{
				if (header.GetCell(i)?.StringCellValue.StartsWith(pattern) ?? false)
				{
					return i;
				}
			}
			return -1;
		}
	}
}
