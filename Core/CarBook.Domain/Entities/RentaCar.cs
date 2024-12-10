namespace CarBook.Domain.Entities
{
    public class RentaCar
    {
        public int RentACarId { get; set; }
        public int LocationID { get; set; }
        public Location Location { get; set; }
        public int CarId { get; set; }
        public Car Car { get; set; }
        public bool Available { get; set; }
    }
}
