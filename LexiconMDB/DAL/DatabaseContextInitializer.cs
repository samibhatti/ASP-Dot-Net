using LexiconMDB.Models;
using System.Collections.Generic;
using System.Data.Entity;
using LexiconMDB.Models;

namespace LexiconMDB.DAL
{
    internal class DatabaseContextInitializer : DropCreateDatabaseAlways<LexiconMDBContext>
    {
        protected override void Seed(LexiconMDBContext context)
        {
            context.Movies.AddRange(new List<Movie> {
            new Movie { Title = "Hallo Hallo", Genre = "Horror", Length = 95 },
            new Movie { Title = "Dee Wee", Genre = "Horror", Length = 90 },
            new Movie { Title = "Chal Chal", Genre = "Drama", Length = 195 },
            new Movie { Title = "Da Da", Genre = "Drama", Length = 55 },

            });
        }
    }
}