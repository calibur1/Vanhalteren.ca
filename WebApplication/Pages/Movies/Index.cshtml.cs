using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication.Models;


namespace WebApplication.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMovieContext _context;

        public IndexModel(RazorPagesMovieContext context)
        {
            _context = context;
        }

        
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        [BindProperty(SupportsGet = true)]
        public string MovieGenre { get;set; }
        
        public SelectList Genres { get;set; }
        
        public IList<Movie> Movie { get; set; }
        
        
        
        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery =
                from m in _context.Movie
                orderby m.Genre
                select m.Genre;
            
            IQueryable<Movie> movieQuery = _context.Movie.AsQueryable();

            if (!string.IsNullOrEmpty(SearchString))
                movieQuery = movieQuery.Where(x => x.Title.Contains(SearchString));

            if (!string.IsNullOrEmpty(MovieGenre))
                movieQuery = movieQuery.Where(x => x.Genre == MovieGenre);
            
            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Movie = await movieQuery.ToListAsync();
        }
    }
}
