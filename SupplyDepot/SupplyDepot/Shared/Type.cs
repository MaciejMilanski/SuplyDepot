using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;
namespace SupplyDepot.Shared
{
    public class Type
    {
        public string GetDetails()
        {
            string result = "Id: " + this.Id + ", " +
                            "Name: " + this.Name;
            return result;
        }
        public XLWorkbook Export(ExportVisitor exportVisitor)
        {
            return exportVisitor.exportType(this);
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
