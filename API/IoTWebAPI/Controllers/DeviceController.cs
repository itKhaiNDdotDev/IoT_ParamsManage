using IoTWebAPI.DTOs;
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
    public class DeviceController : ControllerBase
    {
        private readonly IDevices _deviceService;

        public DeviceController(IDevices deviceService)
        {
            _deviceService = deviceService;
        }

        [HttpPost("{u_id}/create")]
        public async Task<IActionResult> Create([FromBody] CreateDeviceRequest request, int u_id)
        {
            var res = await _deviceService.Create(request, u_id);
            if (res == 0)
                return BadRequest();
            //return Created();
            return Ok();
        }
    }
}
