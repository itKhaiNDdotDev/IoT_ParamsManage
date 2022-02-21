using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoTWebAPI.DTOs
{
    public class ListItemsModel<T>
    {
        public List<T> Items { get; set; }
        public int countRecord { get; set; }
    }
}
