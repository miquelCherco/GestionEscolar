using GestionEscolar.Model;

namespace GestionEscolar.DTO
{
    public class PonderacionesRequest
    {
        public List<Poderacion> listPonderaciones { get; set; }
    }

    public class Poderacion
    {
        public string nombre { get; set; }
        public int ponderacion { get; set; }
    }
}
