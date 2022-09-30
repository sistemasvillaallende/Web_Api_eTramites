using Microsoft.AspNetCore.Mvc;
using Web_Api_eTramites.Entities;
using Web_Api_eTramites.Services;
using Microsoft.AspNetCore.Mvc;
using Web_Api_eTramites.Entities;
using Web_Api_eTramites.Services;
namespace Web_Api_eTramites.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TiposTramitesController : Controller
    {
        private readonly ITiposTramitesServices _itipostramitesService;
     

        public TiposTramitesController(ITiposTramitesServices tipostramitesServices)
        {
            _itipostramitesService = tipostramitesServices;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult read()
        {
            var tipostramites = _itipostramitesService.read();

            return Ok(tipostramites);
        }

        [HttpGet]
        public IActionResult getByPk(int id)
        { 
            var tipostramites = _itipostramitesService.getByPk(id);
            return Ok(tipostramites);
        }
        
    }
}
