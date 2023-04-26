using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(ContentId), IsUnique = true)]
    public class Movie : BaseModel
    {
        public int Id { get; set; }
        public string TrailerPath { get; set; } = null!;
        public string ContentPath { get; set; } = null!;
        public int DurationTimeInHour { get; set; }



        public int ContentId { get; set; }
        public Content? Content { get; set; }
    }
}
