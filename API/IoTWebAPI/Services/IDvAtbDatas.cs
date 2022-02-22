using IoTWebAPI.DTOs.DvAtbDatas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public interface IDvAtbDatas
    {
        Task<DataValueViewModel> GetCurValue(int a_id);
        Task<List<DataValueViewModel>> GetLast30Value(int a_id);
        //Task GetFilter();
        //GET ALL OF A DEVICE ATTRIBUTE
        Task<int> SendData(int a_id, float value);
        Task<DataValueViewModel> GetById(int id);
    }
}
