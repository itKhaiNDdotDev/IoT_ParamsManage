using IoTWebAPI.DTOs.DvAtbDatas;
using IoTWebAPI.EF;
using IoTWebAPI.Helpers;
using IoTWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public class DataService : IDvAtbDatas
    {
        private readonly IoTDbContext _context;
        public DataService(IoTDbContext context)
        {
            _context = context;
        }

        public async Task<DataValueViewModel> GetById(int id)
        {
            //throw new NotImplementedException();
            var data = await _context.Datas.FindAsync(id);
            if (data == null)
                throw new CustomException($"Data value with ID = {id} is not exist!");
            var res = new DataValueViewModel()
            {
                id = data.id,
                a_id = data.a_id,
                value = data.value,
                update_time = data.update_time
            };

            return res;
        }

        public async Task<DataValueViewModel> GetCurValue(int a_id)
        {
            //throw new NotImplementedException();
            var data = from d in _context.Datas
                       select d;
            var atbData = data.Where(r => r.a_id == a_id);
            var curData = atbData.Select(r => new DataValueViewModel()
            {
                id = r.id,
                a_id = a_id,
                value = r.value,
                update_time = r.update_time
            }).OrderByDescending(i => i.id).FirstOrDefault();
            return curData;
        }

        // Neu khong du 30 thi lay het ra
        public async Task<List<DataValueViewModel>> GetLast30Value(int a_id)
        {
            //throw new NotImplementedException();
            var data = from d in _context.Datas
                       select d;
            var atbData = data.Where(r => r.a_id == a_id);
            int cnt = await atbData.CountAsync();
            List<DataValueViewModel> res;
            if(cnt >= 30)
            {
                res = await atbData.Skip(cnt - 30).Take(30)
                .Select(v => new DataValueViewModel()
                {
                    id = v.id,
                    a_id = v.a_id,
                    value = v.value,
                    update_time = v.update_time
                }).ToListAsync();
            }
            else
            {
                res = await atbData
                .Select(v => new DataValueViewModel()
                {
                    id = v.id,
                    a_id = v.a_id,
                    value = v.value,
                    update_time = v.update_time
                }).ToListAsync();
            }
            return res;
        }

        public async Task<int> SendData(int a_id, float value)
        {
            //throw new NotImplementedException();
            var data = new Data()
            {
                a_id = a_id,
                value = value,
                update_time = DateTime.Now
            };
            _context.Datas.Add(data);
            await _context.SaveChangesAsync();
            return data.id;
        }
    }
}
