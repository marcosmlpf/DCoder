using BaseExternalConnector.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseExternalConnector
{
    public class BaseConnector
    {
        public List<Evaluation> EvalList { get; set; }
        public List<Rating> RatingList { get; set; }

        public void SaveToDatabase(string source)
        {
            ServiceReference1.ExternalEvaluation eval = new ServiceReference1.ExternalEvaluation();
            int p = 0;

            foreach (var item in EvalList)
            {
                eval.Pos = item.Pros;
                eval.Cons = item.Cons;
                eval.AdiceToPresident = item.AdviseToPresident;
                eval.Recommend = item.Recomend;
                eval.Source = source;

                eval.Comp_Benefits = GetRate(p).CompBenefits;
                eval.Culture_Values = GetRate(p).CultureValues;
                eval.Senior_Management = GetRate(p).SeniorManagement;
                eval.Work_Life_Balance = GetRate(p).WorkLifeBalance;

                ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

                svc.AddExternalContent(eval);

                p++;
            }
        }

        private Rating GetRate(int pos)
        {
            return RatingList[pos];
        }
    }
}
