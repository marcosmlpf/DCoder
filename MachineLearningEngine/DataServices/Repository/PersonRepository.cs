using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using DataServices;
using DataServices.Infrastructure;

namespace DataServices.Repository
{
    public class PersonRepository : Infrastructure.RepositoryBase<Person>, IPersonRepository
    {

        public PersonRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

      
        
    }
}