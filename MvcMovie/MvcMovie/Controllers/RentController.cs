using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MvcMovie.Controllers
{
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        //---------------------
        private readonly UserManager<ApplicationUser> _userManager;
        
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }

        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
        //---------------------

        [Authorize(Roles = "User")]
        public async Task<IActionResult> Index(int? movieId)
        {
            if (movieId == null)
            {
                return NotFound();
            }

            var movie = await _context.Movie
                .SingleOrDefaultAsync(m => m.Id == movieId);

            if (movie == null)
            {
                return NotFound();
            }

            OrderDetails orDet = new OrderDetails();
            orDet.MovieID = movie.Id;

            orDet.UserId = await GetCurrentUserId();
            
            return View(orDet);
        }

        [Authorize(Roles = "User")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("RentDate,ReturnDate,MovieID,UserId")] OrderDetails orDet)
        {
            if (ModelState.IsValid)
            {
                Console.WriteLine(orDet.UserId);

                _context.Add(orDet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index),"Movies");
            }

            return View("Index",orDet);
        }

        public async Task<IActionResult> MyRent()
        {
            var userId = await GetCurrentUserId();
            //var orders = from o in _context.OrderDetails
            //             where o.UserId == userId
            //            select o;

            var orders1 = _context.OrderDetails.Include(x => x.Movie).Where(x => x.UserId == userId).ToList();
            
            RentViewModel rentVM = new RentViewModel()
            {
                OrdersDetails = orders1
            };

            return View("MyRent",rentVM);
        }
    }
}
