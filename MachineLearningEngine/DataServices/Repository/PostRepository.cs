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
    public class PostRepository : Infrastructure.RepositoryBase<Post>, IPostRepository
    {

        public PostRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public IEnumerable<Post> GetByStatus(string status) 
        {

            return base.GetAll().Where(s => s.Status == status || s.Status == null);
        }

        
    }
}