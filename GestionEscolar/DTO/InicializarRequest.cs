using GestionEscolar.Model;

namespace GestionEscolar.DTO
{
    public class InicializarRequest
    {
        public List<Actividad> listActividades {  get; set; }
        public List<Competencia> listCompetencias {  get; set; }
        public List<Especifica> listEspecificas { get; set; }

        public class Actividad
        {
            public int id { get; set; }
            public String nombre { get; set; }
            public String especifica { get; set; }
            public String competencia { get; set; }
            public List<Ejercicio> ejercicios { get; set; }
            public int nota { get; set; }
        }

        public class Ejercicio
        {
            public int id { get; set; }
            public List<Pregunta> preguntas { get; set; }
        }

        public class Pregunta
        {
            public int id { get; set; }
            public String pregunta { get; set; }
            public String tipo {get; set;} 
            public String respuestaEsperada { get; set;}
        }

        public class Competencia
        {
            public int id { get; set;}
            public String nombre { get; set; }
            public float ponderacion { get; set; }
        }

        public class Especifica
        {
            public int id { get; set; }
            public String nombre { get; set; }
            public float ponderacion { get; set;}
        }
    }
}
