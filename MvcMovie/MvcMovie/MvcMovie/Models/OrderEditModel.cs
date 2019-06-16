using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{/*! \brief OrderEditModel class is a model for editing order entities.
         */
    public class OrderEditModel
    {
        public int Id { get; set; }
        
        public DateTime? ExactReturnDate { get; set; }

        public bool Damaged { get; set; }
    }
}
