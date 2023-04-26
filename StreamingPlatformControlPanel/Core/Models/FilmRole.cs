namespace StreamingPlatformControlPanel.Core.Models
{
    public class FilmRole : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<FilmMakerRole> FilmMakers { get; set; } = new List<FilmMakerRole>();

    }
}
