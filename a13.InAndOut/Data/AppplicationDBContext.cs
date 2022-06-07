using a13.InAndOut.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace a13.InAndOut.Data
{
    public class AppplicationDBContext:DbContext
    {

        public AppplicationDBContext(DbContextOptions<AppplicationDBContext> options): base(options)
        {

        }

        public DbSet<Item> Items { get; set; } // What kind of Entity i want to create. The Item Entity. 
                                               // Items: Το όνομα του πίνακα στην βάση δεδομένων.

        public DbSet<Expense> Expenses { get; set; }


    }
}
