using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using SupplyDepot.DataAccess.Interfaces;

namespace SupplyDepot.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TypesController : Controller
    {
        readonly ITypesRepository _typesRepository;
        readonly IMapper _mapper;
        public TypesController(ITypesRepository typesRepository, IMapper mapper) 
        {
            _typesRepository = typesRepository;
            _mapper = mapper;
        }
        [HttpGet("list-types")]
        public async Task<IActionResult> GetAllTypes()
        {
            var typesDA = await _typesRepository.GetAllTypes();
            var typesShared = _mapper.Map<List<Shared.Type>>(typesDA);
            return Json(typesShared);
        }
    }
}
