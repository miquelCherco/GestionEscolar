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
                ponderacio = 30
            },
            new Competencia {
                id = 2,
                nombre = "Social",
                ponderacio = 20
            },
            new Competencia {
                id = 3,
                nombre = "Matematica",
                ponderacio = 50
            }
        };


        public List<Especifica> especificaList = new List<Especifica> {
             new Especifica{
                id = 1,
                nombre = "Ejercicio",
                ponderacio = 10
            },
             new Especifica{
                 id = 2,
                nombre = "Prueba",
                ponderacio = 50
            },
             new Especifica{
                 id = 3,
                nombre = "Actividad",
                ponderacio = 40
            },
             new Especifica{
                 id = 4,
                nombre = "Autoevaluacion",
                ponderacio = 0
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
