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
        Task<ListItemsModel<AdminDeviceViewModel>> GetAllForAdmin();
        Task<ListItemsModel<UserDeviceViewModel>> GetAllByUserID(int u_id);
        Task<AdminDeviceViewModel> GetById(int d_id);
        //Task<UserDeviceViewModel> GetByIdUser(int u_id, int d_id);
        Task<UserDeviceViewModel> EditDeviceName(int d_id, string new_device_name);
        Task<UserDeviceViewModel> EditDeviceDes(int d_id, string new_device_des);
        Task OnOffDevice(int d_id);
        // Tim kiem qua keyword,sort,filter khong xay dung
        // Lay cac Atribute di kem Device va API Infor
        // IMAGE====================
    }
}
