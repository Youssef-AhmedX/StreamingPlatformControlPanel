using Microsoft.EntityFrameworkCore;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(Name),IsUnique =true)]
    public class Category :BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public ICollection<ContentCategory> Contents { get; set; } = new List<ContentCategory>();
    }
}
