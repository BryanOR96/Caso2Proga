using System.Linq;
using System.Web.Mvc;
using CasoEstudio2.BaseDatos;
using CasoEstudio2.Models;

namespace CasoEstudio2.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class CasasController : Controller
    {
        CasasModel casasM = new CasasModel();

        public ActionResult ConsultaCasas()
        {

            var respuesta = casasM.ConsultaCasas();

            return View(respuesta); ;
        }

        public ActionResult AlquilerCasas()
        {
            return View();
        }
    }
}

