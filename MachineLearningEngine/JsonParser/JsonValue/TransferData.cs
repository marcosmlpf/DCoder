using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JsonValue.ServiceReference1;

namespace JsonValue
{
    [TestClass]
    class TransferData
    {
        [TestMethod]
        public void LoadCards()
        {

            PredictionDataServiceClient svc = new PredictionDataServiceClient();

            var postList = svc.GetAllPosts();

            foreach (var p in postList)
            {
                
            }


        }

        

    }
}
