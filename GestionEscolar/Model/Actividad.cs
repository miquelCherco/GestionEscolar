

namespace GestionEscolar.Model
{
    public class Actividad
    {
        public int id { get; set; }
        public string? nombre { get; set; }
        public List<Ejercicio>? listEjercicios { get; set; }
        public string? competencia { get; set; }
        public string? especifica { get; set; }
        public float nota { get; set; }

    }
}
