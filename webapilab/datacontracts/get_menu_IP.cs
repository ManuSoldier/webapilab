using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapilab.datacontracts
{
    public class get_menu_IP
    {
        public int tenant_id { get; set; }
        public int system_id { get; set; }

        public get_menu_IP()
        {
            tenant_id = 0;
            system_id = 0;
        }
    }
}
