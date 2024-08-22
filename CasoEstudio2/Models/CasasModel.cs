using CasoEstudio2.BaseDatos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
       public List<CasasSistema> ConsultaCasas()
        {
            using (var context = new CasoEstudioKNEntities())
            {
                return context.CasasSistema
                               .ToList();
            }
        }



    }
}
