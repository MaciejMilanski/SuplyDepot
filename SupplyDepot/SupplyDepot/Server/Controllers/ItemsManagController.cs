using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using SupplyDepot.DataAccess.Interfaces;
using SupplyDepot.DataAccess.Repositories;
using SupplyDepot.Shared;
using SupplyDepot.Server.Mapper;

namespace SupplyDepot.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsManagController : Controller
    {
        private readonly IItemsRepository _itemsRepository;
        private readonly IMapper _mapper;
        public ItemsManagController(IItemsRepository itemsRepository, IMapper mapper) 
        {
            _itemsRepository = itemsRepository;
            _mapper = mapper;
        }
        [HttpGet("list-items")]
        public async Task<IActionResult> GetAllItems() 
        {
            var itemsDA = await _itemsRepository.GetAllAsync();
            var itemsShared = _mapper.Map<List<Item>>(itemsDA);
            return Json(itemsShared);
        }
    }
}
