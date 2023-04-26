namespace StreamingPlatformControlPanel.Core.Models
{
    public class ContentCategory
    {
        public int CategoryId { get; set; }
        public Category? Category { get; set; }


        public int ContentId { get; set; }
        public Content? Content { get; set; }


    }
}
