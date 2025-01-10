using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webapilab.bussinesslogic;
using webapilab.datacontracts;

namespace webapilab.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LabController : ControllerBase
    {
        private readonly IConfiguration Configuration;

        public LabController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost]
        [Route("Get_LabMenu")]
        public JsonResult Get_LabMenu(get_menu_IP ip)
        {
            String connectionString = Configuration["DBConnection"];

            get_menu_OP op = new get_menu_OP();

            MAIN_BL bl = new MAIN_BL();

            bl.Get_LabMenu(ref ip, ref op, connectionString);
            return new JsonResult(op);
        }
    }
}
