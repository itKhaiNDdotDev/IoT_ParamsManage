using IoTWebAPI.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public interface IDevices
    {
        Task<int> Create(CreateDeviceRequest request, int u_id_fk);
        Task<int> Delete(int d_id);

    }
}
