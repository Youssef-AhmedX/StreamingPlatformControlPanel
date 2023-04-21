namespace StreamingPlatformControlPanel.Core.Models
{
    public class FilmMaker : BaseModel
    { 
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<Content> Contents { get; set; } = new List<Content>();
        public ICollection<FilmRole> FilmRoles { get; set; } = new List<FilmRole>();

    }
}
