using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project.OnlineQA.Business.Interface;

namespace Project.OnlineQA.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SelectionsController : ControllerBase
    {
        private readonly ISelectionService _selectionService;
        public SelectionsController(ISelectionService selectionService)
        {
            _selectionService = selectionService;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _selectionService.GetAllAsync());
        }
    }
}
