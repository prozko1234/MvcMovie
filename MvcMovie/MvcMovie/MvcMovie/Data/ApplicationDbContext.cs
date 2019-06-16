using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Models;

namespace MvcMovie.Data
{/*! \brief ApplicationDbContext class created for coordinatig functionality of EntityFramework.
         *         There are added db context and entities
         */
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {}
        
        public DbSet<Movie> Movie { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbQuery<MovieView> MovieViews { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Query<MovieView>().ToView("available_movies");
        }
    }
}
