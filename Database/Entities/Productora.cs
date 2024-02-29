namespace Database.Entities
{
    public class Productora
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Serie>? Series { get; set; }
    }
}
