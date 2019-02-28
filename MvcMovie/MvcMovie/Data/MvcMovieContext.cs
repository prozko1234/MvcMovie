using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MvcMovie.Models
{
    //public class MvcMovieContext : DbContext
    //{
    //    public MvcMovieContext (DbContextOptions<MvcMovieContext> options)
    //        : base(options)
    //    {
    //    }
    public class MvcMovieContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options)
            : base(options)
        { }

        public DbSet<MvcMovie.Models.Movie> Movie { get; set; }
    }


}
