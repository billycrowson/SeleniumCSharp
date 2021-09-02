using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumTestProjectCS.Helpers
{
	class ExcelDataHandler
	{

        private static DataTable ReadExcel(String sheetName)
        {
            for (int attempts = 0; attempts < 5; attempts++)
            {
                try
                {
                    DataTable dtTable = new DataTable();
                    List<string> rowList = new List<string>();
                    ISheet sheet;
                    using (var stream = new FileStream("excelTestData.xlsx", FileMode.Open))
                    {
                        stream.Position = 0;
                        XSSFWorkbook xssWorkbook = new XSSFWorkbook(stream);
                        sheet = xssWorkbook.GetSheet(sheetName);
                        IRow headerRow = sheet.GetRow(0);
                        int cellCount = headerRow.LastCellNum;
                        for (int j = 0; j < cellCount; j++)
                        {
                            ICell cell = headerRow.GetCell(j);
                            if (cell == null || string.IsNullOrWhiteSpace(cell.ToString())) continue;
                            {
                                dtTable.Columns.Add(cell.ToString());
                            }
                        }
                        for (int i = (sheet.FirstRowNum + 1); i <= sheet.LastRowNum; i++)
                        {
                            IRow row = sheet.GetRow(i);
                            if (row == null) continue;
                            if (row.Cells.All(d => d.CellType == CellType.Blank)) continue;
                            for (int j = row.FirstCellNum; j < cellCount; j++)
                            {
                                if (row.GetCell(j) != null)
                                {
                                    if (!string.IsNullOrEmpty(row.GetCell(j).ToString()) && !string.IsNullOrWhiteSpace(row.GetCell(j).ToString()))
                                    {
                                        rowList.Add(row.GetCell(j).ToString());
                                    }
                                }
                            }
                            if (rowList.Count > 0)
                                dtTable.Rows.Add(rowList.ToArray());
                            rowList.Clear();
                        }
                    }
                    return dtTable;
                }
                catch (IOException)
                {
                    Thread.Sleep(250);
                }
            }
            return null;
        }

        public static String GetExcelData(String sheetName, String columnName)
        {
            DataTable table = ReadExcel(sheetName);
            var myColumn = table.Columns.Cast<DataColumn>().SingleOrDefault(col => col.ColumnName == columnName);
            if (myColumn != null)
            {
                var tableRow = table.AsEnumerable().First();
                var myData = tableRow.Field<string>(myColumn);

                return myData.ToString();
            }
            return null;
        }

        public static void SetExcelData(String sheetName, String columnName, String newValue)
        {
            //Gets Column index
            DataTable table = ReadExcel(sheetName);
            var myColumn = table.Columns.Cast<DataColumn>().SingleOrDefault(col => col.ColumnName == columnName);

            int columnIndex = default;
            if (myColumn != null)
            {
                columnIndex = myColumn.Ordinal;
            }

            //Writes new value to cell
            string pathSource = "excelTestData.xlsx";

            IWorkbook templateWorkbook;
            for (int attempts = 0; attempts < 5; attempts++)
            {
                try
                {
                    using (FileStream fs = new FileStream(pathSource, FileMode.Open, FileAccess.Read))
                    {
                        templateWorkbook = new XSSFWorkbook(fs);
                    }

                    ISheet sheet = templateWorkbook.GetSheet(sheetName) ?? templateWorkbook.CreateSheet(sheetName);
                    IRow dataRow = sheet.GetRow(1) ?? sheet.CreateRow(1);
                    ICell cell = dataRow.GetCell(columnIndex) ?? dataRow.CreateCell(columnIndex);
                    cell.SetCellType(CellType.String);
                    cell.SetCellValue(newValue);

                    using (FileStream fs = new FileStream(pathSource, FileMode.Create, FileAccess.Write))
                    {
                        templateWorkbook.Write(fs);
                    }
                }
                catch (IOException)
                {
                    Thread.Sleep(250);
                }
            }
        }
    }
}
