using GestionEscolar.Model;
using System.Collections.Generic;

namespace GestionEscolar.Repository
{
    public class PonderacionRepository
    {
        public List<Competencia> competenciaList = new List<Competencia> {
            new Competencia {
                id = 1,
                nombre = "Digital",
                ponderacion = 30
            },
            new Competencia {
                id = 2,
                nombre = "Social",
                ponderacion = 20
            },
            new Competencia {
                id = 3,
                nombre = "Matematica",
                ponderacion = 50
            }
        };


        public List<Especifica> especificaList = new List<Especifica> {
             new Especifica{
                id = 1,
                nombre = "Ejercicio",
                ponderacion = 10
            },
             new Especifica{
                 id = 2,
                nombre = "Prueba",
                ponderacion = 50
            },
             new Especifica{
                 id = 3,
                nombre = "Actividad",
                ponderacion = 40
            },
             new Especifica{
                 id = 4,
                nombre = "Autoevaluacion",
                ponderacion = 0
            }
         };

        public List<Competencia> GetCompetencias()
        {
            return competenciaList;
        }

        public List<Especifica> GetEspecificas()
        {
            return especificaList;
        }


    }
}
