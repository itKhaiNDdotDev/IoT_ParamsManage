using IoTWebAPI.DTOs.Devices;
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

        //Tao device moi kem lua chon bat cac Attribute mong muon trong 4 Attributes
        [HttpPost("{u_id}")]        // POST ./api/devices/{u_id}
        public async Task<IActionResult> Create([FromBody] CreateDeviceRequest request, int u_id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int deviceId = await _deviceService.Create(request, u_id);
            if (deviceId <= 0)
                return BadRequest();
            var device = await _deviceService.GetById(deviceId);
            //return Created(nameof(GetById), device);
            return CreatedAtAction(nameof(GetById), new { id = deviceId }, device);
        }

        //Lat danh sach tat ca Device trong he thong duoi goc nhin Admin:   
        [HttpGet]               // GET ./api/devices
        public async Task<IActionResult> Get()
        {
            return Ok(await _deviceService.GetAllForAdmin());
        }

        //Lay danh sach tat ca Device dang duoc phep hoat dong tuong ung cua mot User qua u_id
        [HttpGet("{u_id}/my-devices")]     // GET ./api/devices/{u_id}/my-devices
        public async Task<IActionResult> Get(int u_id)
        {
            return Ok(await _deviceService.GetAllByUserID(u_id));
        }

        //Lay thong tin device qua d_id
        [HttpGet("{d_id}")]     // GET ./api/devices/{d_id}
        public async Task<IActionResult> GetById(int d_id)
        {
            var res = await _deviceService.GetById(d_id);
            if (res == null)
                return BadRequest("Can not find device");
            return Ok(res);
        }

        //Xoa mot device qua d_id:  
        [HttpDelete("{d_id}")]  // DELETE ./api/devices/{d_id}
        public async Task<IActionResult> Delete(int d_id)
        {
            var deleted = await _deviceService.Delete(d_id);
            if (deleted == 0)
                return BadRequest();
            return Ok();
        }

        //Sua ten cua device
        [HttpPatch("{d_id}/edit-device-name")]      //PATCH ./api/devices/{d_id}/edit-device-name
        public async Task<IActionResult> EditDeviceName(int d_id, [FromBody] string new_device_name)
        {
            return Ok(await _deviceService.EditDeviceName(d_id, new_device_name));
        }

        //Sua description cua device
        [HttpPatch("{d_id}/edit-description")]      //PATCH ./api/devices/{d_id}/edit-description
        public async Task<IActionResult> EditDeviceDes(int d_id, [FromBody] string new_device_name)
        {
            return Ok(await _deviceService.EditDeviceDes(d_id, new_device_name));
        }

        // UnActive/Active mot Device
        [HttpPatch("{d_id}/on-off")]            //PATCH ./api/devices/{d_id}/on-off
        public async Task<IActionResult> OnOffDevice(int d_id)
        {
            await _deviceService.OnOffDevice(d_id);
            return Ok(await _deviceService.GetById(d_id));
        }
    }
}
