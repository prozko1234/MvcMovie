using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        public List<MovieView> Movies { get; set; }
       
        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}