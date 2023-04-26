using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StreamingPlatformControlPanel.Core.Models;
using StreamingPlatformControlPanel.Core.ViewModels;
using StreamingPlatformControlPanel.Data;

namespace StreamingPlatformControlPanel.Controllers
{
    public class ContentController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public ContentController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public IActionResult Index(bool ContentType = true)
        {

            var ContentList = _context.Contents
                .Where(c => c.ContentType == (ContentType ? 'M' : 'S'))
                //Content Type = true => Movie :: Content Type = false => Series                                                                                 
                .Include(c => c.Certification)
                .Include(c => c.Categories)
                .ThenInclude(c => c.Category)
                .Include(c => c.FilmMakers)
                .ThenInclude(f => f.FilmMaker)
                .ToList();


            return View(ContentList);
        }

        public IActionResult Details(int Id, bool ContentType = true)
        {
            //Content Type = true => Movie :: Content Type = false => Series                                                                                 

            if (ContentType == true)
            {
                var movie = _context.Movies
                    .Include(m => m.Content)
                    .ThenInclude(c => c.Categories)
                    .ThenInclude(c => c.Category)
                    .Include(m => m.Content)
                    .ThenInclude(c => c.FilmMakers)
                    .ThenInclude(f => f.FilmMaker)
                    .Include(m => m.Content)
                    .ThenInclude(c => c.Certification)
                    .ThenInclude(c => c.Name)
                    .FirstOrDefault(m => m.ContentId == Id);

                if (movie is null)
                    return RedirectToAction(nameof(Index));

                return View("MovieDetails", movie);


            }
            else
            {
                var series = _context.Series
                    .Include(s => s.Content)
                    .ThenInclude(c => c.Categories)
                    .ThenInclude(c => c.Category)
                    .Include(s => s.Content)
                    .ThenInclude(c => c.FilmMakers)
                    .ThenInclude(f => f.FilmMaker)
                    .Include(s => s.Content)
                    .ThenInclude(c => c.Certification)
                    .Include(s => s.Seasons)
                    .ThenInclude(s => s.Episods)
                    .FirstOrDefault(m => m.ContentId == Id);

                if (series is null)
                    return RedirectToAction(nameof(Index));

                return View("SeriesDetails", series);

            }


        }

        public IActionResult Create()
        {
            return View(IntitialBookForm());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContentFormViewModel contentForm)
        {
            if (!ModelState.IsValid || contentForm.ContentType != 'S' && contentForm.ContentType != 'M')
                return View(IntitialBookForm(contentForm));

            if (contentForm.TrailerPath is null || contentForm.DurationTimeInHour is null || contentForm.ContentPath is null)
            {
                if (contentForm.ContentType == 'M')
                    return View(IntitialBookForm(contentForm));
            }

            var content = _mapper.Map<Content>(contentForm);

            foreach (var SelectedCategoryId in contentForm.SelectedCategories)
            {
                content.Categories.Add(new ContentCategory { CategoryId = SelectedCategoryId });
            }

            content.Isdeleted = true;

            _context.Contents.Add(content);
            _context.SaveChanges();

            if (contentForm.ContentType == 'M')
                CreateMovie((int)contentForm.DurationTimeInHour!, contentForm.ContentPath!, contentForm.TrailerPath!, content.Name!);
            else
                CreateSeries(content.Name);

            return RedirectToAction(nameof(Index));
        }

        private void CreateMovie(int DurationTimeInHour, string ContentPath, string TrailerPath, string ContentName)
        {
            var content = _context.Contents.FirstOrDefault(c => c.Name == ContentName);

            if (content != null)
            {
                Movie movie = new()
                {
                    ContentId = content.Id,
                    ContentPath = ContentPath,
                    DurationTimeInHour = DurationTimeInHour,
                    TrailerPath = TrailerPath,

                };

                _context.Movies.Add(movie);
                _context.SaveChanges();
            }


        }

        private void CreateSeries(string ContentName)
        {
            var content = _context.Contents.FirstOrDefault(c => c.Name == ContentName);

            if (content != null)
            {
                Series series = new()
                {
                    ContentId = content.Id,

                };

                _context.Series.Add(series);
                _context.SaveChanges();
            }
        }

        public IActionResult ToggleStatus(int Id)
        {
            var content = _context.Contents.Find(Id);

            if (content is null || !content.Categories.Any() || !content.FilmMakers.Any())
                return BadRequest();

            if (content.ContentType == 'M')
            {
                var ContentMovie = _context.Movies.FirstOrDefault(x => x.ContentId == Id);
                if (ContentMovie is null)
                    return BadRequest();
            }
            else
            {
                var ContentSeries = _context.Series.FirstOrDefault(x => x.ContentId == Id);
                if (ContentSeries is null)
                    return BadRequest();
            }


            content.Isdeleted = !content.Isdeleted;

            _context.Contents.Update(content);
            _context.SaveChanges();

            return Ok();
        }

        private ContentFormViewModel IntitialBookForm(ContentFormViewModel? form = null)
        {
            ContentFormViewModel contentForm = form is null ? new ContentFormViewModel() : form;

            var Categories = _context.Categories
                .Where(c => !c.Isdeleted)
                .OrderBy(c => c.Name)
                .ToList();

            var Certifications = _context.Certifications
                .Where(c => !c.Isdeleted)
                .ToList();

            contentForm.Categories = _mapper.Map<IEnumerable<SelectListItem>>(Categories);
            contentForm.Certifications = _mapper.Map<IEnumerable<SelectListItem>>(Certifications);
            if (form is null)
                contentForm.ReleaseDate = DateTime.Now;


            return contentForm;
        }
    }
}
