using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyDepot.DataAccess.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Value { get; set; }
        public string Designation { get; set; }
        public string Type { get; set; }
    }
}
