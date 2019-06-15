using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class OrderEditModel
    {
        public int Id { get; set; }
        
        public DateTime? ExactReturnDate { get; set; }

        public bool Damaged { get; set; }
    }
}
