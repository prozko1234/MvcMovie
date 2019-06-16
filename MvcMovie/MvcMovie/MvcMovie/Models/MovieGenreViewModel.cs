using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{/*! \brief MovieGenreViewModel class is a view model of movie entities.
         */
    public class MovieGenreViewModel
    {
        public List<MovieView> Movies { get; set; }
       
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}