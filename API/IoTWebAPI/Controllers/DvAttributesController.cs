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
    public class DvAttributesController : ControllerBase
    {
        private readonly IDvAttributes _attributeService;
        public DvAttributesController(IDvAttributes attributeService)
        {
            _attributeService = attributeService;
        }

        [HttpGet("{d_id}")]
        public async Task<IActionResult> Get(int d_id)
        {
            return Ok(await _attributeService.GetAllByDeviceId(d_id));
        }

        [HttpPatch("{a_id}/edit-description")]      //PATCH ./api/dvattributes/{a_id}/edit-description
        public async Task<IActionResult> EditDes(int a_id, [FromBody] string new_a_des)
        {
            return Ok(await _attributeService.EditDes(a_id, new_a_des));
        }

        // On/Off mot Device Attribute
        [HttpPatch("{a_id}/on-off")]            //PATCH ./api/dvattributes/{a_id}/on-off
        public async Task<IActionResult> OnOffDevice(int a_id)
        {
            return Ok(await _attributeService.OnOffDvAttribute(a_id));
        }
    }
}
