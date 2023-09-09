namespace GestionEscolar.Model
{
    public class Pregunta
    {
        public int id { get; set; }
        public string? pregunta { get; set; }
        public TipoPregunta tipo { get; set; }
        public string? respuestaEsperada { get; set; }
        public string? respuesta { get; set; }
    }
}
