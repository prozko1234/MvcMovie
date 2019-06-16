using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{/*! \brief RentViewModel class is a view model of order entities.
         */
    public class RentViewModel
    {
        public List<OrderDetails> OrdersDetails { get; set; }
    }
}
