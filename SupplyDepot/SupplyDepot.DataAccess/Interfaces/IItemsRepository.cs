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
    }
}
