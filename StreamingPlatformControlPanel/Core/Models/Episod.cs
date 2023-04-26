using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(EpNum),nameof(SeasonId), IsUnique = true)]
    public class Episod : BaseModel
    {
        public int Id { get; set; }
        public string ContentPath { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string EpNum { get; set; } = null!;
        public string EpName { get; set; } = null!;
        public int DurationTimeInHour { get; set; }


        public int SeasonId { get; set; }
        public Season? Season { get; set; }
    }
}
