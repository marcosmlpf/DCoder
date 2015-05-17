using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace DataServices
{
    [ServiceContract]
    public interface IPredictionDataService
    {
        [OperationContract]
        IEnumerable<Post> GetAllPosts();

        [OperationContract]
        IEnumerable<Post> GetPostByStatus(string status);

        [OperationContract]
        void UpdatePost(Post post);

        [OperationContract]
        void AddPost(Post post);

        [OperationContract]
        void AddExternalContent(ExternalEvaluation post);

        [OperationContract]
        IEnumerable<ExternalEvaluation> GetExternalContent(string source);

        [OperationContract]
        void AddTouchPoint(TouchPoint touchPoint);

        [OperationContract]
        void AddPerson(Person person);

        [OperationContract]
        string GetCategoryByLabel(string label);
    }
}
