using Core.Data;
using MightyGmCtrl.ImportExport;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MightyGmCtrl.Controleurs
{
	public class DataExport : Controleur
	{
		public DataExport(Context context) : base(context)
		{
		}

		public bool ExportDataToExcel(string outputFilePath, IEnumerable<Type> types, bool onlyHeader = false)
		{
			bool success = false;
			// 1Step/type + File Save
			SetNbrEtapes(types.Count()+1);

			try
			{
				//Create excel document
				IWorkbook workbook = new XSSFWorkbook();

				//Create header cell style
				//Generic
				ICellStyle headerCellStyle = workbook.CreateCellStyle();
				headerCellStyle.VerticalAlignment = VerticalAlignment.Top;
				headerCellStyle.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.Grey25Percent.Index;
				headerCellStyle.FillPattern = FillPattern.SolidForeground;
				IFont boldFont = workbook.CreateFont();
				boldFont.IsBold = true;
				headerCellStyle.SetFont(boldFont);
				//Grid
				ICellStyle headerCellStyleGrid = workbook.CreateCellStyle();
				headerCellStyleGrid.CloneStyleFrom(headerCellStyle);
				headerCellStyleGrid.BorderBottom = BorderStyle.Thin;
				headerCellStyleGrid.BorderTop = BorderStyle.Thin;
				headerCellStyleGrid.BorderLeft = BorderStyle.Thin;
				headerCellStyleGrid.BorderRight = BorderStyle.Thin;

				//Create link cellStyle
				ICellStyle linkCellStyle = workbook.CreateCellStyle();
				IFont linkFont = workbook.CreateFont();
				linkFont.Color = NPOI.HSSF.Util.HSSFColor.DarkBlue.Index;
				linkFont.Underline = FontUnderlineType.Single;
				linkCellStyle.SetFont(linkFont);

				//Create Summary
				ISheet sommaire = workbook.CreateSheet(GlobalContext.GetMessageRessource("SUMMARY"));

				//Create headers
				List<IRow> headers = new List<IRow>();
				for (int i = 0; i < ExportExcel.NBR_LIGNES_HEADER_SUMMARY; i++)
				{
					headers.Add(sommaire.CreateRow(i));
					//Format Style
					for (int j = 0; j < 5; j++)
					{
						//last one is a grid
						headers[i].CreateCell(j).CellStyle = (i == ExportExcel.NBR_LIGNES_HEADER_SUMMARY-1 ? headerCellStyleGrid : headerCellStyle);
					}
				}
				headers[0].GetCell(0).SetCellValue(System.DateTime.Now.ToString("yyyy/MM/dd"));
				headers[0].GetCell(1).SetCellValue(GlobalContext.JdrContext.Name);
				headers[1].GetCell(0).SetCellValue("Link");
				headers[1].GetCell(1).SetCellValue("Table");
				headers[1].GetCell(2).SetCellValue("Tag");
				headers[1].GetCell(3).SetCellValue("Completion");
				headers[1].GetCell(4).SetCellValue("Correction");
				sommaire.SetColumnWidth(0, 10 * ExportExcel.COL_WIDTH_FACTOR);
				sommaire.SetColumnWidth(1, 30 * ExportExcel.COL_WIDTH_FACTOR);
				sommaire.SetColumnWidth(3, 30 * ExportExcel.COL_WIDTH_FACTOR);
				sommaire.SetColumnWidth(4, 12 * ExportExcel.COL_WIDTH_FACTOR);
				sommaire.CreateFreezePane(0, ExportExcel.NBR_LIGNES_HEADER_SUMMARY);

				//Add types
				for (int i = 0; i < types.Count(); i++)
				{
					//New Sheet
					string sheetName = "D" + i;
					ISheet newSheet = workbook.CreateSheet(sheetName);

					//Summary update : new line
					IRow rs = sommaire.CreateRow(i + ExportExcel.NBR_LIGNES_HEADER_SUMMARY);
					rs.CreateCell(1).SetCellValue(types.ElementAt(i).Name);
					rs.CreateCell(0).SetCellValue(sheetName);
					//Summary update : hyperlink Creation (Summary -> Sheet)
					XSSFHyperlink link2 = new XSSFHyperlink(HyperlinkType.Document) { Address = sheetName + "!A1" };
					rs.GetCell(0).Hyperlink = link2;
					rs.GetCell(0).CellStyle = linkCellStyle;

					//Sheet Creation
					ExportExcel.CreateSheet(newSheet, headerCellStyle, headerCellStyleGrid, (onlyHeader ? null : GlobalContext.Data), types.ElementAt(i));
					SetFinEtape();

					//Summary update : hyperlink Creation (Sheet -> Summary)
					XSSFHyperlink link2r = new XSSFHyperlink(HyperlinkType.Document) { Address = sommaire.SheetName + "!A1" };
					newSheet.GetRow(0).GetCell(1).Hyperlink = link2r;
				}

				//Write excel file
				using (FileStream file = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				{
					workbook.Write(file);
				}
				SetFinEtape();

				//Finished
				success = true;
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("EXPORT_PROC", success);

			return success;
		}

		public bool ExportModeleDataToWord(Type t, string outputFilePath)
		{
			bool success = false;
			// Write document + save
			SetNbrEtapes(2);

			try
			{
				//Create word document
				XWPFDocument doc = ExportWord.WriteDocument(t, GlobalContext.Data);

				SetFinEtape();

				//Write word file
				using (FileStream outFile = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
				{
					doc.Write(outFile);
				}
				SetFinEtape();

				//Finished
				success = true;
			}
			catch (Exception ex)
			{
				ReportException(ex);
			}

			ReportSuccess("EXPORT_PROC", success);

			return success;
		}
	}
}
