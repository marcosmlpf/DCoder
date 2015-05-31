using SmartCanvasAPIWrapper.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace CallDCoder
{
    public partial class Form1 : Form
    {
        private void btnCallAPI_Click(object sender, EventArgs e)
        {

            var cards = new List<Card>();
            SmartCanvasAPIWrapper.CardHelper helper = new SmartCanvasAPIWrapper.CardHelper();

            try
            {

                #region CreateCard

                var card1 = helper.CreateCardInstance(10, "This is the title 1", "This is the summary", "This is the <b>content</b>");
                var card2 = helper.CreateCardInstance(20, "This is the title 2", "This is the summary", "This is the <b>content</b>");
                var card3 = helper.CreateCardInstance(30, "This is the title 3", "This is the summary", "This is the <b>content</b>");
                var card4 = helper.CreateCardInstance(40, "This is the title 4", "This is the summary", "This is the <b>content</b>");

                helper.CreateCard(card1);
                helper.CreateCard(card2);
                helper.CreateCard(card3);

                string tempo = @"html content...";

                var cardTempo = helper.CreateCardInstance(450, "This is the tempo test", "This is the summary", tempo);

                helper.CreateCard(cardTempo);

                #endregion

                #region GetCards

                cards = helper.GetCards("vaicoders");

                #endregion
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

