using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AirCanadaTechnicalInterview.Server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;


namespace AirCanadaTechnicalInterview.Server.Data
{
    public class AirCanadaTechnicalInterviewServerContext : IdentityDbContext<IdentityUser>
    {
        public AirCanadaTechnicalInterviewServerContext (DbContextOptions<AirCanadaTechnicalInterviewServerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Book>().HasData(new[] {
                new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "Children of Dune",
                    Author = "Frank Herbert"
                }, new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Lord of the Rings: The Fellowship of the ring",
                    Author = "Tolkien"
                }, new Book
                {
                    Id = Guid.NewGuid(),
                    Title = "The Three-Body Problem",
                    Author = "Liu Cixin"
                }}
            );
        }

        public DbSet<AirCanadaTechnicalInterview.Server.Models.Book> Book { get; set; } = default!;
    }

}
