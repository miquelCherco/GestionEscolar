namespace GestionEscolar.Model
{
    public class Pregunta
    {
        public int id { get; set; }
        public String pregunta { get; set; }
        public TipoPregunta tipo { get; set; }
        public String respuestaEsperada { get; set; }
        public String respuesta { get; set; }
    }
}
