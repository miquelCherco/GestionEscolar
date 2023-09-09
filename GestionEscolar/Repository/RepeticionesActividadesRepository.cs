using GestionEscolar.Model;

namespace GestionEscolar.Repository
{
    public class RepeticionesActividadesRepository
    {
        public List<RepeticionesActividades> listRepeticiones = new List<RepeticionesActividades>
        {
            new RepeticionesActividades
            {
                idActividad = 1,
                repticiones = 2
            },
            new RepeticionesActividades
            {
                idActividad = 2,
                repticiones = 1
            }
        };

        public List<RepeticionesActividades> GetRepeticionesActividades()
        {
            return listRepeticiones;
        }
    }
}
