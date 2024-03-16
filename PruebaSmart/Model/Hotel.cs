namespace PruebaSmart.Model
{
    public class Hotel
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Enable { get; set; }        

        public List<Habitacion> Habitacions { get; set; }
    }
}
