namespace Database.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Serie>? Series { get; set; }
        public ICollection<Serie>? AltSeries { get; set; }
    }
}
