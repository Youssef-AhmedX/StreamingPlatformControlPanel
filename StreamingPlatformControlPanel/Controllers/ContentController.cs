using Microsoft.AspNetCore.Mvc;
using StreamingPlatformControlPanel.Data;

namespace StreamingPlatformControlPanel.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContentController(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
