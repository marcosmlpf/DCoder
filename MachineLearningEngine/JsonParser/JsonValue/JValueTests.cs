using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using JsonValue.ServiceReference1;

namespace JsonValueTests
{
    [TestClass]
    public class JValueTests
    {
        [TestMethod]
        public void JsonCardParser()
        {

            //string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-2.json";   -- processado
            //string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-0.json";   -- processado
            //string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-1.json";     -- processado
            //string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-3.json"; -- processado
            string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-5.json"; 
            

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            List<string> lines = new List<string>();

            int counter = 0;
            string line;
            System.Text.StringBuilder sb = new StringBuilder();
            string id = string.Empty;
            string providerUserId = string.Empty;
            string personTitle = string.Empty;
            string currentProperty = string.Empty;

            while ((line = file.ReadLine()) != null)
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(line)))
                {
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            if (reader.Value.ToString().Length > 50 && !reader.Value.ToString().StartsWith("https"))
                            {
                                string token = @"{""access""";

                                if (reader.Value.ToString().StartsWith(token))
                                {
                                    using (JsonTextReader reader2 = new JsonTextReader(new StringReader(reader.Value.ToString())))
                                    {
                                        while (reader2.Read())
                                        {
                                            if (reader2.Value != null)
                                            {
                                                if (reader2.Value.ToString().Length > 50 && !reader2.Value.ToString().StartsWith("https"))
                                                {
                                                    sb.Append(RemoveHtmlTags(reader2.Value.ToString()));
                                                    //lines.Add(RemoveHtmlTags(reader2.Value.ToString()));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                    sb.Append(RemoveHtmlTags(reader.Value.ToString()));
                                    //lines.Add(RemoveHtmlTags(reader.Value.ToString()));
                                }
                            else
                            {
                                switch (reader.Value.ToString())
                                {
                                    case "personTitle":
                                        currentProperty = "personTitle";
                                        continue;
                                    case "id":
                                        currentProperty = "id";
                                        continue;
                                    case "providerUserId":
                                        currentProperty = "providerUserId";
                                        continue;
                                    default:
                                        break;
                                }

                                switch (currentProperty)
                                {
                                    case "personTitle":
                                        personTitle = reader.Value.ToString();
                                        currentProperty = string.Empty;
                                        break;
                                    case "id":
                                        id = reader.Value.ToString();
                                        currentProperty = string.Empty;
                                        break;
                                    case "providerUserId":
                                        providerUserId = reader.Value.ToString();
                                        currentProperty = string.Empty;
                                        break;
                                    default:
                                        break;
                                }
                                    
                            }

                        }

                    }
                }

                if (sb.Length > 0)
                {
                    Post p = new Post();
                    p.Description = sb.ToString();
                    p.ProviderUserId = providerUserId;
                    p.PersonTitle = personTitle;
                    p.CardId = id;

                    this.SaveCard(p);

                    sb.Clear();

                    id = string.Empty;
                    providerUserId = string.Empty;
                    personTitle = string.Empty;
                    currentProperty = string.Empty;

                }

                //System.IO.File.WriteAllLines(@"D:\WorkingDir\Projetos\DCoder\Jsons\cards_values_output11.txt", lines.ToArray<string>());

                counter++;
                Console.WriteLine(counter.ToString());
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();
            
        }

        [TestMethod]
        public void JObjectOutputTest()
        {
            // strong type instance 
            var jsonObject = new JObject();

            // you can explicitly add values here
            jsonObject.Add("Entered", DateTime.Now);

            // dynamic expando instance you can add properties to
            dynamic album = jsonObject;

            album.AlbumName = "Dirty Deeds Done Dirt Cheap";
            album.Artist = "AC/DC";
            album.YearReleased = 1976;

            album.Songs = new JArray() as dynamic;

            dynamic song = new JObject();
            song.SongName = "Dirty Deeds Done Dirt Cheap";
            song.SongLength = "4:11";
            album.Songs.Add(song);

            song = new JObject();
            song.SongName = "Love at First Feel";
            song.SongLength = "3:10";
            album.Songs.Add(song);

            Console.WriteLine(album.ToString());
        }

        [TestMethod]
        public void JsonValueParsingTest()
        {
            var jsonString = @"{""Name"":""Rick"",""Company"":""West Wind"",""Entered"":""2012-03-16T00:03:33.245-10:00""}";

            dynamic json = JValue.Parse(jsonString);
            //dynamic json = jsonVal;

            // values require casting
            string name = json.Name;
            string company = json.Company;
            DateTime entered = json.Entered;

            Assert.AreEqual(name, "Rick");
            Assert.AreEqual(company, "West Wind");
        }

        [TestMethod]
        public void JsonValueParsingTest2()
        {
            //var jsonString = @"{""Name"":""Rick"",""Company"":""West Wind"",""Entered"":""2012-03-16T00:03:33.245-10:00""}";


            var jsonString = @"{
	""deletetionDate"": 1429690020222,
	""updated"": 1429690020222,
	""userContentActivities"": {},
	""categories"": [],
	""categoryNames"": [],
	""providerPublished"": 1429603644675,
	""languages"": [""pt"", ""en"", ""zz""],
	""detectedLanguage"": ""zz"",
	""regions"": [""br"", ""us"", ""zz""],
	""personBlock"": {
		""personName"": ""RAFAEL DE CASTRO SANTOS ALENCAR"",
		""personTitle"": ""Developer"",
		""personImageURL"": ""https://lh4.googleusercontent.com/-YdGXoFGuluk/AAAAAAAAAAI/AAAAAAAAAK8/k_6rr2LuZzw/photo.jpg?sz=50""
	},
	""contactBlock"": {
		""phones"": [""+55 (19) 2102-9393"", ""+55 (11) 991445579""],
		""emails"": [""ralencar@ciandt.com""],
		""location"": ""Campinas""
	},
	""managerBlock"": {
		""managerName"": ""MARCIO KIKUTI"",
		""managerUrl"": ""kikuti""
	},
	""awardsBlock"": [{
		""title"": ""Team Highlight"",
		""description"": {
			""value"": """"
		},
		""icon"": ""4"",
		""date"": 1325376000000
	}, {
		""title"": ""Team Highlight"",
		""description"": {
			""value"": """"
		},
		""icon"": ""4"",
		""date"": 1261872000000
	}, {
		""title"": ""Team Highlight"",
		""description"": {
			""value"": """"
		},
		""icon"": ""4"",
		""date"": 1356825600000
	}, {
		""title"": ""Individual Highlight"",
		""description"": {
			""value"": """"
		},
		""icon"": ""3"",
		""date"": 1356825600000
	}, {
		""title"": ""Sustainability"",
		""description"": {
			""value"": """"
		},
		""icon"": ""37"",
		""date"": 1388275200000
	}, {
		""title"": ""5 Years"",
		""description"": {
			""value"": """"
		},
		""icon"": ""1"",
		""date"": 1419724800000
	}, {
		""title"": ""Team Highlight"",
		""description"": {
			""value"": ""O desafio de negócio do cliente (Lançamento do Banco Digital em Mar/15) implicou em montar 12 células de projeto para num prazo de 6 meses garantir o marco de negócio, sendo que para uma tecnologia especifica de mobile não tínhamos o conhecimento instalado na CI&T. As células foram montadas, sendo que 85% do time era recém contratado (incluindo key positions), entenderam o desafio, empenharam-se em instalar/estabilizar o conhecimento técnico e mesmo frente a tantas restrições e/ou dificuldades para executar nosso processo de desenvolvimento, o qual garante parte do sucesso dos projetos realizados pela CI&T, conseguimos progredir no planejamento do projeto e desde Jan/15 essas células vem garantindo implantações importantes para o atingimento do marco de negócio do cliente. Temos muitos desafios ainda pela frente e lições aprendidas para incorporar no dia-a-dia das células, mas certamente o resultado obtido até então é muito expressivo.""
		},
		""icon"": ""4"",
		""date"": 1419724800000
	}],
	""projectsBlock"": {
		""current"": [""Banco Original""]
	},
	""expired"": false,
	""autoModerated"": true,
	""approved"": false,
	""unapproved"": false,
	""featured"": false,
	""id"": 4503636010860544,
	""createdAt"": 1429603644675,
	""mnemonic"": ""ralencar"",
	""status"": ""DELETED"",
	""approvalStatus"": ""UNAPPROVED"",
	""attachments"": [],
	""isFeatured"": false,
	""providerUserId"": ""ralencar@ciandt.com"",
	""hashtagList"": [],
	""title"": ""RAFAEL DE CASTRO SANTOS ALENCAR"",
	""providerContentId"": ""ralencar"",
	""providerId"": ""brain.person"",
	""providerUpdated"": 1429603644675,
	""expirationDate"": 32535302399000,
	""publishingDate"": 0
}";

            //string text = System.IO.File.ReadAllText(@"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-4.json");

            //string text = System.IO.File.ReadAllText(@"D:\WorkingDir\Projetos\DCoder\Jsons\json_test.json");

            string filePath = @"D:\WorkingDir\Projetos\DCoder\Jsons\Card-1429782151462-2.json";

            System.IO.StreamReader file = new System.IO.StreamReader(filePath);
            List<string> lines = new List<string>();

            int counter = 0;
            string line;
            System.Text.StringBuilder sb = new StringBuilder();

            while ((line = file.ReadLine()) != null)
            {
                using (JsonTextReader reader = new JsonTextReader(new StringReader(line)))
                {
                    while (reader.Read())
                    {
                        if (reader.Value != null)
                        {
                            if (reader.Value.ToString().Length > 50 && !reader.Value.ToString().StartsWith("https"))
                            {
                                string token = @"{""access""";

                                if (reader.Value.ToString().StartsWith(token))
                                {
                                    using (JsonTextReader reader2 = new JsonTextReader(new StringReader(reader.Value.ToString())))
                                    {
                                        while (reader2.Read())
                                        {
                                            if (reader2.Value != null)
                                            {
                                                if (reader2.Value.ToString().Length > 50 && !reader2.Value.ToString().StartsWith("https"))
                                                {
                                                    sb.Append(RemoveHtmlTags(reader2.Value.ToString()));
                                                    //lines.Add(RemoveHtmlTags(reader2.Value.ToString()));
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                    sb.Append(RemoveHtmlTags(reader.Value.ToString()));
                                    //lines.Add(RemoveHtmlTags(reader.Value.ToString()));
                            }
                         
                        }

                        
                    }

                }

                if (sb.Length > 0)
                {
                    lines.Add("##NEW_POST##" + sb.ToString());
                    sb.Clear();
                }

                System.IO.File.WriteAllLines(@"D:\WorkingDir\Projetos\DCoder\Jsons\cards_values_output11.txt", lines.ToArray<string>());

                counter++;
            }

            file.Close();

            // Suspend the screen.
            Console.ReadLine();


            //dynamic json = JValue.Parse(text);

            

            

            //foreach (var item in json)
            //{
            //    Console.WriteLine("{0}\n", item);

            //    string itemName = item.Name.ToString();
            //    switch (itemName)
            //    {
            //        case "awardsBlock" :
            //            Console.WriteLine("{0}\n", item.Title);
            //            break;

            //        default:
            //            //Console.WriteLine("{0}\n", item.Title);
            //            break;
            //    }
            //}



            // values require casting
            //string awardsBlock = json.awardsBlock;
            //string company = json.Company;
            //DateTime entered = json.Entered;

            //Assert.AreEqual(name, "Rick");
            //Assert.AreEqual(company, "West Wind");
        }

        [TestMethod]
        public void JsonArrayParsingTest()
        {
            JArray jsonVal = JArray.Parse(jsonString) as JArray;
            dynamic albums = jsonVal;

            foreach (dynamic album in albums)
            {
                Console.WriteLine(album.AlbumName + " (" + album.YearReleased.ToString() + ")");
                foreach (dynamic song in album.Songs)
                {
                    Console.WriteLine("\t" + song.SongName);
                }
            }

            Console.WriteLine(albums[0].AlbumName);
            Console.WriteLine(albums[0].Songs[1].SongName);
        }

        [TestMethod]
        public void JsonParseToStrongTypeTest()
        {
            JArray albums = JArray.Parse(jsonString) as JArray;

            // pick out one album
            JObject jalbum = albums[0] as JObject;

            // Copy to a static Album instance
            Album album = jalbum.ToObject<Album>();

            Assert.IsNotNull(album);
            Assert.AreEqual(album.AlbumName, jalbum.Value<string>("AlbumName"));
            Assert.IsTrue(album.Songs.Count > 0);
        }

        [TestMethod]
        public void StronglyTypedSerializationTest()
        {

            // Demonstrate deserialization from a raw string
            var album = new Album()
            {
                AlbumName = "Dirty Deeds Done Dirt Cheap",
                Artist = "AC/DC",
                Entered = DateTime.Now,
                YearReleased = 1976,
                Songs = new List<Song>() 
        {
            new Song()
            {
                SongName = "Dirty Deeds Done Dirt Cheap",
                SongLength = "4:11"
            },
            new Song()
            {
                SongName = "Love at First Feel",
                SongLength = "3:10"
            }
        }
            };

            // serialize to string            
            string json2 = JsonConvert.SerializeObject(album, Formatting.Indented);

            Console.WriteLine(json2);

            // make sure we can serialize back
            var album2 = JsonConvert.DeserializeObject<Album>(json2);

            Assert.IsNotNull(album2);
            Assert.IsTrue(album2.AlbumName == "Dirty Deeds Done Dirt Cheap");
            Assert.IsTrue(album2.Songs.Count == 2);
        }


        #region Private Methods

        private string RemoveHtmlTags(string text)
        {
            HtmlAgilityPack.HtmlDocument htmlDoc = new HtmlAgilityPack.HtmlDocument();

            htmlDoc.LoadHtml(text);

            if (htmlDoc == null) return null;

            string output = "";

            foreach (var node in htmlDoc.DocumentNode.ChildNodes)
            {
                output += node.InnerText;
            }

            return output;

        }

        private void SaveCard(Post post)
        {
            JsonValue.ServiceReference1.PredictionDataServiceClient svc = new PredictionDataServiceClient();

            svc.Add(post);

        }


        #endregion

        string jsonString = @"[
{
""Id"": ""b3ec4e5c"",
""AlbumName"": ""Dirty Deeds Done Dirt Cheap"",
""Artist"": ""AC/DC"",
""YearReleased"": 1976,
""Entered"": ""2012-03-16T00:13:12.2810521-10:00"",
""AlbumImageUrl"": ""http://ecx.images-amazon.com/images/I/61kTaH-uZBL._AA115_.jpg"",
""AmazonUrl"": ""http://www.amazon.com/gp/product/B00008BXJ4/ref=as_li_ss_tl?ie=UTF8&tag=westwindtechn-20&linkCode=as2&camp=1789&creative=390957&creativeASIN=B00008BXJ4"",
""Songs"": [
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Dirty Deeds Done Dirt Cheap"",
    ""SongLength"": ""4:11""
    },
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Love at First Feel"",
    ""SongLength"": ""3:10""
    },
    {
    ""AlbumId"": ""b3ec4e5c"",
    ""SongName"": ""Big Balls"",
    ""SongLength"": ""2:38""
    }
]
},
{
""Id"": ""67280fb8"",
""AlbumName"": ""Echoes, Silence, Patience & Grace"",
""Artist"": ""Foo Fighters"",
""YearReleased"": 2007,
""Entered"": ""2012-03-16T00:13:12.2810521-10:00"",
""AlbumImageUrl"": ""http://ecx.images-amazon.com/images/I/41mtlesQPVL._SL500_AA280_.jpg"",
""AmazonUrl"": ""http://www.amazon.com/gp/product/B000UFAURI/ref=as_li_ss_tl?ie=UTF8&tag=westwindtechn-20&linkCode=as2&camp=1789&creative=390957&creativeASIN=B000UFAURI"",
""Songs"": [
    {
    ""AlbumId"": ""67280fb8"",
    ""SongName"": ""The Pretender"",
    ""SongLength"": ""4:29""
    },
    {
    ""AlbumId"": ""67280fb8"",
    ""SongName"": ""Let it Die"",
    ""SongLength"": ""4:05""
    },
    {
    ""AlbumId"": ""67280fb8"",
    ""SongName"": ""Erase/Replay"",
    ""SongLength"": ""4:13""
    }
]
},
{
""Id"": ""7b919432"",
""AlbumName"": ""End of the Silence"",
""Artist"": ""Henry Rollins Band"",
""YearReleased"": 1992,
""Entered"": ""2012-03-16T00:13:12.2800521-10:00"",
""AlbumImageUrl"": ""http://ecx.images-amazon.com/images/I/51FO3rb1tuL._SL160_AA160_.jpg"",
""AmazonUrl"": ""http://www.amazon.com/End-Silence-Rollins-Band/dp/B0000040OX/ref=sr_1_5?ie=UTF8&qid=1302232195&sr=8-5"",
""Songs"": [
    {
    ""AlbumId"": ""7b919432"",
    ""SongName"": ""Low Self Opinion"",
    ""SongLength"": ""5:24""
    },
    {
    ""AlbumId"": ""7b919432"",
    ""SongName"": ""Grip"",
    ""SongLength"": ""4:51""
    }
]
}
]";
    }


    public class Song
    {
        public string SongName { get; set; }
        public string SongLength { get; set; }
    }

    public class Album
    {
        public DateTime Entered { get; set; }
        public string AlbumName { get; set; }
        public string Artist { get; set; }
        public int YearReleased { get; set; }
        public List<Song> Songs { get; set; }
    }
}
