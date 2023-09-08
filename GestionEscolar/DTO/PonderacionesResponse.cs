namespace GestionEscolar.DTO
{
    public class PonderacionesResponse
    {
        public List<Poderacion> listPonderaciones { get; set; }
    }

    public class Ponderacion
    {
        public string nombre { get; set; }
        public int pondercaion { get; set; }
    }
}
