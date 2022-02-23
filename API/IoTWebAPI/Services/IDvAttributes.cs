using IoTWebAPI.DTOs.DvAttributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.Services
{
    public interface IDvAttributes
    {
        Task<List<DvAttributeViewModel>> GetAllByDeviceId(int d_id);
        //Task GetAllForAdmin();    //XAY DUNG SAU
        // Khong can Create, Delete
        Task<DvAttributeViewModel> EditDes(int a_id, string new_a_des);
        Task<DvAttributeViewModel> OnOffDvAttribute(int a_id);
        //API Info - chi lay Token va URL
    }
}
