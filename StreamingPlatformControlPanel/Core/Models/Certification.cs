using Microsoft.EntityFrameworkCore;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(Name), IsUnique = true)]
    public class Certification : BaseModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        
        public ICollection<Content> Contents { get; set; } = new List<Content>();
    }
}
