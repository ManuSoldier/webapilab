using System.Data;
using Microsoft.Data.SqlClient;
using webapilab.datacontracts;
using webapilab.dataobjects;

namespace webapilab.bussinesslogic
{
    public class MAIN_BL
    {
        public int Get_LabMenu(ref get_menu_IP ip, ref get_menu_OP op, string connectionString)
        {
            string query = @"
            SELECT DISTINCT  tenant_code, system_code,system_id,tenant_id, l1_menu_item_name1, l2_menu_item_name1 , l1_menu_item_display_order, l2_menu_item_display_order 
            FROM system.vw_user_role_main_menu
            WHERE tenant_id = @TenantID
              AND system_id = @SystemID
            ORDER BY l1_menu_item_display_order, l2_menu_item_display_order;";


            DataTable dtUserDetail = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TenantID", ip.tenant_id);
                    command.Parameters.AddWithValue("@SystemID", ip.system_id);

                    try
                    {
                        connection.Open();
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(dtUserDetail);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                        return -1;
                    }
                }
            }


            if (dtUserDetail.Rows.Count > 0)
            {
                op.ml_lab = new List<vw_user_role_main_menu>();

                foreach (DataRow row in dtUserDetail.Rows)
                {
                    vw_user_role_main_menu menuItem = new vw_user_role_main_menu
                    {
                        tenant_code = Convert.ToInt32(row["tenant_code"]),
                        system_code = row["system_code"].ToString(),
                        tenant_id = Convert.ToInt32(row["tenant_id"]),
                        system_id = Convert.ToInt32(row["system_id"]),
                        l1_menu_item_name1 = row["l1_menu_item_name1"].ToString(),
                        l2_menu_item_name1 = row["l2_menu_item_name1"].ToString(),
                        l1_menu_item_display_order = Convert.ToInt32(row["l1_menu_item_display_order"]),
                        l2_menu_item_display_order = row["l2_menu_item_display_order"].ToString(),
                    };

                    op.ml_lab.Add(menuItem);
                }
            }

            return 0;
        }
    }
}
