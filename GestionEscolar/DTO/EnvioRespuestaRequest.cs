namespace GestionEscolar.DTO
{
    public class EnvioRespuestaRequest
    {
        public List<Respuesta> listRespuestas { get; set; }
    }

    public class Respuesta
    {
        public int idEjercicio { get; set; }
        public int idPregunta { get; set; }
        public int respuesta { get; set; }
    }

}
