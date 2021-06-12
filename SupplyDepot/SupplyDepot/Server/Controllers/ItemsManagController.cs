using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

using SupplyDepot.DataAccess.Interfaces;
using SupplyDepot.DataAccess.Repositories;
using SupplyDepot.DataAccess.Models;
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
            var itemsShared = _mapper.Map<List<Shared.Item>>(itemsDA);
            return Json(itemsShared);
        }

        [HttpPost("create-item")]
        public async Task<IActionResult> Create(Shared.Item itemShared)
        {
            try 
            { 
                var itemDA = _mapper.Map<DataAccess.Models.Item>(itemShared);
                await _itemsRepository.ItemAdd(itemDA);
                return Ok();
            }
            catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpDelete("delete-item/{id}")]
        public async Task<IActionResult> Delete(int id) 
        {
            try
            {
                await _itemsRepository.ItemDeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("get-item/{id}")]
        public IActionResult GetItem(int id)
        {
            var itemDA = _itemsRepository.GetItem(id);
            var itemShared = _mapper.Map<Shared.Item>(itemDA);
            return Json(itemShared);
        }

        [HttpPut("update-item")]
        public async Task<IActionResult> Update(Shared.Item itemShared)
        {
            try
            {
                var itemDA = _mapper.Map<DataAccess.Models.Item>(itemShared);
                await _itemsRepository.ItemUpdateAsync(itemDA);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost("copy-item")]
        public async Task<IActionResult> Copy(Shared.Item itemShared)
        {
            try
            {
                Shared.Item item = itemShared.ShallowCopy();
                var itemDA = _mapper.Map<DataAccess.Models.Item>(item);
                await _itemsRepository.ItemAdd(itemDA);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
