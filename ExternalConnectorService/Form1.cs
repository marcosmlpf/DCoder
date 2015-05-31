using HtmlAgilityPack;
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
using GlassDoorConnector;
using LoveMondaysConnector;

namespace HtmlParser
{
    public partial class Form1 : Form
    {
        string fileName = @"D:\WorkingDir\Projetos\DCoder\";
        
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

        }

        private void btnGetHtmlLoveMondays_Click(object sender, EventArgs e)
        {
            LoveMondaysConnector.LoveMondaysConn love = new LoveMondaysConnector.LoveMondaysConn();

            love.GetHtmlLoveMondays();

        }

        private void btnParseLoveMondays_Click(object sender, EventArgs e)
        {
            LoveMondaysConnector.LoveMondaysConn love = new LoveMondaysConnector.LoveMondaysConn();

            love.ParseOnLineLoveMondays();
        }

        private void btnParseGlassDoor_Click(object sender, EventArgs e)
        {
            GlassDoorConn glass = new GlassDoorConnector.GlassDoorConn();

            //glass.GetLocalHtmls();
            glass.GetOnLineFiles();
            glass.ParseGlassDoor();

        }
                      
    }
}
