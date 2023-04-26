using Microsoft.EntityFrameworkCore;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class FilmMaker : BaseModel
    { 
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ContentFilmMaker> Contents { get; set; } = new List<ContentFilmMaker>();
        public ICollection<FilmMakerRole> FilmRoles { get; set; } = new List<FilmMakerRole>();

    }
}
