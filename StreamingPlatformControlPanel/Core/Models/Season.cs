using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using System;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(SeasonNum), nameof(SeriesId), IsUnique = true)]

    public class Season : BaseModel
    {
        public int Id { get; set; }
        public string SeasonNum { get; set; } = null!;
        public string TrailerPath { get; set; } = null!;

        public int SeriesId { get; set; }
        public Series? Series { get; set; }

        public ICollection<Episod> Episods { get; set; } = new List<Episod>();

    }
}
