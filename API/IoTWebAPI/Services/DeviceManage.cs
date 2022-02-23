using IoTWebAPI.DTOs.Devices;
using IoTWebAPI.EF;
using IoTWebAPI.Helpers;
using IoTWebAPI.Models;
using IoTWebAPI.Models.Enums;
using Microsoft.EntityFrameworkCore;
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
            await _context.SaveChangesAsync();
            return device.d_id;
        }

        public async Task<int> Delete(int d_id) //CHUA XOA CACHE
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null)
                throw new CustomException($"DeviceID = {d_id} is not exist!");
            //xoa cac attribute va anh nua (Atb tu đong xoa theo khoa ngoai roi kia)
            _context.Devices.Remove(device);
            return await _context.SaveChangesAsync();
        }

        public async Task<UserDeviceViewModel> EditDeviceDes(int d_id, string new_device_des)
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null || device.is_active == false)
                throw new CustomException($"Device with DeviceID = {d_id} is not a exist active device!");
            device.device_description = new_device_des;
            await _context.SaveChangesAsync();
            var res = new UserDeviceViewModel
            {
                d_id = device.d_id,
                device_name = device.device_name,
                device_description = device.device_description,
                img_url = device.img_url,
                create_date = device.create_date
            };
            return res;
        }

        public async Task<UserDeviceViewModel> EditDeviceName(int d_id, string new_device_name)
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null || device.is_active == false)
                throw new CustomException($"Device with DeviceID = {d_id} is not a exist active device!");
            device.device_name = new_device_name;
            await _context.SaveChangesAsync();
            var res = new UserDeviceViewModel
            {
                d_id = device.d_id,
                device_name = device.device_name,
                device_description = device.device_description,
                img_url = device.img_url,
                create_date = device.create_date
            };
            return res;
        }

        public async Task<ListItemsModel<UserDeviceViewModel>> GetAllByUserID(int u_id)
        {
            //throw new NotImplementedException();
            //Check u_id xem có không đã
            var allDevices = from d in _context.Devices
                             select d;
            var myDevices = allDevices.Where(r => r.u_id == u_id && r.is_active == true);
            int cnt = await myDevices.CountAsync();
            if (myDevices == null || cnt == 0)
                throw new CustomException("You have not any active device!");
            var data = await myDevices.Select(r => new UserDeviceViewModel()
            {
                d_id = r.d_id,
                device_name = r.device_name,
                device_description = r.device_description,
                img_url = r.img_url,
                create_date = r.create_date
            }).ToListAsync();

            var res = new ListItemsModel<UserDeviceViewModel>//()
            {
                countRecord = cnt,
                Items = data
            };
            return res;
        }

        public async Task<ListItemsModel<AdminDeviceViewModel>> GetAllForAdmin()
        {
            //throw new NotImplementedException();
            var allDevices = from d in _context.Devices
                             select d;
            int cnt = await allDevices.CountAsync();
            if (allDevices == null || cnt == 0)
                throw new CustomException("No device exists in the system!");
            var data = await allDevices.Select(r => new AdminDeviceViewModel()
            {
                d_id = r.d_id,
                u_id = r.u_id,
                device_name = r.device_name,
                device_description = r.device_description,
                img_url = r.img_url,
                create_date = r.create_date,
                is_active = r.is_active
            }).ToListAsync();

            var res = new ListItemsModel<AdminDeviceViewModel>//()
            {
                countRecord = cnt,
                Items = data
            };
            return res;
        }

        public async Task<AdminDeviceViewModel> GetById(int d_id)
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null)
                throw new CustomException($"DeviceID = {d_id} is not exist!");
            var res = new AdminDeviceViewModel()
            {
                d_id = device.d_id,
                device_name = device.device_name,
                device_description = device.device_description,
                img_url = device.img_url,
                create_date = device.create_date,
                is_active = device.is_active
            };

            return res;
        }

        public async Task OnOffDevice(int d_id)
        {
            //throw new NotImplementedException();
            var device = await _context.Devices.FindAsync(d_id);
            if (device == null)
                throw new CustomException($"DeviceID = {d_id} is not exist!");
            if(device.is_active == true)
            {
                device.is_active = false;
                //var atbDv = _context.DvAttributes.Where(r => r.d_id == d_id);
                // Khong nen unActive luon ca cac Attribute vi luc bat Device se khong biet can bar Atb nao de recorver cho User
            }
            else
            {
                device.is_active = true;
            }
        }
    }
}
