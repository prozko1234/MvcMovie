using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace MvcMovie.Models
{
    public class MovieGenreViewModel
    {
        //public PaginatedList<MovieView> MovieViews{ get; set; }
        public PaginatedList<MovieView> Movies { get; set; }
        public List<SelectListItem> Genres { get; set; }

        public string MovieGenre { get; set; }
        public string SearchString { get; set; }
    }
}