﻿using Microsoft.EntityFrameworkCore;

namespace StreamingPlatformControlPanel.Core.Models
{
    [Index(nameof(ContentId), IsUnique = true)]
    public class Series : BaseModel
    {
        public int Id { get; set; }

        public int ContentId { get; set; }
        public Content? Content { get; set; }

        public ICollection<Season> Seasons { get; set; } = new List<Season>();

    }
}
