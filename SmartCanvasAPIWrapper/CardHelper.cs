using Newtonsoft.Json;
using SmartCanvasAPIWrapper.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SmartCanvasAPIWrapper
{
    public class CardHelper
    {
         //# Client ID: must be in the header to ensure security
        const string client_id = "1";

        //# API Key: must be in the header to ensure security
        const string api_key = "cf812f3722f0ff885501330df71396e2d08baacb87cc7c8a6f311b1ddd928915";

        //# Base URI: we are going to use Smart Canvas production URI here
        //const string base_uri = "http://d-coder.smartcanvas.com";
        const string base_uri = "https://d1-prd.appspot.com/brain/d-coder";

        //# Google API Key: used to access some google APIs such as Google+
        const string google_api_key = "AIzaSyDZIKKCZiHmIyki0yyPWnEUrkgFzw09zUs";

        //# Max results coming from Google+
        const int max_results = 20;

        #region public methods

        public Card CreateCardInstance(long id, String title, String summary, String content)
        {
            Card card = new Card();

            //{"authorId":5639445604728832,
            //"categoryNames": ["vaiCoders-dcoder"],
            //"languages":["en"],
            //"regions":["us"],
            //"autoModerated":true,
            //"featured":true,
            //"mnemonic":"vaiCoders-dcoder",
            //"authorDisplayName":"Felipe",
            //"authorImageURL":"https://lh3.googleusercontent.com/-1t2-wVx4zOc/AAAAAAAAAAI/AAAAAAAAAF0/qOlneWgGBNk/s120-c/photo.jpg?sz=50",
            //"providerUserId":"5639445604728832",
            //"hashtagList":["freeroom","thegarage"],
            //"title":"My title 2",
            //"description":"","content":"orem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum:<br><table border='1'><tr><td>Jill</td><td>Smith</td> <td>50</td></tr> <tr><td>Eve</td> <td>Jackson</td> <td>94</td></tr></table>",
            //"providerContentId":"room-formiga-atomica","providerId":"garage-sensor"}

            //Basic info
            //card.id = id;

            card.id = id;
            card.authorDisplayName = "Felipe";
            //card.authorEmail = "emersonrs@ciandt.com";
            card.authorId = 5639445604728832;
            card.authorImageURL = "https://lh3.googleusercontent.com/-1t2-wVx4zOc/AAAAAAAAAAI/AAAAAAAAAF0/qOlneWgGBNk/s120-c/photo.jpg?sz=50";
            //card.setAutoModerated(true);
            card.autoModerated = true;
            //card.createdAt = new DateTime();
            card.featured = false;
            card.mnemonic = "vaiCoders-dcoder";
            //card.providerId = "0202198219988251445";
            //card.updated = null;
            //card.expirationDate = null;
            //card.publishingDate = null;
            //card.securityLevel = 0;
            card.hashtagList.Add("dash-dcoder");

            card.categoryNames.Add("tempo-vaiCoders-dcoder");

            //card.addCategory("teste");
            //card.addCategory("d-coder");

            //i18n
            card.languages.Add("en");
            card.regions.Add("US");

            //Content info
            card.title = title;
            //card.description = summary;
            card.content = content;
            card.providerContentId = id.ToString();
            //card.providerContentURL= "http://xxxx.com";
            card.providerId = "981395851";
            //card.providerUpdated = new DateTime();
            //card.providerPublished = new DateTime();
            card.providerUserId = "5639445604728832";

            //Community
            //card.setCommunity("Community Test");
            //card.setCommunityDisplayName("Community Display Name Test");

            //Attachment attachment = new Attachment();
            //attachment.imageType = "mimetype";
            //attachment.imageHeight = 200;
            //attachment.fullImageWidth = 300;
            //attachment.imageURL = "originalurl";


            //card.attachments.Add(attachment);

            return card;
        }

        public List<Card> GetCards(String query)
        {
            //https://d1-prd.appspot.com/brain/ciandt-i/card/v3/cards?locale=pt-BR&q=

            //String parameters = "?locale=pt-BR" + "&q=" + Uri.encode(query.toLowerCase(new Locale("pt", "BR")));
            //String url = APIConstants.URL_D1_PROD_BRAIN + APIConstants.PATH_D1_PROD_INTRANET_CARDS + parameters;

            //String url = "https://d1-prd.appspot.com/brain/" + APIConstants.GetTenantID() + "/card/v3/cards?locale=pt-BR&q=" + "&q=" + Uri.encode(query.toLowerCase(new Locale("pt", "BR")));

            String url = base_uri + "/card/v3/cards?locale=pt-BR&q=" + "&q=" + query;

            //String json = WebClient.HttpRequest(url, CreateHeadersArray(), "GET");

            string json = this.GetBase(url);

            //JsonTextReader reader = new JsonTextReader(new StringReader(json));

            //var ret =   JsonConvert.P.Parse(unfilteredJSONData).ToObject<Response>();

            //JArray token = JArray.Parse(json);

            //JArray jsonArray = JArray.Parse(json);

            //foreach (var item in jsonArray.Children<JObject>())
            //{
            //    Card card = new Card();
            //    //List<BlocksInformations> blocks = new List<BlocksInformations>();

            //    if (item["id"] != null)
            //        card.id = item["id"].Value<long>();


            //}

            //JToken token = JObject.Load(reader);

            //var results = JsonConvert.DeserializeObject(json, typeof(List<Card>));

            //return json;

            return CardModel.getCardsFromJSON(json);
        }

        public void CreateCard(Card card)
        {
            this.Post(this.SerializeObject(card));
        }

        #endregion

        #region private helper methods

        private string SerializeObject(Card card)
        {
            return JsonConvert.SerializeObject(card, Formatting.Indented);
        }

        private void Get()
        {
            // Create the web request  
            HttpWebRequest request = WebRequest.Create("https://developer.yahoo.com/") as HttpWebRequest;

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }


        }

        private string GetBase(string requestUri)
        {
            // Create the web request  
            //HttpWebRequest request = WebRequest.Create("https://developer.yahoo.com/") as HttpWebRequest;

            HttpWebRequest request = WebRequest.Create(requestUri) as HttpWebRequest;

            request.Method = "GET";
            request.ContentType = "text/json";
            request.Accept = "application/json";


            request.Headers.Add("CLIENT_ID", client_id);
            request.Headers.Add("API_KEY", api_key);


            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                //Console.WriteLine(reader.ReadToEnd());

                string line;

                //while ((line = reader.ReadLine()) != null)
                //{
                //    var result = JsonConvert.DeserializeObject(line);
                //}

                return reader.ReadToEnd();
            }

        }

        private void Post(string data)
        {
            string apiSpecificPath = "/card/v2/cards";

            Uri address = new Uri(base_uri + apiSpecificPath);

            // Create the web request  
            HttpWebRequest request = WebRequest.Create(address) as HttpWebRequest;

            // Set type to POST  
            request.Method = "PUT";
            request.ContentType = "text/json";
            request.Accept = "application/json";

            //CLIENT_ID: 1
            //API_KEY: cf812f3722f0ff885501330df71396e2d08baacb87cc7c8a6f311b1ddd928915
            //Type: application/json,application/xhtml+xml

            request.Headers.Add("CLIENT_ID", client_id);
            request.Headers.Add("API_KEY", api_key);

            using (var streamWriter = new StreamWriter(request.GetRequestStream()))
            {
                streamWriter.Write(data);
                streamWriter.Flush();
                streamWriter.Close();
            }

            // Get response  
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                // Get the response stream  
                StreamReader reader = new StreamReader(response.GetResponseStream());

                // Console application output  
                Console.WriteLine(reader.ReadToEnd());
            }
        }

        #endregion

    }
}
