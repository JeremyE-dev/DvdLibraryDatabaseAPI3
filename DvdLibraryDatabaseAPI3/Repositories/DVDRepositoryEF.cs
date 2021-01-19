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
                    repository.SaveChanges();
                }

                else
                {
                    //set director to existing instance of director
                    d.Director = repository.Directors.First(x => x.director == d.director);
                    d.Director.DirectorId = repository.Directors.First(x => x.director == d.director).DirectorId;
                    d.DirectorId = d.Director.DirectorId;
                    d.director = d.Director.director;
                    repository.SaveChanges();
                }

            }

            d.rating = dvd.rating;

            if (d.rating != null)
            {

                if (repository.Ratings.Count(x => x.rating == d.rating) == 0)
                {
                    //add director information to the database
                    d.Rating.RatingId = repository.Ratings.Count() + 1;
                    d.RatingId = d.Rating.RatingId;
                    d.Rating.rating = dvd.rating;
                    d.rating = d.Rating.rating;
                    repository.SaveChanges();
                }

                else
                {
                    //set director to existing instance of director
                    d.Rating = repository.Ratings.First(x => x.rating == d.rating);
                    d.Rating.RatingId = repository.Ratings.First(x => x.rating == d.rating).RatingId;
                    d.RatingId = d.Rating.RatingId;
                    d.rating = d.Rating.rating;
                    repository.SaveChanges();
                }

            }
            d.releaseYear = dvd.releaseYear;

            if (d.releaseYear != null)
            {

                if (repository.ReleaseYears.Count(x => x.releaseYear == d.releaseYear) == 0)
                {
                    //add director information to the database
                    d.ReleaseYear.ReleaseYearId = repository.ReleaseYears.Count() + 1;
                    d.ReleaseYearId = d.ReleaseYear.ReleaseYearId;
                    d.ReleaseYear.releaseYear = (int)d.releaseYear;
                    d.releaseYear = d.ReleaseYear.releaseYear;
                    repository.SaveChanges();
                }

                else
                {
                    //set director to existing instance of director
                    d.ReleaseYear = repository.ReleaseYears.First(x => x.releaseYear == d.releaseYear);
                    d.ReleaseYear.ReleaseYearId = repository.ReleaseYears.First(x => x.releaseYear == d.releaseYear).ReleaseYearId;
                    d.ReleaseYearId = d.ReleaseYear.ReleaseYearId;
                    d.releaseYear = d.ReleaseYear.releaseYear;
                    repository.SaveChanges();

                }
                d.Notes = dvd.Notes;

                repository.Dvds.Add(d);
                repository.SaveChanges();
            }
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

          

            Dvd d = repository.Dvds.Where(x => x.DvdId == dvd.DvdId).First();

            d.Director = new Director();
            d.Rating = new Rating();
            d.ReleaseYear = new ReleaseYear();


            if (d != null)
            {
                d.DvdId = dvd.DvdId;
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
                        repository.SaveChanges();
                    }

                    else
                    {
                        //set director to existing instance of director
                        d.Director = repository.Directors.First(x => x.director == d.director);
                        d.Director.DirectorId = repository.Directors.First(x => x.director == d.director).DirectorId;
                        d.DirectorId = d.Director.DirectorId;
                        d.director = d.Director.director;
                        repository.SaveChanges();
                    }

                }

                d.rating = dvd.rating;
                if (d.rating != null)
                {

                    if (repository.Ratings.Count(x => x.rating == d.rating) == 0)
                    {
                        //add director information to the database
                        d.Rating.RatingId = repository.Ratings.Count() + 1;
                        d.RatingId = d.Rating.RatingId;
                        d.Rating.rating = dvd.rating;
                        d.rating = d.Rating.rating;
                        repository.SaveChanges();
                    }

                    else
                    {
                        //set director to existing instance of director
                        d.Rating = repository.Ratings.First(x => x.rating == d.rating);
                        d.Rating.RatingId = repository.Ratings.First(x => x.rating == d.rating).RatingId;
                        d.RatingId = d.Rating.RatingId;
                        d.rating = d.Rating.rating;
                        repository.SaveChanges();
                    }

                }
                d.releaseYear = dvd.releaseYear;

                if (d.releaseYear != null)
                {

                    if (repository.ReleaseYears.Count(x => x.releaseYear == d.releaseYear) == 0)
                    {
                        //add director information to the database
                        //d.ReleaseYear.ReleaseYearId = repository.ReleaseYears.Count() + 1;
                        d.ReleaseYearId = d.ReleaseYear.ReleaseYearId;
                        d.ReleaseYear.releaseYear = (int)d.releaseYear;
                        d.releaseYear = d.ReleaseYear.releaseYear;
                        repository.SaveChanges();
                    }

                    else
                    {
                        //set director to existing instance of director
                        d.ReleaseYear = repository.ReleaseYears.First(x => x.releaseYear == d.releaseYear);
                        d.ReleaseYear.ReleaseYearId = repository.ReleaseYears.First(x => x.releaseYear == d.releaseYear).ReleaseYearId;
                        d.ReleaseYearId = d.ReleaseYear.ReleaseYearId;
                        d.releaseYear = d.ReleaseYear.releaseYear;
                        repository.SaveChanges();

                    }

                    d.Notes = dvd.Notes;

                }
                //repository.Entry(d).State = System.Data.Entity.EntityState.Modified;
                repository.SaveChanges();
            }

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
            var repository = new DvdLibraryEntities();
            List<Dvd> allDvds = (from d in repository.Dvds
                                 where d.director.Contains(director)
                                 select d).ToList();

            foreach (Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

            return allDvds;
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
                                 where d.rating.Contains(rating)
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
                                 where d.Title.Contains(title)
                                 select d).ToList();

            foreach (Dvd x in allDvds)
            {
                x.releaseYear = x.ReleaseYear.releaseYear;
                x.director = x.Director.director;
                x.rating = x.Rating.rating;
            };

            return allDvds;
        }

        //delete later
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