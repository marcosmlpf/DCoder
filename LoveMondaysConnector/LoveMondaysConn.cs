using BaseExternalConnector.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoveMondaysConnector
{
    public class LoveMondaysConn : BaseExternalConnector.BaseConnector
    {
        string fileName = @"D:\WorkingDir\Projetos\DCoder\";

        public LoveMondaysConn()
        {
            base.EvalList = new List<Evaluation>();
            base.RatingList = new List<Rating>();

        }

        public void GetHtmlLoveMondays()
        {
            

            var getHtmlWeb = new HtmlWeb();
            int TotalPages = 15;

            var document = getHtmlWeb.Load("https://www.lovemondays.com.br/trabalhar-na-ci-and-t");

            document.Save(fileName + "1.html");


            //string[] str = new string[TotalPages];


            for (int i = 1; i < TotalPages; i++)
            {
                document = getHtmlWeb.Load("https://www.lovemondays.com.br/trabalhar-na-ci-and-t?page=" + i.ToString());

                document.Save(fileName + i.ToString() + ".html");
            }

            //System.IO.File.WriteAllLines(@"D:\WorkingDir\Projetos\DCoder\Jsons\loveMondays.txt", str.ToArray<string>());

        }

        public void ParseOnLineLoveMondays()
        {
           
            var getHtmlWeb = new HtmlWeb();
            int TotalPages = 15;

            var document = getHtmlWeb.Load("https://www.lovemondays.com.br/trabalhar-na-ci-and-t");

         

            this.GetEvaluation(document);

            for (int i = 1; i < TotalPages; i++)
            {
                document = getHtmlWeb.Load("https://www.lovemondays.com.br/trabalhar-na-ci-and-t?page=" + i.ToString());

                this.GetEvaluation(document);
            }

            //this.Print();

            base.SaveToDatabase("LOVE_MONDAYS");
        }

        private void GetEvaluation(HtmlAgilityPack.HtmlDocument document)
        {

            // Get evaluations
            List<HtmlNode> evaluationList = document.DocumentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("company-review"))).ToList();

            foreach (var evaluation in evaluationList)
            {
                foreach (var content in evaluation.ChildNodes)
                {
                    Console.WriteLine(content.InnerText);
                    var eval = this.ParseEvaluation(content.InnerText);

                    if (eval.Pros!=null) 
                         base.EvalList.Add(eval);
                }
            }


            // Get ratings
            List<HtmlNode> rateList = document.DocumentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("static-rating-wrapper"))).ToList();

            foreach (var rate in rateList)
            {
            //    //foreach (var content in rate.ChildNodes)
            //    //{
                var r = new Rating();

                //r.CompBenefits = rate.ChildNodes[3].InnerText;
                //r.CompBenefits = rateList.ChildNodes[4].InnerText;
                //r.CompBenefits = rateList.ChildNodes[5].InnerText;
                //r.CompBenefits = rateList.ChildNodes[6].InnerText;

                //if (r.CompBenefits != null)
                //    ratingList.Add(r);
                //}
            }

        }

        private void Print()
        {
            string[] lines = new string[base.EvalList.Count];
            string line;
            string path = @"D:\WorkingDir\Projetos\DCoder\Jsons\loveMondaysParsed.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var item in base.EvalList)
                {
                    line = string.Format("Pros: {0}", item.Pros);

                    sw.WriteLine(line);

                    line = string.Format("Contras: {0}", item.Cons);

                    sw.WriteLine(line);

                    line = string.Format("Conselho para a previdência: {0}", item.AdviseToPresident);

                    sw.WriteLine(line);

                    line = string.Format("Recomenda a empresa: {0}", item.Recomend);

                    sw.WriteLine(line);

                    sw.WriteLine("===========================================================================================");
                }
            }	

            
            

            
        }

        private Rating ParseRating(List<HtmlAgilityPack.HtmlNode> rateList)
        {
            for (int i = 0; i < 3; i++)
            {
                var r = new Rating();

                var rate = rateList[i];

                r.CompBenefits = int.Parse(rate.ChildNodes[3].InnerText);
            }


            return new Rating();

        }

        private Evaluation ParseEvaluation(string content)
        {

            string[] tokens = new string[] { "Prós:", "Contras:", "Conselhos para presidência:", "Recomenda a empresa:" };
            Evaluation eval = new Evaluation();

            if (content != null)
            {
                string[] lines = content.Split('\n');

                foreach (var line in lines)
                {
                    foreach (var t in tokens)
                    {
                        if (line.IndexOf(t) > 0)
                        {
                            Console.WriteLine(String.Format("{0} - {1}" , t, line));

                            switch (t)
                            {
                                case "Prós:":
                                    eval.Pros = line.Replace(t,"").Trim();
                                    break;
                                case "Contras:":
                                    eval.Cons = line.Replace(t, "").Trim();
                                    break;
                                case "Conselhos para presidência:":
                                    eval.AdviseToPresident = line.Replace(t, "").Trim();
                                    break;
                                case "Recomenda a empresa:":
                                    eval.Recomend = line.Replace(t, "").Trim();
                                    break;
                                default:
                                    break;
                            }

                        }
                    }
                }
            }

            return eval;
        }

    }
}
