using IoTWebAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataValuesController : ControllerBase
    {
        private readonly IDvAtbDatas _dataService;

        public DataValuesController(IDvAtbDatas dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("get-by-id/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _dataService.GetById(id));
        }

        [HttpGet("{a_id}/current")]
        public async Task<IActionResult> GetCurValue(int a_id)
        {
            return Ok(await _dataService.GetCurValue(a_id));
        }

        [HttpPost("{a_id}")]
        public async Task<IActionResult> SendData(int a_id, [FromBody] float value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _dataService.SendData(a_id, value);
            if (id <= 0)
                return BadRequest();
            return Ok(await _dataService.GetById(id));
        }

        [HttpGet("{a_id}")]
        public async Task<IActionResult> GetLast30Value(int a_id)
        {
            return Ok(await _dataService.GetLast30Value(a_id));
        }
    }
}
