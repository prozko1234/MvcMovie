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
{   /*! \brief MoviesController class for User's version of page.
         *         There are actions for controlling page's functionality
         */
    public class MoviesController : Controller
    {
        private readonly ApplicationDbContext _context;/*!< \param - for recieving data from database */
        /**
       * A constructor taking two arguments.
       * This constructor recieves ApplicationDbContext variable and writes them to field.
       */
        public MoviesController(ApplicationDbContext context)
        {
            _context = context;
        }

        //! Async Action for getting list of films and showing it.
        /*!
         * It's method that assign data list of films to model's object and return it to "Index" view. 
         * \return model for "Index" view.
         */
        public async Task<IActionResult> Index()
        {
            var movies = from m in _context.MovieViews
                         select m;
            
            var options =  _context.MovieViews.ToList();

            var movieGenreVM = new MovieGenreViewModel
            {
                Movies = options
            };
            
            return View(movieGenreVM);
        }
        //! Methode for checking is movie exists.
        /*!
         * \param id of film
         *  \return true if exists and false if it doesn't exists 
         */
        public bool MovieExists(int id)
        {
            return _context.Movie.Any(e => e.Id == id);
        }
    }
}
