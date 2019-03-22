using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{   
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Movies
        public async Task<IActionResult> Index(
            string movieGenre,
            string searchString,
            string currentFilter,
            string sortOrder, 
            int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["TitleSortParam"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["RelDateParam"] = sortOrder == "Release Date" ? "RelDate_desc" : "Release Date";
            ViewData["GenreParam"] = sortOrder == "Genre" ? "Genre_desc":"Genre";
            ViewData["PriceParam"] = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            
            var movies = from m in _context.MovieViews
                         select m;

            switch (sortOrder)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(m => m.Title);
                    break;
                case "RelDate_desc":
                    movies = movies.OrderByDescending(m => m.ReleaseDate);
                    break;
                case "Release Date":
                    movies = movies.OrderBy(m => m.ReleaseDate);
                    break;
                case "Genre_desc":
                    movies = movies.OrderByDescending(m => m.Genre);
                    break;
                case "Genre":
                    movies = movies.OrderBy(m => m.Genre);
                    break;
                case "Price_desc":
                    movies = movies.OrderByDescending(m => m.Price);
                    break;
                case "Price":
                    movies = movies.OrderBy(m => m.Price);
                    break;
                default:
                    movies = movies.OrderBy(m => m.Title);
                    break;  
            }
            //FILTERING
            var options = await  _context.Movie.AsQueryable().Select(x => x.Genre).Distinct().Select(x => new SelectListItem(x, x)).ToListAsync();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }

            int pageSize = 4;

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = options,
                Movies = await PaginatedList<MovieView>.CreateAsync(movies, page ?? 1, pageSize)
            };
            
            return View(movieGenreVM);
        }
        
        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
