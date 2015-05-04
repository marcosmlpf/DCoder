﻿using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlParser.ServiceReference1;


namespace HtmlParser
{
    public partial class Form1 : Form
    {
        string fileName = @"D:\WorkingDir\Projetos\DCoder\";
        List<Evaluation> evalList = new List<Evaluation>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        #region Love Mondays

        private void btnGetHtmlLoveMondays_Click(object sender, EventArgs e)
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

        private void btnParseLoveMondays_Click(object sender, EventArgs e)
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

            this.SaveToDatabase("LOVE_MONDAYS");
        }

        private void GetEvaluation(HtmlAgilityPack.HtmlDocument document)
        {
            List<HtmlNode> evaluationList = document.DocumentNode.Descendants().Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("company-review"))).ToList();

            foreach (var evaluation in evaluationList)
            {
                foreach (var content in evaluation.ChildNodes)
                {
                    Console.WriteLine(content.InnerText);
                    var eval = this.ParseEvaluation(content.InnerText);

                    if (eval.Pros!=null) 
                        evalList.Add(eval);
                }
            }

        }

        private void Print()
        {
            string[] lines = new string[evalList.Count];
            string line;
            string path = @"D:\WorkingDir\Projetos\DCoder\Jsons\loveMondaysParsed.txt";

            using (StreamWriter sw = File.AppendText(path))
            {
                foreach (var item in evalList)
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

        private void SaveToDatabase(string source)
        {
            ServiceReference1.ExternalEvaluation eval = new ExternalEvaluation();

            foreach (var item in evalList)
            {
                eval.Pos = item.Pros;
                eval.Cons = item.Cons;
                eval.AdiceToPresident = item.AdviseToPresident;
                eval.Recommend = item.Recomend;
                eval.Source = source;

                ServiceReference1.PredictionDataServiceClient svc = new PredictionDataServiceClient();

                svc.AddExternalContent(eval);
            }
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

        #endregion

        #region Glass Door

        private void btnParseGlassDoor_Click(object sender, EventArgs e)
        {
            var getHtmlWeb = new HtmlWeb();
            int TotalPages = 15;

            var document = getHtmlWeb.Load("http://www.glassdoor.com/Reviews/CI-and-T-Reviews-E140265.htm");

            this.GetEvaluationGlassDoor(document);

            for (int i = 1; i <= TotalPages; i++)
            {
                document = getHtmlWeb.Load("http://www.glassdoor.com/Reviews/CI-and-T-Reviews-E140265_P" + i.ToString() + ".htm");

                this.GetEvaluation(document);
            }

            //this.Print();

            this.SaveToDatabase("GLASS_DOOR");
        }

        private void GetEvaluationGlassDoor(HtmlAgilityPack.HtmlDocument document)
        {
            List<HtmlNode> evaluationList = document.DocumentNode.ChildNodes.Where(x => (x.Name == "div" && x.Attributes["class"] != null && x.Attributes["class"].Value.Contains("prosConsAdvice"))).ToList();

            foreach (var evaluation in evaluationList)
            {
                foreach (var content in evaluation.ChildNodes)
                {
                    Console.WriteLine(content.InnerText);
                    var eval = this.ParseEvaluationGlassDoor(content.InnerText);

                    if (eval.Pros != null)
                        evalList.Add(eval);
                }
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

            string[] tokens = new string[] { "Pros", "Cons", "Advice to Management" };
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
                                case "Pros":
                                    eval.Pros = line.Replace(t, "").Trim();
                                    break;
                                case "Cons:":
                                    eval.Cons = line.Replace(t, "").Trim();
                                    break;
                                case "Advice to Management":
                                    eval.AdviseToPresident = line.Replace(t, "").Trim();
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

        #endregion
      
    }
}