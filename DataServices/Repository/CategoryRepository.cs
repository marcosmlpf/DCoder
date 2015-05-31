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
    public class CategoryRepository : Infrastructure.RepositoryBase<Category>, ICategoryRepository
    {

        public CategoryRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        public string GetCategoryByLabel(string label) 
        {
            return base.DataContext.PredictionLabel.Where(l=>l.Label== label).SingleOrDefault().Category.Name;

        }

        
    }
}