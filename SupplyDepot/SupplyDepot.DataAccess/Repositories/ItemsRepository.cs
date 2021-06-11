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
        public async Task ItemAdd(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
        }
        public async Task ItemDeleteAsync(int itemId) 
        {
            try
            {
                var itemToDelete = _context.Items.Single(x => x.Id == itemId);
                _context.Items.Remove(itemToDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) { }
        }
        public async Task ItemUpdateAsync(Item item) 
        {
            _context.Items.Update(item);
            await _context.SaveChangesAsync();
        }
        public Item GetItem(int id)
        {  
            try
            {
                return  _context.Items.Single(x => x.Id == id);
            }
            catch (Exception ex) 
            {
                return null;
            }
        }
    }
}
