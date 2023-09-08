namespace GestionEscolar.Model
{
    public class Alumno
    {
        public int id {  get; set; }
        public string nombre { get; set; }
        public int edad { get; set; }
        public List<Actividad> listActividades { get; set;}
    }
}
