namespace DvdLibraryDatabaseAPI3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DvdLibraryDatabaseAPI3.DvdLibraryEntities>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DvdLibraryDatabaseAPI3.DvdLibraryEntities context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Ratings.AddOrUpdate(
                      r => r.rating,
                      new Models.Rating { rating = "G" },
                      new Models.Rating { rating = "PG" },
                      new Models.Rating { rating = "PG-13" },
                      new Models.Rating { rating = "R" }
                      );
            context.Directors.AddOrUpdate(
                d => d.director,
                new Models.Director { director = "Hartnell" },
                new Models.Director { director = "Troughton" },
                new Models.Director { director = "Pertwee" },
                new Models.Director { director = "Baker" }
                );
            context.ReleaseYears.AddOrUpdate(
                d => d.releaseYear,
                new Models.ReleaseYear { releaseYear = 1900 },
                new Models.ReleaseYear { releaseYear = 1901 },
                new Models.ReleaseYear { releaseYear = 1902 },
                new Models.ReleaseYear { releaseYear = 1903 }
                );
            context.SaveChanges();

            context.Dvds.AddOrUpdate(
                m => m.Title,
                new Models.Dvd
                {
                    Title = "Star Wars",
                    RatingId = context.Ratings.First(r => r.rating == "R").RatingId,
                    DirectorId = context.Directors.First(r => r.director == "Hartnell").DirectorId,
                    ReleaseYearId = context.ReleaseYears.First(y => y.releaseYear == 1900).ReleaseYearId,
                }

            );


        }
    }
}
