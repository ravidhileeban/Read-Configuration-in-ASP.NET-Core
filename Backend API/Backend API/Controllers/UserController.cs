using Backend_API.SqlModel;
using Microsoft.AspNetCore.Mvc;

namespace Backend_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        #region Step:5 Constructor Injection for Confiiguration

        public readonly IConfiguration _configuration;
        public readonly SqlEndPoint sqlEndPoint;
        #endregion
        public UserController(IConfiguration configuration,SqlEndPoint sqlEndPoint)
        {
          _configuration = configuration;
            this.sqlEndPoint = sqlEndPoint;
         }

        [HttpGet]
        public async Task<IActionResult> InsertUser()
        {
            #region Step : 6 Access Value via IConfiguration
            var connection = _configuration.GetSection("SqlEndPoint").GetSection("ConnectionString").Value;

            var connection2 = _configuration.GetValue<string>("SqlEndPoint:ConnectionString");

            #endregion


            #region Access value via Class Model
            var connetcion3 = this.sqlEndPoint.ConnectionString;
            #endregion.

            return Ok();
        }

    }
}
