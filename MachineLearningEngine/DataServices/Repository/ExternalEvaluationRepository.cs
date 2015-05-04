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
    public class ExternalEvaluationRepository : Infrastructure.RepositoryBase<ExternalEvaluation>, IExternalEvaluationRepository
    {

        public ExternalEvaluationRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }
    }
}