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
        IEnumerable<Post> GetAll();

        [OperationContract]
        IEnumerable<Post> GetByStatus(string status);

        [OperationContract]
        void Update(Post post);
    }
}
