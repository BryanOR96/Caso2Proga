using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using CasoEstudio2.BaseDatos;
using CasoEstudio2.Models;

namespace CasoEstudio2.Controllers
{
    [OutputCache(NoStore = true, VaryByParam = "*", Duration = 0)]
    public class CasasController : Controller
    {
        CasasModel casasM = new CasasModel();

        [HttpGet]
        public ActionResult ConsultaCasas()
        {

            var respuesta = casasM.ConsultaCasas();

            return View(respuesta); ;
        }

        [HttpGet]
        public ActionResult TablaCompleta()
        {

            var respuesta = casasM.TablaCompleta();

            return View(respuesta); ;
        }

        [HttpGet]
        public ActionResult AlquilerCasas()
        {
            var disponibles = casasM.ConsultaAlquiler();

            ViewBag.DisponiblesList = new SelectList(disponibles, "IdCasa", "DescripcionCasa");
            return View();
        }

        [HttpGet]
        public JsonResult ObtenerPrecio(int id)
        {
            var PrecioCasa = casasM.ObtenerPrecio(id);
            return Json(new { PrecioCasa = PrecioCasa.ToString() }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Alquilar(int IdCasa, string UsuarioAlquiler)
        {
            var respuesta = casasM.Alquilar(IdCasa, UsuarioAlquiler);

            if (respuesta == false)
            {
                return RedirectToAction("Registro", "Home");
            }

            return RedirectToAction("ConsultaCasas", "Casas");
        }
    }
}

