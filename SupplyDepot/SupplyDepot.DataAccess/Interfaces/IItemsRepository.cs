using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SupplyDepot.DataAccess.Models;

namespace SupplyDepot.DataAccess.Interfaces
{
    public interface IItemsRepository
    {
        Task<IEnumerable<Item>> GetAllAsync();
        Task ItemAdd(Item item);
        Task ItemDeleteAsync(int itemId);
        Task ItemUpdateAsync(Item item);
        Item GetItem(int id);
    }
}
