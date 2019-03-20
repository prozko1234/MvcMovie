using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class MovieView
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public DateTime ReleaseDate { get; private set; }
        public decimal Price { get; private set; }
        public string Genre { get; private set; }
        public string Rating { get; private set; }
        public uint Quantity { get; private set; }
        public uint QuantityMax { get; private set; }
        public DateTime NearDate { get; private set; }
    }
}