using GestionEscolar.Model;

namespace GestionEscolar.DTO
{
    public class InicializarRequest
    {
        public List<ActividadRequest> listActividades {  get; set; }
        public List<CompetenciaRequest> listCompetencias {  get; set; }
        public List<EspecificaRequest> listEspecificas { get; set; }

        public class ActividadRequest
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public string especifica { get; set; }
            public string competencia { get; set; }
            public List<EjercicioRequest> listEjercicios { get; set; }
            public int nota { get; set; }
        }

        public class EjercicioRequest
        {
            public int id { get; set; }
            public List<PreguntaRequest> listPreguntas { get; set; }
        }

        public class PreguntaRequest
        {
            public int id { get; set; }
            public string pregunta { get; set; }
            public TipoPregunta tipo {get; set;} 
            public string respuestaEsperada { get; set;}
        }

        public class CompetenciaRequest
        {
            public int id { get; set;}
            public string nombre { get; set; }
            public float ponderacion { get; set; }
        }

        public class EspecificaRequest
        {
            public int id { get; set; }
            public string nombre { get; set; }
            public float ponderacion { get; set;}
        }
    }
}
