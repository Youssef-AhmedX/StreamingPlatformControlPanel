namespace StreamingPlatformControlPanel.Core.Models
{
    public class ContentFilmMaker
    {
        public int ContentId { get; set; }
        public Content? Content { get; set; }

        public int FilmMakerId { get; set; }
        public FilmMaker? FilmMaker { get; set; }

        public string Role { get; set; } = null!;
    }
}
