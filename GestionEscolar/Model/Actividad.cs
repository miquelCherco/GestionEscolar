using Microsoft.AspNetCore.Mvc.TagHelpers;

namespace GestionEscolar.Model
{
    public class Actividad
    {
        public int id { get; set; }
        public String nombre { get; set; }
        public List<Ejercicio> listEjercicios { get; set; }
        public String competencia { get; set; }
        public String especifica { get; set; }
        public int nota { get; set; }

    }
}
