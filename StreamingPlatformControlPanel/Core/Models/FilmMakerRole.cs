namespace StreamingPlatformControlPanel.Core.Models
{
    public class FilmMakerRole
    {
        public int FilmMakerId { get; set; }
        public FilmMaker? FilmMaker { get; set; }

        public int FilmRoleId { get; set; }
        public FilmRole? FilmRole { get; set; }
    }
}
