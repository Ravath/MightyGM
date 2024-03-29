﻿using NPOI.SS.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MightyGmCtrl.ImportExport
{
	public abstract class ExcelDataInterface
	{
		public IWorkbook Workbook { get; set; }

		private const int letterNb = 26;
		public string GetColumnName(int index)
		{
			string name = "";
			char letter;
			while (index >= letterNb)
			{
				letter = 'A';
				letter += ((char)(index % letterNb));
				name = letter + name;
				//name = name.Insert(name.Length, letter.ToString());
				index /= letterNb;
				index--;
			}
			letter = 'A';
			letter += ((char)(index % letterNb));
			name = letter + name;
			return name;
		}


	}

	/// <summary>
	/// Check the validity of an excel file before import.
	/// </summary>
	public class ImportChecker : ExcelDataInterface
	{

		private List<string> _errors = new List<string>();

		public int ErrorCount
		{
			get
			{
				return _errors.Count;
			}
		}

		public IEnumerable<string> Errors
		{
			get
			{
				return _errors;
			}
		}

		public ImportChecker()
		{

		}
		/// <summary>
		/// Check the excel file and update the error list.
		/// </summary>
		/// <returns>false if fatal errors found.</returns>
		public bool CheckFile()
		{
			/* init error reports */
			_errors.Clear();

			/* check file */
			if (Workbook == null)
			{
				_errors.Add("File not found.");
				return false;
			}

			/* begin check */
			bool fatalFound = false;

			for (int i = 1/*skip summary*/; i < Workbook.NumberOfSheets; i++)
			{
				ISheet sheet = Workbook.GetSheetAt(i);
				IRow firstRow = sheet.GetRow(ExportExcel.NBR_LIGNES_HEADER-1/*0-based*/);

				/* Check there are at least 2 rows.
				 * which is, in fact, only due to formatting. */
				if (sheet.LastRowNum < ExportExcel.NBR_MIN_COL_HEADER - 1/*0-based*/)
				{
					AddError(sheet, 0, sheet.LastRowNum, "Must have at least 2 columns");
				}

				/* for every columns */
				foreach (var cell in firstRow.Cells)
				{
					if(cell == null) { continue; }
					/* check all column headers have a name */
					if (String.IsNullOrWhiteSpace(cell.StringCellValue))
					{
						AddError(sheet, cell.RowIndex, cell.ColumnIndex, "is empty string");
					}
					/*check all name specific verifications */
					if (cell.StringCellValue.ToLower() == "name")
					{
						for (int ir = ExportExcel.NBR_LIGNES_HEADER/*0-based*/; ir <= sheet.LastRowNum; ir++)
						{
							var nameCell = sheet.GetRow(ir)?.GetCell(cell.ColumnIndex);
							if(nameCell == null) { continue; }
							/* check all data names has length */
							if (nameCell.StringCellValue.Length > ExportExcel.NAME_MAX_LENGTH)
							{
								AddError(sheet, ir, cell.ColumnIndex, "name length > "+ ExportExcel.NAME_MAX_LENGTH + " : "+ nameCell.StringCellValue.Length);
								fatalFound = true;
							}
							/* look for duplicates */
							for (int jr = ir + 1; jr <= sheet.LastRowNum; jr++)
							{
								var iCell = sheet.GetRow(jr)?.GetCell(cell.ColumnIndex);
								if (iCell!=null && nameCell.StringCellValue?.ToLower() == iCell?.StringCellValue?.ToLower())
								{
									AddError(sheet, jr, cell.ColumnIndex, "Duplicate name of " + PositionName(cell.ColumnIndex, ir));
									fatalFound = true;
								}
							}
						}
					}
					/*check all tag specific verifications */
					if (cell.StringCellValue?.ToLower() == "tag")
					{
						for (int ir = ExportExcel.NBR_LIGNES_HEADER/*0-based*/; ir <= sheet.LastRowNum; ir++)
						{
							var nameCell = sheet.GetRow(ir)?.GetCell(cell.ColumnIndex);
							if (nameCell == null)
							{
								AddError(sheet, ir, cell.ColumnIndex, "tag is missing");
								continue;
							}
							/* check all tags have length ==7 */
							if (nameCell?.StringCellValue?.Length != 7)
							{
								AddError(sheet, ir, cell.ColumnIndex, "tag is not of length 7");
								fatalFound = true;
							}
							/* look for duplicates */
							for (int jr = ir + 1; jr <= sheet.LastRowNum; jr++)
							{
								var iCell = sheet?.GetRow(jr)?.GetCell(cell.ColumnIndex);
								if (iCell == null) { continue; }
								if (nameCell.StringCellValue.ToLower() == iCell.StringCellValue.ToLower())
								{
									AddError(sheet, jr, cell.ColumnIndex, "Duplicate tag of " + PositionName(cell.ColumnIndex, ir));
									fatalFound = true;
								}
							}
						}
					}
				}
			}

			return !fatalFound;
		}

		private void AddError(ISheet sheet, int row, int column, string message)
		{
			_errors.Add(string.Format("{0}: [{2}{1}] : {3}", sheet.SheetName, row + 1, GetColumnName(column), message));
		}
		private string PositionName(int col, int row)
		{
			return "[" + GetColumnName(col) + (row + 1) + "]";
		}
	}
}
