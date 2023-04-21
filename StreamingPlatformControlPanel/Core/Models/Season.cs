namespace StreamingPlatformControlPanel.Core.Models
{
    public class Season : BaseModel
    {
        public int Id { get; set; }
        public string SeasonNum { get; set; } = null!;
        public string TrailerPath { get; set; } = null!;

        public int SeriesId { get; set; }
        public Series? Series { get; set; }
    }
}
