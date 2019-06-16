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


namespace MvcMovie.Controllers
{/*! \brief RentController class controlling pages related with movie rent.
         *         There are actions for controlling page's functionality
         */
    public class RentController : Controller
    {
        private readonly ApplicationDbContext _context;/*!< \param - for recieving data from database */
        /**
       * A constructor taking two arguments.
       * This constructor recieves ApplicationDbContext and UserManager<ApplicationUser> variables and writes them to fields.
       */
        public RentController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        private readonly UserManager<ApplicationUser> _userManager;/*!< \param - for using "Identity" framework functionality*/
        //! Async Action for geting current user ID.
        /*!
         * It's HttpGet method that gets object of user that currentky logged on page. 
         * \param usr current user object.
         * \return user's ID.
         */
        [HttpGet]
        public async Task<string> GetCurrentUserId()
        {
            ApplicationUser usr = await GetCurrentUserAsync();
            return usr?.Id;
        }
        //! Method for getting current user object.
        private Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);

        //! Async Action for geting modal view and showing it.
        /*!
         * This action shows modal view to make movie order.
         * This method requires user to be logged in. 
         * \param movies contain list of films.
         * \param orDet model's object
         * \return model for "Index" view.
         */
        [Authorize(Roles = "User,Admin")]
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
            
            return PartialView("Index", orDet);
        }

        //! Action for creating new order and adding it to database.
        /*!
         * This method gets data from view's form and saves entity of rent in database.
         * As arguments gets OrderDetail object and has binded values of form to write it in object.
         * \return redirects to "Index" view after finishing operation.
         */
        [Authorize(Roles = "User,Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("RentDate,ReturnDate,MovieID,UserId")] OrderDetails orDet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orDet);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index),"Movies");
            }

            return PartialView("Index",orDet);
        }
        //! Async Action for getting list of orders made by logged in user and showing it.
        /*!
         * It's method that assign data list of orders to model's object and return it to "MyRent" view. 
         * \userId id of logged in user.
         * \param orders1 list of orders made by logged in user
         * \param rentVM model's object
         * \return model for "MyRent" view.
         */
        public async Task<IActionResult> MyRent()
        {
            var userId = await GetCurrentUserId();

            var orders1 = _context.OrderDetails.Include(x => x.Movie).Where(x => x.UserId == userId).ToList();
            
            RentViewModel rentVM = new RentViewModel()
            {
                OrdersDetails = orders1
            };

            return View("MyRent",rentVM);
        }

        //! Async Action for getting list of orders made by all users and showing it.
        /*!
         * It's method that assign data list of orders made by all users to model's object and return it to "MyRent" view. 
         * \userId id of logged in user.
         * \param orders1 list of orders made by logged in user
         * \param rentVM model's object
         * \return model for "MyRent" view.
         */
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> MyRentAdm()
        {
            var userId = await GetCurrentUserId();

            var orders1 = _context.OrderDetails.Include(x => x.Movie).Include(x => x.User).ToList();

            RentViewModel rentVM = new RentViewModel()
            {
                OrdersDetails = orders1
            };

            return View("MyRentAdm", rentVM);
        }
    }
}
