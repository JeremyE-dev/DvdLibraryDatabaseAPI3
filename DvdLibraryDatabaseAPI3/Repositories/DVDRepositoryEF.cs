using DvdLibraryDatabaseAPI3.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryDatabaseAPI3.Repositories
{
    public class DVDRepositoryEF : IDvdRepository
    {

        public void Add(Dvd dvd)
        {
            var repository = new DvdLibraryEntities();
            Dvd d = new Dvd();
            d.Director = new Director();
            d.Rating = new Rating();
            d.ReleaseYear = new ReleaseYear();

            d.DvdId = repository.Dvds.Count() + 1; 
                  
            d.Title = dvd.Title;
            
            d.director = dvd.director;
            if (d.director != null)
            {

                if (repository.Directors.Count(x => x.director == d.director) == 0)
                {
                    //add director information to the database
                    d.Director.DirectorId = repository.Directors.Count() + 1;
                    d.DirectorId = d.Director.DirectorId;
                    d.Director.director = dvd.director;
                    d.director = d.Director.director;
                }

                else
                {
                    d.DirectorId = repository.Directors.First(x => x.director == d.director).DirectorId;
                }

            }

            d.rating = dvd.rating;
            
            //if(d.rating != null)
            //{
            //    d.RatingId = repository.Ratings.First(r => r.rating == d.rating).RatingId;
            //}

            d.releaseYear = dvd.releaseYear;

            //if (d.releaseYear != null)
            //{
            //    d.ReleaseYearId = repository.ReleaseYears.First(y => y.releaseYear == d.releaseYear).ReleaseYearId;
            //}

            d.Notes = dvd.Notes;

            repository.Dvds.Add(dvd);
            repository.SaveChanges();
        }

        public void Delete(int dvdID)
        {
            var repository = new DvdLibraryEntities();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 select d).ToList();


            Dvd dvdToDelete = allDvds.FirstOrDefault(d => d.DvdId == dvdID);

            if (dvdToDelete != null)
            {
                repository.Dvds.Remove(dvdToDelete);
                repository.SaveChanges();
            }
        }

        public void Edit(Dvd dvd)
        {
            var repository = new DvdLibraryEntities();


            Dvd d = GetById(dvd.DvdId);

            d.DvdId = dvd.DvdId;
            d.Title = dvd.Title;
            d.director = dvd.director;
            d.DirectorId = dvd.DirectorId;
            d.rating = dvd.rating;
            d.RatingId = dvd.RatingId;
            d.releaseYear = dvd.releaseYear;
            d.ReleaseYearId = dvd.ReleaseYearId;
            d.Notes = dvd.Notes;

            repository.SaveChanges();
        }

        public List<Dvd> GetAll()
        {
            List<Dvd> allDvds = new List<Dvd>();

            var repository = new DvdLibraryEntities();

            var d = from r in repository.Dvds
                    select r;

            allDvds =  d.ToList();

            foreach(Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

            return allDvds;         
            
        }

        public List<Dvd> GetByDirectorName(string director)
        {
            throw new NotImplementedException();
        }

        public Dvd GetById(int dvdId)
        {
            var repository = new DvdLibraryEntities();
            Dvd dvd = new Dvd();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 select d).ToList();

            dvd =  allDvds.FirstOrDefault(d => d.DvdId == dvdId);
            dvd.releaseYear = dvd.ReleaseYear.releaseYear;
            dvd.director = dvd.Director.director;
            dvd.rating = dvd.Rating.rating;

            return dvd;
        }

        public List<Dvd> GetByRating(string rating)
        {
            var repository = new DvdLibraryEntities();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 where d.rating == rating
                                 select d).ToList();

            foreach (Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

           return allDvds;
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            var repository = new DvdLibraryEntities();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 where d.releaseYear == releaseYear
                                 select d).ToList();
            
            foreach (Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

            return allDvds;
        }

        public List<Dvd> GetByTitle(string title)
        {
            var repository = new DvdLibraryEntities();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 where d.Title == title
                                 select d).ToList();

            foreach (Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

            return allDvds;
        }

        public Dvd GetOneDvdByTitle(string title)
        {
            var repository = new DvdLibraryEntities();
            Dvd dvd = new Dvd();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 select d).ToList();

            dvd = allDvds.FirstOrDefault(d => d.Title == title);
            dvd.releaseYear = dvd.ReleaseYear.releaseYear;
            dvd.director = dvd.Director.director;
            dvd.rating = dvd.Rating.rating;

            return dvd;
        }



    }
}