using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SupplyDepot.DataAccess.Interfaces;
using SupplyDepot.DataAccess.Models;

namespace SupplyDepot.DataAccess.Repositories
{
    public class ItemsRepository : IItemsRepository
    {
        private readonly SupplyDepotContext _context;
        public ItemsRepository(SupplyDepotContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Items.ToListAsync();
        }
    }
}
