using IoTWebAPI.DTOs;
using IoTWebAPI.EF;
using IoTWebAPI.Helpers;
using IoTWebAPI.Models;
using IoTWebAPI.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public class DeviceManage : IDevices
    {
        private readonly IoTDbContext _context;

        public DeviceManage(IoTDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(CreateDeviceRequest request, int u_id_fk)
        {
            //throw new NotImplementedException();
            var device = new Device()
            {
                u_id = u_id_fk,
                device_name = request.device_name,
                device_description = request.device_description,
                img_url = request.img_url,
                is_active = true,
                create_date = DateTime.Now.Date,
                list_attributes = new List<DvAttribute>()
            };
            if(request.temp_is_active == true)
            {
                var atbT = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Temperature,
                    a_description = request.a_des_temp,
                    is_active = request.temp_is_active,
                    active_date = DateTime.Now.Date
                };
                device.list_attributes.Add(atbT);
            }
            else
            {
                var atbT = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Temperature,
                    a_description = request.a_des_temp,
                    is_active = request.temp_is_active
                };
                device.list_attributes.Add(atbT);
            }
            if (request.humi_is_active == true)
            {
                var atbH = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Humidity,
                    a_description = request.a_des_humi,
                    is_active = request.humi_is_active,
                    active_date = DateTime.Now.Date
                };
                device.list_attributes.Add(atbH);
            }
            else
            {
                var atbH = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Humidity,
                    a_description = request.a_des_humi,
                    is_active = request.humi_is_active
                };
                device.list_attributes.Add(atbH);
            }
            if (request.pres_is_active == true)
            {
                var atbP = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Pressure,
                    a_description = request.a_des_pres,
                    is_active = request.pres_is_active,
                    active_date = DateTime.Now.Date
                };
                device.list_attributes.Add(atbP);
            }
            else
            {
                var atbP = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Pressure,
                    a_description = request.a_des_pres,
                    is_active = request.pres_is_active
                };
                device.list_attributes.Add(atbP);
            }
            if (request.brin_is_active == true)
            {
                var atbB = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Brightness,
                    a_description = request.a_des_brin,
                    is_active = request.brin_is_active,
                    active_date = DateTime.Now.Date
                };
                device.list_attributes.Add(atbB);
            }
            else
            {
                var atbB = new DvAttribute()
                {
                    a_name = AttributeNameOpt.Brightness,
                    a_description = request.a_des_brin,
                    is_active = request.brin_is_active
                };
                device.list_attributes.Add(atbB);
            }

            _context.Devices.Add(device);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(int d_id) //CHUA XOA CACHE
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null)
                throw new CustomException($"DeviceID = {d_id} is not exist!");
            //xoa cac attribute va anh nua
            _context.Devices.Remove(device);
            return await _context.SaveChangesAsync();
        }
    }
}
