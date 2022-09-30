using Microsoft.AspNetCore.Mvc;
using Web_Api_eTramites.Entities;
using Web_Api_eTramites.Services;


namespace Web_Api_eTramites.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TramitesController : Controller
    {
        private readonly ITramitesServices _itramitesService;

        public TramitesController(ITramitesServices tramitesServices)
        {
            _itramitesService = tramitesServices;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public IActionResult read()
        {
            var tramites = _itramitesService.read();
            return Ok(tramites);
        }
        [HttpPost]
        public IActionResult insert(Entities.TRAMITE obj)
        {
            var tramites = _itramitesService.insert(obj);
            return Ok(tramites);
        }
        [HttpPost]
        public IActionResult update(Entities.TRAMITE obj)
        {
            _itramitesService.update(obj);
            var tramites = _itramitesService.read();
            return Ok(tramites);
        }
        [HttpPost]
        public IActionResult delete(Entities.TRAMITE obj)
        {
            _itramitesService.delete(obj);
            var tramites = _itramitesService.read();
            return Ok(tramites);
        }
        [HttpGet]
        public IActionResult getByPk(int id)
        {
            var tramites = _itramitesService.getByPk(id);
            return Ok(tramites);
        }

        [HttpGet]
        public IActionResult listartipos_tramites()
        {
            var indycom = _itramitesService.listartipos_tramites();
            return Ok(indycom);
        }
        [HttpGet]
        public IActionResult listartipologias()
        {
            var indycom = _itramitesService.listartipologias();
            return Ok(indycom);
        }
        [HttpGet]
        public IActionResult getHistorial(int id)
        {
            var tramites = _itramitesService.getHistorial(id);
            return Ok(tramites);
        }


    }
}
