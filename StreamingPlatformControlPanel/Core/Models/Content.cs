namespace StreamingPlatformControlPanel.Core.Models
{
    public class Content : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public char ContentType { get; set; }

        public int CertificationId { get; set; } 
        public Certification? Certification { get; set; }

        public ICollection<FilmMaker> FilmMakers { get; set; } = new List<FilmMaker>();
        public ICollection<Category> Categories { get; set; } = new List<Category>();


    }
}
