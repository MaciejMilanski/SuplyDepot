using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
//using Microsoft.JSInterop;

using ClosedXML.Excel;

using SupplyDepot.Shared;

namespace SupplyDepot.Shared
{
    public class ExportVisitor
    {
        public XLWorkbook exportItem(Item item) 
        {
            //using (var workbook = new XLWorkbook())
            //{
                var workbook = new XLWorkbook();
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("Items");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";
                worksheet.Cell(1, 3).Value = "Designation";
                worksheet.Cell(1, 4).Value = "Value";
                worksheet.Cell(1, 5).Value = "Type";

                for (int i = 1; i <= 5; i++)
                {
                    worksheet.Cell(1, i).Style.Font.Bold = true;
                }

                int index = 1;
                
                worksheet.Cell(index + 1, 1).Value = item.Id;
                worksheet.Cell(index + 1, 2).Value = item.Name;
                worksheet.Cell(index + 1, 3).Value = item.Designation;
                worksheet.Cell(index + 1, 4).Value = item.Value;
                worksheet.Cell(index + 1, 5).Value = item.Type;                


                return workbook;
                
            //}
        }
        public XLWorkbook exportType(SupplyDepot.Shared.Type type) 
        {
                var workbook = new XLWorkbook();
                IXLWorksheet worksheet =
                workbook.Worksheets.Add("Items");
                worksheet.Cell(1, 1).Value = "Id";
                worksheet.Cell(1, 2).Value = "Name";

                for (int i = 1; i <= 5; i++)
                {
                    worksheet.Cell(1, i).Style.Font.Bold = true;
                }

                int index = 1;

                worksheet.Cell(index + 1, 1).Value = type.Id;
                worksheet.Cell(index + 1, 2).Value = type.Name;               


                return workbook;

        }
    }
}
