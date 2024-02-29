namespace Database.Entities
{
    public class Serie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public string Url { get; set; }
        public int PrimaryGenreId { get; set; }
        public int? SecondaryGenreId { get; set; }
        public int ProductoraId { get; set; }

        //navigation properties
        public Genre PrimaryGenre { get; set; }
        public Genre? SecondaryGenre { get; set; }
        public Productora Productora { get; set; }
    }
}
