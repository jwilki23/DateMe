using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMe.Models
{
    public class DateInfoContext : DbContext
    {
        //Constructor
        public DateInfoContext (DbContextOptions<DateInfoContext> options) : base (options)
        {
            //Leave blank for now
        }

        public DbSet<ApplicationResponse> responses { get; set; }
        public DbSet<Major> Majors { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Major>().HasData(
                new Major { MajorId = 1, MajorName="Information Systems" },
                new Major { MajorId = 2, MajorName="Accounting"},
                new Major { MajorId = 3, MajorName="Neuroscience" },
                new Major { MajorId = 4, MajorName="Actuarial Science"},
                new Major { MajorId = 5, MajorName="Psychology"},
                new Major { MajorId = 6, MajorName="Undeclared"}
                );
            mb.Entity<ApplicationResponse>().HasData(

                    new ApplicationResponse
                    {
                        ApplicationID = 1,
                        FirstName = "Michael",
                        LastName = "Scott",
                        Age = 45,
                        Phone = "555-123-2356",
                        MajorId = 4,
                        CreeperStalker = false
                    },
                    new ApplicationResponse
                    {
                        ApplicationID = 2,
                        FirstName = "Creed",
                        LastName = "Bratton",
                        Age = 60,
                        Phone = "555-234-5646",
                        MajorId = 6,
                        CreeperStalker = true
                    }
                );
        }
    }
}
