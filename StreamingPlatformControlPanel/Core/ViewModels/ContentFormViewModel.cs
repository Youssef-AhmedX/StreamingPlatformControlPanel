
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingPlatformControlPanel.Core.Models;

namespace StreamingPlatformControlPanel.Core.ViewModels
{
    public class ContentFormViewModel
    {
        // Content

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime ReleaseDate { get; set; }
        public char ContentType { get; set; }

        public int CertificationId { get; set; }
        public IEnumerable<SelectListItem>? Certifications { get; set; }

        public IList<int> SelectedCategories { get; set; } = null!;
        public IEnumerable<SelectListItem>? Categories { get; set; }


        //Movie Attr

        public string? TrailerPath { get; set; }
        public string? ContentPath { get; set; }
        public int? DurationTimeInHour { get; set; }
    }
}
