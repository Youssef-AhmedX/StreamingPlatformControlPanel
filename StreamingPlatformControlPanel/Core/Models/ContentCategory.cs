namespace StreamingPlatformControlPanel.Core.Models
{
    public class ContentCategory
    {
        public int ContentId { get; set; }
        public Content? Content { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
