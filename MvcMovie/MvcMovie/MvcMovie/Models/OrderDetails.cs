using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    /*! \brief OrderDetails class is a model for order entities.
         */
    public class OrderDetails
    {
        public int Id { get; set;}

        [Display(Name = "Rent Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime RentDate { get; set; }

        [Display(Name = "Return Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime ReturnDate { get; set; }

        [Display(Name = "Exact Return Date")]
        [DataType(DataType.Date)]
        public DateTime? ExactReturnDate { get; set; }

        [Required]
        [ForeignKey("User")]
        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        [Required]
        [ForeignKey("Movie")]
        public int MovieID { get; set; }
        public Movie Movie { get; set; }

        public bool Damaged { get; set; }
    }

}
