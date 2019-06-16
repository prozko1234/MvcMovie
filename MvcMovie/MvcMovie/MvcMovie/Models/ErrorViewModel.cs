using System;

namespace MvcMovie.Models
{/*! \brief ErrorViewModel class created automaticly.
         */
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}