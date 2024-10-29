using Microsoft.EntityFrameworkCore;
using MyNewCiniesOction.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public ChiniesOctionContext Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<ChiniesOctionContext>()
                               // .UseSqlServer("Server=srv2\\pupils;Database=ElishevaTests;Trusted_Connection=True;")
                               .UseSqlServer("Server=DESKTOP-E0FAPSB\\SQLEXPRESS;Database=ElishevaTests;Trusted_Connection=True;")

                .Options;
            Context = new ChiniesOctionContext(options);
            Context.Database.EnsureCreated();// create the data base
        }

        public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
