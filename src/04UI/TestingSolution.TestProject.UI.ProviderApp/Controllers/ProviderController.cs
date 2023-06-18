using Microsoft.AspNetCore.Mvc;

namespace TestingSolution.TestProject.UI.ProviderApp.Controllers
{
    [Route("api/[controller]")]
    public class ProviderController : Controller
    {
        private IConfiguration _Configuration { get; }

        public ProviderController(IConfiguration configuration)
        {
            _Configuration = configuration;
        }

        // GET api/provider?validDateTime=[DateTime String]
        [HttpGet]
        public IActionResult Get(string validDateTime)
        {
            if (string.IsNullOrEmpty(validDateTime))
            {
                return BadRequest(new { message = "validDateTime is required" });
            }

            if (DataMissing())
            {
                return NotFound();
            }

            DateTime parsedDateTime;

            try
            {
                parsedDateTime = DateTime.Parse(validDateTime);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "validDateTime is not a date or time" });
            }

            return new JsonResult(new
            {
                test = "NO",
                validDateTime = parsedDateTime.ToString("dd-MM-yyyy HH:mm:ss")
            });
        }

        private bool DataMissing()
        {
            string path = Path.Combine("C:\\Users\\Raven\\source\\repos\\TestingSolution\\tests\\data");
            string pathWithFile = Path.Combine(path, "somedata.txt");

            return !System.IO.File.Exists(pathWithFile);
        }
    }
}
