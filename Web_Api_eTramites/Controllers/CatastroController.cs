using Microsoft.AspNetCore.Mvc;
using Web_Api_eTramites.Services;

namespace Web_Api_eTramites.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
   // [Route("api/[controller]/[action]")]
    public class CatastroController : Controller
    {
        private readonly ICatastroServices _icatastroServices;
        public CatastroController(ICatastroServices icatastroServices)
        {
            _icatastroServices = icatastroServices;
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public IActionResult read()
        {
            var catastro = _icatastroServices.read();
            return Ok(catastro);
        }
        [HttpGet]
        public IActionResult BuscarCatastro(int circunscripcion, int seccion, int manzana, int parcela, int p_h)
        {
            var catastro = _icatastroServices.getByPk(circunscripcion, seccion, manzana, parcela, p_h);
            return Ok(catastro);
        }

    }
}
