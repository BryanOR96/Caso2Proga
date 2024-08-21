using System;
using System.ComponentModel.DataAnnotations;

namespace CasoEstudio2.Models
{
    public class CasasModel
    {
        [Key]
        public long IdCasa { get; set; }

        [Required]
        [StringLength(30)]
        public string DescripcionCasa { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser un valor positivo.")]
        public decimal PrecioCasa { get; set; }

        [StringLength(30)]
        public string UsuarioAlquiler { get; set; }

        public DateTime? FechaAlquiler { get; set; }

        // Propiedad calculada para mostrar el estado de la casa (Disponible o Reservada)
        public string Estado
        {
            get
            {
                return string.IsNullOrEmpty(UsuarioAlquiler) ? "Disponible" : "Reservada";
            }
        }
    }
}
