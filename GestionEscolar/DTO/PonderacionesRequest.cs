using GestionEscolar.Model;

namespace GestionEscolar.DTO
{
    public class PonderacionesRequest
    {
        public List<PonderacionRequest> listPonderaciones { get; set; }
    }

    public class PonderacionRequest
    {
        public string nombre { get; set; }
        public int ponderacion { get; set; }
    }
}
