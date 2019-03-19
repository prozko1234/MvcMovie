using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcMovie.Models
{
    public class RentViewModel
    {
        public PaginatedList<OrderDetails> OrdersDetails { get; set; }

    }
}
