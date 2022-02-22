using IoTWebAPI.DTOs.DvAttributes;
using IoTWebAPI.EF;
using IoTWebAPI.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public class DvAttributesManage : IDvAttributes
    {
        private readonly IoTDbContext _context;
        public DvAttributesManage(IoTDbContext context)
        {
            _context = context;
        }

        public async Task<DvAttributeViewModel> EditDes(int a_id, string new_a_des)
        {
            //throw new NotImplementedException();
            var atb = await _context.DvAttributes.FindAsync(a_id);
            if (atb == null || atb.is_active == false)
                throw new CustomException("This DeviceAttribute is unactive or not exist!");
            atb.a_description = new_a_des;
            await _context.SaveChangesAsync();
            var res = new DvAttributeViewModel()
            {
                a_id = atb.a_id,
                a_name = atb.a_name.ToString(),
                a_description = atb.a_description,
                a_active_date = atb.active_date.ToString(),
                a_last_update = atb.last_update,
                a_is_active = atb.is_active
            };
            return res;
        }

        public async Task<List<DvAttributeViewModel>> GetAllByDeviceId(int d_id)
        {
            //throw new NotImplementedException();
            var allAtbs = from a in _context.DvAttributes
                          select a;
            var listDvAtbs = allAtbs.Where(r => r.d_id == d_id);
            if (listDvAtbs == null || await listDvAtbs.CountAsync() == 0)
                throw new CustomException($"No result for querry with DeviceID = {d_id}");
            var res = await listDvAtbs.Select(r => new DvAttributeViewModel()
            {
                a_id = r.a_id,
                a_name = r.a_name.ToString(),
                a_description = r.a_description,
                a_active_date = r.active_date.ToString(),
                a_last_update = r.last_update,
                a_is_active = r.is_active
            }).ToListAsync();

            return res;
        }

        public async Task<DvAttributeViewModel> OnOffDvAttribute(int a_id)
        {
            //throw new NotImplementedException();
            var atb = await _context.DvAttributes.FindAsync(a_id);
            if (atb == null)
                throw new CustomException("This DeviceAttribute is not exist!");
            if(atb.is_active == true)
            {
                atb.is_active = false;
                atb.active_date = null;
            }
            else
            {
                atb.is_active = true;
                if (atb.active_date == null)
                    atb.active_date = DateTime.Now.Date;
            }
            await _context.SaveChangesAsync();
            var res = new DvAttributeViewModel()
            {
                a_id = atb.a_id,
                a_name = atb.a_name.ToString(),
                a_description = atb.a_description,
                a_active_date = atb.active_date.ToString(),
                a_last_update = atb.last_update,
                a_is_active = atb.is_active
            };
            return res;
        }
    }
}
// Format lai ngay gio
// Ap dung voi cac d_id Active thoi