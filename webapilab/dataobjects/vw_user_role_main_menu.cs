using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace webapilab.dataobjects
{
    public class vw_user_role_main_menu
    {
        public int tenant_code { get; set; }
        public string system_code { get; set; }
        public int tenant_id { get; set; }
        public int system_id { get; set; }
        public string l1_menu_item_name1 { get; set; }
        public string l2_menu_item_name1 { get; set; }
        public int l1_menu_item_display_order { get; set; }
        public string l2_menu_item_display_order { get; set; }
    }
}
