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
        private ExternalEvaluationRepository externalEvaluationRepository;
        private TouchPointRepository touchPointRepository;
        private PersonRepository personRepository;
        private CategoryRepository categoryRepository;

        public IEnumerable<Post> GetAllPosts()
        {
            postRepostitory = new PostRepository(databaseFactory);

            return this.postRepostitory.GetAll();
        }

        public void UpdatePost(Post post)
        {
            postRepostitory = new PostRepository(databaseFactory);
            unitofWork = new UnitOfWork(databaseFactory);

            postRepostitory.Update(post);

            unitofWork.Commit();

        }

        public IEnumerable<Post> GetPostByStatus(string status)
        {
            postRepostitory = new PostRepository(databaseFactory);

            return this.postRepostitory.GetByStatus(status);
        }

        public void AddPost(Post post)
        {
            postRepostitory = new PostRepository(databaseFactory);
            unitofWork = new UnitOfWork(databaseFactory);

            postRepostitory.Add(post);

            unitofWork.Commit();

        }

        public void AddExternalContent(ExternalEvaluation evaluation)
        {
            externalEvaluationRepository = new ExternalEvaluationRepository(databaseFactory);

            unitofWork = new UnitOfWork(databaseFactory);

            externalEvaluationRepository.Add(evaluation);

            unitofWork.Commit();
        }

        public void AddTouchPoint(TouchPoint touchPoint)
        {
            touchPointRepository = new TouchPointRepository(databaseFactory);

            unitofWork = new UnitOfWork(databaseFactory);

            touchPointRepository.Add(touchPoint);

            unitofWork.Commit();

        }

        public void AddPerson(Person person)
        {
            personRepository = new PersonRepository(databaseFactory);

            unitofWork = new UnitOfWork(databaseFactory);

            personRepository.Add(person);

            unitofWork.Commit();

        }

        public string GetCategoryByLabel(string label)
        {
            categoryRepository = new CategoryRepository(databaseFactory);

            return categoryRepository.GetCategoryByLabel(label);
        }
    }
}
