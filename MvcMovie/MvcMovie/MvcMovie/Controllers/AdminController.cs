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
    /*! \brief AdminController class for Admin's version of page.
         *         There are actions for controlling page's functionality
         */
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;/*!< \param - for recieving data from database */
        private readonly UserManager<ApplicationUser> _userManager;/*!< \param - for using "Identity" framework functionality*/
       /**
       * A constructor taking two arguments.
       * This constructor recieves ApplicationDbContext and UserManager<ApplicationUser> variables and writes them to fields.
       */
        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

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

        //! Async Action for getting list of films and showing it.
        /*!
         * It's method that assign data list of films to model's object and return it to "Index" view. 
         * \param movies contain list of films.
         * \param movieGenreVM model's object
         * \return model for "Index" view.
         */
        public async Task<IActionResult> Index()
                {
                    var movies = _context.MovieViews.ToList();


                    var movieGenreVM = new MovieGenreViewModel
                    {
                        Movies = movies
                    };

                    return View("Index",movieGenreVM);
                }

        //! Async Action for getting modal view of film's details.
        /*!
         * This method gets id of film from view and returns partial view with film's details.
         * \param id it is id of film.
         * \param movie object of film.
         * \return model for "Details" partial view.
         */
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

            return PartialView("Details",movie);
        }

        //! Action for geting creating film view.
        /*!
         * This method can be used only by user with "Admin" role.
         * \return "Create" view.
         */
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View("AdminIndex");
        }

        //! Action for creating new film and adding it to database.
        /*!
         * This method gets data from view's form and saves entity of film in database.
         * As arguments gets Movie object and has binded values of form to write it in object.
         * \return redirects to "Index" view after finishing operation.
         */
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

        //! Action for geting "Edit" partial view.
        /*!
         * This method can be used only by user with "Admin" role.
         * It gets id of film as argument and check is film exist.
         * \param movie film with id from argument.
         * \return model to "Edit" partial view.
         */
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
            return PartialView("Edit",movie);
        }

        //! Action for saving edited movie .
        /*!
         * This method can be used only by user with "Admin" role.
         * It gets data from View's form, validate it and if everything is right 
         * method saves it in database.
         * \return model to "Index" view.
         */
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price,Rating,Quantity")] Movie movie)
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

        //! Action for geting "Delete" partial view.
        /*!
         * This method can be used only by user with "Admin" role.
         * It gets id of film as argument and check is film exist.
         * \param movie film with id from argument.
         * \return model to "Delete" partial view.
         */
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

            return PartialView("Delete",movie);
        }

        //! Action for delete movie .
        /*!
         * This method can be used only by user with "Admin" role.
         * It deletes selected film. 
         * Method saves changes in database.
         * \param movie film with id from argument.
         * \return "Index" view.
         */
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

        //! Action for geting "EditOrder" partial view.
        /*!
         * This method can be used only by user with "Admin" role.
         * It gets id of order as argument and check is order exist.
         * \param order order with id from argument.
         * \return model to "EditOrder" partial view.
         */
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

            return PartialView("EditOrder",orEd);
        }

        //! Action for editing order.
        /*!
         * This method can be used only by user with "Admin" role.
         * This method edits movie order depending on form content. 
         * Method saves changes in database.
         * \param order it's order with id from argument.
         * \return model on "Index" view.
         */
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditOrder(int id, [Bind("Id,ExactReturnDate,Damaged")] OrderEditModel orEd)
        {
            id = orEd.Id;
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
                return RedirectToAction(nameof(Index),"Admin");
            }
            return View(order);
        }

        //! Methode for checking is order exists.
        /*!
         *  \return true if exists and false if it doesn't exists 
         */
        private bool OrderExists(int id)
         {
             return _context.OrderDetails.Any(e => e.Id == id);
         }

        //! Methode for checking is movie exists.
        /*!
         *  \return true if exists and false if it doesn't exists 
         */
        private bool MovieExists(int id)
         {
             return _context.Movie.Any(e => e.Id == id);
         }
     }
 }
 