using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ClosedXML.Excel;

namespace SupplyDepot.Shared
{
    public class Item
    {
        public Item ShallowCopy()
        {
            var copy = (Item)this.MemberwiseClone();
            copy.Id = 0;
            return copy;
        }
        public string GetDetails()
        {
            string result = "Id: " + this.Id + "," +
                            "Name: " + this.Name + "," +
                            "Value: " + this.Value + "," +
                            "Designation: " + this.Designation + "," +
                            "Type: " + this.Type;
            return result;
        }
        public XLWorkbook Export(ExportVisitor exportVisitor) 
        {
            return exportVisitor.exportItem(this);
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
    }
}
