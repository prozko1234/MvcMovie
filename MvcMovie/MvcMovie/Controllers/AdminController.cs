﻿using System;
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
    public class AdminController : Controller
    {
        // GET: /<controller>/
        
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        //-----------------------------------------------------------------
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        //-----------------------------------------------------------------
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
            ViewData["GenreParam"] = sortOrder == "Genre" ? "Genre_desc" : "Genre";
            ViewData["PriceParam"] = sortOrder == "Price" ? "Price_desc" : "Price";
            ViewData["CurrentFilter"] = searchString;
            ViewData["answ"] = "-";

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
            var options = await _context.Movie.AsQueryable().Select(x => x.Genre).Distinct().Select(x => new SelectListItem(x, x)).ToListAsync();
            
            if (!String.IsNullOrEmpty(searchString))
            {
                movies = movies.Where(m => m.Title.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(movieGenre))
            {
                movies = movies.Where(x => x.Genre == movieGenre);
            }
            int pageSize = 3;
            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = options,
                Movies = await PaginatedList<MovieView>.CreateAsync(movies, page ?? 1, pageSize)
            };


            //if (User.Identity.IsAuthenticated)
            //{
            //    if (User.IsInRole("Admin"))
            //    {
            //        return View("AdminIndex",movieGenreVM);
            //    }
            //}
            return View(movieGenreVM);
        }

        // GET: Movies/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // GET: Movies/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("AdminIndex");
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.Id == id);

            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        // POST: Movies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        {
            if (id != movie.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MovieExists(movie.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }

        // GET: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // POST: Movies/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var movie = await _context.Movie.SingleOrDefaultAsync(m => m.Id == id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MyRent()
        {
            var userId = await GetCurrentUserId();
            
            var orders1 = _context.OrderDetails.Include(x => x.Movie).Include(x => x.User).ToList();
            
            RentViewModel rentVM = new RentViewModel()
            {
                OrdersDetails = orders1
            };

            return View("MyRentAdm", rentVM);
        }

        

        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> EditOrder(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var order = await _context.OrderDetails.SingleOrDefaultAsync(x => x.Id == id);

            if (order == null)
            {
                return NotFound();
            }

            OrderEditModel orEd = new OrderEditModel()
            {
                Id = order.Id,
                ExactReturnDate = order.ExactReturnDate,
                Damaged = order.Damaged
            };

            return View("EditOrder",orEd);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(int id, [Bind("Id,ExactReturnDate,Damaged")] OrderEditModel orEd)
        {
            var order = await _context.OrderDetails.SingleOrDefaultAsync(x => x.Id == id);

            order.ExactReturnDate = orEd.ExactReturnDate;
            order.Damaged = orEd.Damaged;

            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(order);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderExists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(MyRent),"Admin");
            }
            return View(order);
        }

        private bool OrderExists(int id)
        {
            return _context.OrderDetails.Any(e => e.Id == id);
        }

        private bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}