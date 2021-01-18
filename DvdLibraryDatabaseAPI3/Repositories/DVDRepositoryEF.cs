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
            //Dvd d = new Dvd();

            //d.DvdId = dvd.DvdId;
            //d.Title = dvd.Title;
            //d.director = dvd.director;
            ////d.DirectorId = dvd.DirectorId;
            //d.rating = dvd.rating;
            ////d.RatingId = dvd.RatingId;
            ////d.ReleaseYear1 = dvd.ReleaseYear1;
            //d.ReleaseYearId = dvd.ReleaseYearId;
            //d.Notes = dvd.Notes;

            repository.Dvds.Add(dvd);
            repository.SaveChanges();
        }

        public void Delete(int dvdID)
        {
            throw new NotImplementedException();
        }

        public void Edit(Dvd dvd)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<Dvd> GetByRating(string rating)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByReleaseYear(int releaseYear)
        {
            throw new NotImplementedException();
        }

        public List<Dvd> GetByTitle(string title)
        {
            throw new NotImplementedException();
        }

    }
}