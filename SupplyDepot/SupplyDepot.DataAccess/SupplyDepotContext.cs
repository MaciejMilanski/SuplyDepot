using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupplyDepot.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace SupplyDepot.DataAccess
{
    public class SupplyDepotContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<DataAccess.Models.Type> Types { get; set; }

        public SupplyDepotContext(DbContextOptions<SupplyDepotContext> options) : base(options)
        {

        }
    }
}