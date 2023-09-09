namespace GestionEscolar.DTO
{
    public class EnvioRespuestaRequest
    {
        public List<RespuestaRequest> listRespuestas { get; set; }
    }

    public class RespuestaRequest
    {
        public int idEjercicio { get; set; }
        public int idPregunta { get; set; }
        public string respuesta { get; set; }
    }

}
