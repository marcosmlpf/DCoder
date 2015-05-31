using BaseExternalConnector.Model;
using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlassDoorConnector
{
    public class GlassDoorConn : BaseExternalConnector.BaseConnector
    {
        public GlassDoorConn()
        {
            base.EvalList = new List<Evaluation>();
            base.RatingList = new List<Rating>();
        }

        public void ParseGlassDoor()
        {
            this.GetLocalHtmls();
            //this.GetOnLineFiles();

            base.SaveToDatabase("GLASS_DOOR");
        }

        public void GetOnLineFiles()
        {
            string fileName = @"D:\WorkingDir\Projetos\DCoder\GlassDoor\";

            var getHtmlWeb = new HtmlWeb();

            int TotalPages = 5;

            var document = getHtmlWeb.Load("http://www.glassdoor.com/Reviews/CI-and-T-Reviews-E140265.htm");

            document.Save(fileName + "1.html");

            this.GetEvaluationGlassDoor(document);

            for (int i = 3; i <= TotalPages; i++)
            {
                document = getHtmlWeb.Load("http://www.glassdoor.com/Reviews/CI-and-T-Reviews-E140265_P" + i.ToString() + ".htm");

                document.Save(fileName + i.ToString() + ".html");

                this.GetEvaluationGlassDoor(document);
            }
        }

        private void GetEvaluationGlassDoor(HtmlAgilityPack.HtmlDocument document)
        {
            List<HtmlNode> evaluationList = document.DocumentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("tbl fill prosConsAdvice truncateData padTop"))).ToList();

            foreach (var evaluation in evaluationList)
            {
                //foreach (var content in evaluation.ChildNodes)
                //{
                Console.WriteLine(evaluation.InnerText);
                var eval = this.ParseEvaluationGlassDoor(evaluation.InnerText);

                if (eval.Pros != null)
                    base.EvalList.Add(eval);
                //}
            }

        }

        //private void Print()
        //{
        //    string[] lines = new string[evalList.Count];
        //    string line;
        //    string path = @"D:\WorkingDir\Projetos\DCoder\Jsons\loveMondaysParsed.txt";

        //    using (StreamWriter sw = File.AppendText(path))
        //    {
        //        foreach (var item in evalList)
        //        {
        //            line = string.Format("Pros: {0}", item.Pros);

        //            sw.WriteLine(line);

        //            line = string.Format("Contras: {0}", item.Cons);

        //            sw.WriteLine(line);

        //            line = string.Format("Conselho para a previdência: {0}", item.AdviseToPresident);

        //            sw.WriteLine(line);

        //            line = string.Format("Recomenda a empresa: {0}", item.Recomend);

        //            sw.WriteLine(line);

        //            sw.WriteLine("===========================================================================================");
        //        }
        //    }





        //}

        private Evaluation ParseEvaluationGlassDoor(string content)
        {

            string[] tokens = new string[] { "Pros ", "Cons ", "Advice to Management " };
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
                            Console.WriteLine(String.Format("{0} - {1}", t, line));

                            switch (t)
                            {
                                case "Pros ":
                                    eval.Pros = line.Substring(line.IndexOf(t), line.IndexOf("Cons") - line.IndexOf(t)).Trim();
                                    eval.Pros = eval.Pros.Replace(t, "").Trim();
                                    break;
                                case "Cons ":
                                    if (line.IndexOf("Advice to Management") > 0)
                                        eval.Cons = line.Substring(line.IndexOf(t), line.IndexOf("Advice to Management") - line.IndexOf(t)).Trim();
                                    else
                                        eval.Cons = line.Substring(line.IndexOf(t), line.Length - line.IndexOf(t)).Trim();

                                    eval.Cons = eval.Cons.Replace(t, "").Trim();
                                    break;
                                case "Advice to Management ":
                                    eval.AdviseToPresident = line.Substring(line.IndexOf(t), line.Length - line.IndexOf(t)).Trim();
                                    eval.AdviseToPresident = eval.AdviseToPresident.Replace(t, "").Trim();
                                    break;
                                    //case "Recomenda a empresa:":
                                    //    eval.Recomend = line.Replace(t, "").Trim();
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

        public void GetLocalHtmls()
        {
            string path = @"D:\WorkingDir\Projetos\DCoder\GlassDoor\";

            HtmlAgilityPack.HtmlDocument html = new HtmlAgilityPack.HtmlDocument();

            System.IO.DirectoryInfo dir = new DirectoryInfo(path);

            foreach (var file in dir.GetFiles())
            {
                html.Load(file.FullName);

                this.GetEvaluationGlassDoor(html);
            }
        }

    }
}
