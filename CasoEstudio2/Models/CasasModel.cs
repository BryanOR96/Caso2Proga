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
                               .Where(c => c.PrecioCasa >= 115000 && c.PrecioCasa <= 180000)
                               .OrderByDescending(c => c.UsuarioAlquiler == null && c.FechaAlquiler == null)
                               .ToList();
            }
        }

        public List<CasasSistema> TablaCompleta()
        {
            using (var context = new CasoEstudioKNEntities())
            {
                return context.CasasSistema
                               .OrderByDescending(c => c.UsuarioAlquiler == null && c.FechaAlquiler == null)
                               .ToList();
            }
        }

        public List<CasasSistema> ConsultaAlquiler()
        {
            using (var context = new CasoEstudioKNEntities())
            {
                return context.CasasSistema
                               .Where(c => c.UsuarioAlquiler == null && c.FechaAlquiler == null)
                               .ToList();
            }
        }

        public decimal ObtenerPrecio(int id)
        {
            using (var context = new CasoEstudioKNEntities())
            {
                var entidad = context.CasasSistema
                                     .Where(c => c.IdCasa == id)
                                     .Select(c => c.PrecioCasa)
                                     .FirstOrDefault();

                return entidad;
            }
        }

        public bool Alquilar(int IdCasa, string UsuarioAlquiler)
        {
            using (var context = new CasoEstudioKNEntities())
            {
                var casas = context.CasasSistema.FirstOrDefault(c => c.IdCasa == IdCasa);

                if (casas == null)
                {
                    return false;
                }

                casas.UsuarioAlquiler = UsuarioAlquiler;
                casas.FechaAlquiler = DateTime.Now;
                context.SaveChanges();
                return true;

            }
        }
    }
}
