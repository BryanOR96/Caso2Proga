using System.Linq;
using System.Web.Mvc;
using CasoEstudio2.BaseDatos;
using CasoEstudio2.Models;

namespace CasoEstudio2.Controllers
{
    public class CasasController : Controller
    {
        public CasasSistema db = new CasasSistema(); 
        // GET: Casas
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ConsultaCasas()
        {
            var casas = db.CasasSistema
                 .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa <= 180000)
                 .OrderBy(c => c.UsuarioAlquiler == null ? 0 : 1)
                 .ToList();

            return View(casas); ;
        }

        public ActionResult AlquilerCasas()
        {
            return View();
        }
    }
}

