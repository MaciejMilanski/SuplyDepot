using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SupplyDepot.DataAccess.Interfaces;

namespace SupplyDepot.DataAccess.Repositories
{
    public class TypesRepository : ITypesRepository
    {
        readonly SupplyDepotContext _context;
        public TypesRepository(SupplyDepotContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<DataAccess.Models.Type>> GetAllTypes()
        {
            return await _context.Types.ToListAsync();
        }
    }
}
