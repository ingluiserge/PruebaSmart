namespace PruebaSmart.Model
{
    public class Habitacion
    {
        public Guid Id { get; set; }
        public string? Description { get; set; }
        public double Costo { get; set; }
        public string? Base { get; set; }
        public double Tax { get; set; }
        public string? Type { get; set; }
        public string? Ubicacion { get; set; }
        public bool Enable { get; set; }

        public Guid? HotelId { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual List<Reserva> Reservas { get; set; }
    }
}
