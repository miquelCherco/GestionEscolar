namespace GestionEscolar.DTO
{
    public class PonderacionesResponse
    {
        public List<PonderacionResponse> listPonderaciones { get; set; }
    }

    public class PonderacionResponse
    {
        public string nombre { get; set; }
        public int ponderacion { get; set; }
    }
}
