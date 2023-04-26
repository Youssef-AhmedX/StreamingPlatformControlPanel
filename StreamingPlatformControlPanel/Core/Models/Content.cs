using Microsoft.EntityFrameworkCore;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Content : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public char ContentType { get; set; }

        public int CertificationId { get; set; } 
        public Certification? Certification { get; set; }

        public ICollection<ContentFilmMaker> FilmMakers { get; set; } = new List<ContentFilmMaker>();
        public ICollection<ContentCategory> Categories { get; set; } = new List<ContentCategory>();


    }
}
