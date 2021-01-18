using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using DvdLibraryDatabaseAPI3.Repositories;

namespace DvdLibraryDatabaseAPI3.Models
{
    public class RepositoryFactory
    {
        public static IDvdRepository Create()
        {
            string mode = ConfigurationManager.AppSettings["Mode"].ToString();

            switch (mode)
            {
                case "SampleData":
                    return new DVDRepositoryMock();

                case "EntityFramework":
                    return new DVDRepositoryEF();

                case "ADO":
                    return new DVDRepositoryADO();

                default:
                    throw new Exception("Mode in web config is not valid");

            }

        }
    }
}