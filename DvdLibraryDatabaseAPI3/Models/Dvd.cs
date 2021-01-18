using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DvdLibraryDatabaseAPI3.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }
        public int? DirectorId { get; set; }
        public int? RatingId { get; set; }

        public int? ReleaseYearId { get; set; }

        public string Title { get; set; }
        public string Notes { get; set; }

        //releaseYear, director, and rating are used in ADORepository to set these fields in the POST and PUT requests
        public int? releaseYear { get; set; }

        public string director { get; set; }

        public string rating { get; set; }

        public virtual Rating Rating { get; set; }
        public virtual ReleaseYear ReleaseYear { get; set; }
        public virtual Director Director { get; set; }
    }
}