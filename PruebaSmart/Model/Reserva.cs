namespace PruebaSmart.Model
{
    public class Reserva
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual Huesped Huesped { get; set; }
        public virtual Habitacion Habitacion { get; set; }
    }
}
