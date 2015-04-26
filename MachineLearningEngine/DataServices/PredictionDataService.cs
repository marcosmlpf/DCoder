using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using DataServices.Repository;
using DataServices.Infrastructure;

namespace DataServices
{
    public class PredictionDataService : IPredictionDataService
    {
        private IDatabaseFactory databaseFactory = new Infrastructure.DatabaseFactory();
        private IUnitOfWork unitofWork;

        private PostRepository postRepostitory;

        public IEnumerable<Post> GetAll()
        {
            postRepostitory = new PostRepository(databaseFactory);

            return this.postRepostitory.GetAll();
        }

        public void Update(Post post)
        {
            postRepostitory = new PostRepository(databaseFactory);
            unitofWork = new UnitOfWork(databaseFactory);

            postRepostitory.Update(post);

            unitofWork.Commit();

        }

        public IEnumerable<Post> GetByStatus(string status)
        {
            postRepostitory = new PostRepository(databaseFactory);

            return this.postRepostitory.GetByStatus(status);
        }
    }
}
