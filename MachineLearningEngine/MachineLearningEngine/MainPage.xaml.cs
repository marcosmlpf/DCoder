using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Drive.v2.Data;
using Google.Apis.Prediction.v1_6;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using MachineLearningEngine.ServiceReference1;
using Windows.Storage;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace MachineLearningEngine
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private UserCredential credential;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void btnProcess_Click(object sender, RoutedEventArgs e)
        {
            this.lstLog.Items.Add("Starting...");

            try
            {
                // Get all posts not processed
                ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

                var posts = await svc.GetPostByStatusAsync(PredicctionStatus.NotProcessed.ToString());

                this.txtMsg.Text = "Total rows : " + posts.Count().ToString();
                int totalRows = posts.Count();

                await AuthenticateAsync();

                // Call predict for each post
                foreach (var post in posts)
                {
                    try
                    {
                        var processedPost = await Predict(post.Description);

                        post.Status = PredicctionStatus.Processed.ToString();
                        post.PredictionLabelResult = processedPost.PredictionLabelResult;
                        post.BENEFITS = processedPost.BENEFITS;
                        post.CAREER_DEVELOPMENT = processedPost.CAREER_DEVELOPMENT;
                        post.CELEBRATION = processedPost.CELEBRATION;
                        post.COLLABORATION_CULTURE = processedPost.COLLABORATION_CULTURE;
                        post.ENVIR_HEALTHY = processedPost.ENVIR_HEALTHY;
                        post.FELLOWSHIP = processedPost.FELLOWSHIP;
                        post.HIRING_EFFECTIVITY = processedPost.HIRING_EFFECTIVITY;
                        post.INFRASTRUCTURE = processedPost.INFRASTRUCTURE;
                        post.INNOVATION_CULTURE = processedPost.INNOVATION_CULTURE;
                        post.MANAGEMENT_CULTURE = processedPost.MANAGEMENT_CULTURE;
                        post.MANAGEMENT_FEEDBACK = processedPost.MANAGEMENT_FEEDBACK;
                        post.MANAGEMENT_RESPECT = processedPost.MANAGEMENT_RESPECT;
                        post.NO_DISCRIMINATION = processedPost.NO_DISCRIMINATION;
                        post.OPEN_COMMUNICATION = processedPost.OPEN_COMMUNICATION;
                        post.PURPOSE = processedPost.PURPOSE;
                        post.RECOGNITION = processedPost.RECOGNITION;
                        post.SOCIAL_WORK_BALANCE = processedPost.SOCIAL_WORK_BALANCE;
                        post.TRAINING = processedPost.TRAINING;

                        this.lstLog.Items.Add("Updating post: " + post.PredictionLabelResult + " - " + post.Id.ToString() + " - " + post.Description.Substring(0, 60) + "...");

                        // Update predict
                        await svc.UpdatePostAsync(post);

                    }
                    catch (Exception)
                    {
                        post.Status = PredicctionStatus.Error.ToString();

                        svc.UpdatePostAsync(post);
                    }
                  

                    totalRows = totalRows - 1;

                    this.txtMsg.Text = "Total rows : " + posts.Count().ToString() + " - Remaining Rows : " + totalRows.ToString(); ;
                }
            }
            catch (Exception ex)
            {
                MessageDialog m = new MessageDialog(ex.Message);
                m.ShowAsync();

            }

            this.lstLog.Items.Add("Finished");
        }

        private async Task AuthenticateAsync()
        {

            // C:\Users\feliperc\AppData\Roaming\Drive.Auth.Store

            credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                new Uri("ms-appx:///Assets/client_secrets.json"),
                new[] { DriveService.Scope.Drive, 
                        PredictionService.Scope.Prediction,
                        PredictionService.Scope.DevstorageFullControl
                        },
                "new_user",
                CancellationToken.None);

        }

        private async Task<Post> Predict(string postDescription)
        {
            const string API_KEY = "AIzaSyB1eYnBdNSAjwwK1rMSw7hBlsi2Wh4ulRY";
            const string PROJECT = "163818756296";
            const string ID = "enterpriseClimate4";
            var processePost  = new Post();

            var service = new Google.Apis.Prediction.v1_6.PredictionService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Prediction Sample",
                ApiKey = API_KEY,
            });

            try
            {
                var input = new Google.Apis.Prediction.v1_6.Data.Input();

                //IList<object> values = "Java,100,1,Observed,Commerce,6,3,3,Observed".Split(',');

                string[] str = new string[1];
                str[0] = postDescription;

                IList<object> values = str;

                input.InputValue = new Google.Apis.Prediction.v1_6.Data.Input.InputData() {  CsvInstance = values };

                var predictResult = service.Trainedmodels.Predict(input, PROJECT, ID);

                var output = await predictResult.ExecuteAsync();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

                return this.ParsePredcitionReturn(output);

            }
            catch (Exception ex)
            {

                throw;
            }

        }

        private Post ParsePredcitionReturn(Google.Apis.Prediction.v1_6.Data.Output output)
        {

            var post = new Post();
            string label;
            string score;

             foreach (var item in output.OutputMulti)
             {

                 label = item.Label;
                 score = item.Score;

                 post.PredictionLabelResult = output.OutputLabel;

                 switch (label)
                 {
                     case "MANAGEMENT_CULTURE":
                         post.MANAGEMENT_CULTURE = (decimal.Parse(score)).ToString().ToString();
                         break;
                     case "HIRING_EFFECTIVITY":
                         post.HIRING_EFFECTIVITY = (decimal.Parse(score)).ToString();
                         break;

                     case "TRAINING":
                         post.TRAINING = (decimal.Parse(score)).ToString();
                         break;

                     case "INFRASTRUCTURE":
                         post.INFRASTRUCTURE = (decimal.Parse(score)).ToString();
                         break;

                     case "MANAGEMENT_FEEDBACK":
                         post.MANAGEMENT_FEEDBACK = (decimal.Parse(score)).ToString();
                         break;

                     case "INNOVATION_CULTURE":
                         post.INNOVATION_CULTURE = (decimal.Parse(score)).ToString();
                         break;

                     case "MANAGEMENT_RESPECT":
                         post.MANAGEMENT_RESPECT = (decimal.Parse(score)).ToString();
                         break;

                     case "ENVIR_HEALTHY":
                         post.ENVIR_HEALTHY = (decimal.Parse(score)).ToString();
                         break;

                     case "SOCIAL_WORK_BALANCE":
                         post.SOCIAL_WORK_BALANCE = (decimal.Parse(score)).ToString();
                         break;

                     case "PAY":
                         post.PAY = (decimal.Parse(score)).ToString();
                         break;

                     case "RECOGNITION":
                         post.RECOGNITION = (decimal.Parse(score)).ToString();
                         break;

                     case "CAREER_DEVELOPMENT":
                         post.CAREER_DEVELOPMENT = (decimal.Parse(score)).ToString();
                         break;

                     case "NO_DISCRIMINATION":
                         post.NO_DISCRIMINATION = (decimal.Parse(score)).ToString();
                         break;

                     case "OPEN_COMMUNICATION":
                         post.OPEN_COMMUNICATION = (decimal.Parse(score)).ToString();
                         break;

                     case "PURPOSE":
                         post.PURPOSE = (decimal.Parse(score)).ToString();
                         break;

                     case "FELLOWSHIP":
                         post.FELLOWSHIP = (decimal.Parse(score)).ToString();
                         break;

                     case "CELEBRATION":
                         post.CELEBRATION = (decimal.Parse(score)).ToString();
                         break;
                     case "COLLABORATION_CULTURE":
                         post.COLLABORATION_CULTURE = (decimal.Parse(score)).ToString();
                         break;

                 }
             }

             return post;
        }

        private bool IsSpecialChar(string word)
        {
            string[] specialChars = new string[] { "&quot", "&amp", "ciandt", "ci&ampdt" };

            foreach (string w in specialChars)
            {
                if (word.ToLower().Trim() == w.ToLower().Trim())
                {
                    return true;
                }
            }

            return false;
        }

        private bool IsStopWord(string word)
        {
            string[] stopWords = new string[] { "a", "agora", "ainda", "alguém", "algum", "alguma", "algumas", "alguns", "ampla", "amplas", "amplo", "amplos", "ante", "antes", "ao", "aos", "após", "aquela", "aquelas", "aquele", "aqueles", "aquilo", "as", "até", "através", "cada", "coisa", "coisas", "com", "como", "contra", "contudo", "da", "daquele", "daqueles", "das", "de", "dela", "delas", "dele", "deles", "depois", "dessa", "dessas", "desse", "desses", "desta", "destas", "deste", "deste", "destes", "deve", "devem", "devendo", "dever", "deverá", "deverão", "deveria", "deveriam", "devia", "deviam", "disse", "disso", "disto", "dito", "diz", "dizem", "do", "dos", "e", "é", "ela", "elas", "ele", "eles", "em", "enquanto", "entre", "era", "essa", "essas", "esse", "esses", "esta", "está", "estamos", "estão", "estas", "estava", "estavam", "estávamos", "este", "estes", "estou", "eu", "fazendo", "fazer", "feita", "feitas", "feito", "feitos", "foi", "for", "foram", "fosse", "fossem", "grande", "grandes", "há", "isso", "isto", "já", "la", "lá", "lhe", "lhes", "lo", "mas", "me", "mesma", "mesmas", "mesmo", "mesmos", "meu", "meus", "minha", "minhas", "muita", "muitas", "muito", "muitos", "na", "não", "nas", "nem", "nenhum", "nessa", "nessas", "nesta", "nestas", "ninguém", "no", "nos", "nós", "nossa", "nossas", "nosso", "nossos", "num", "numa", "nunca", "o", "os", "ou", "outra", "outras", "outro", "outros", "para", "pela", "pelas", "pelo", "pelos", "pequena", "pequenas", "pequeno", "pequenos", "per", "perante", "pode", "pude", "podendo", "poder", "poderia", "poderiam", "podia", "podiam", "pois", "por", "porém", "porque", "posso", "pouca", "poucas", "pouco", "poucos", "primeiro", "primeiros", "própria", "próprias", "próprio", "próprios", "quais", "qual", "quando", "quanto", "quantos", "que", "quem", "são", "se", "seja", "sejam", "sem", "sempre", "sendo", "será", "serão", "seu", "seus", "si", "sido", "só", "sob", "sobre", "sua", "suas", "talvez", "também", "tampouco", "te", "tem", "tendo", "tenha", "ter", "teu", "teus", "ti", "tido", "tinha", "tinham", "toda", "todas", "todavia", "todo", "todos", "tu", "tua", "tuas", "tudo", "última", "últimas", "último", "últimos", "um", "uma", "umas", "uns", "vendo", "ver", "vez", "vindo", "vir", "vos", "vós" , "alem",
                                                "alem",               "amp",                "aqui",                "atuando",                "br",                "ci",                "com",                "como",                "de",                "docs",                "ele",                "em",                "felipe",                "foi",                "forma",                "hoje",                "mais",                "isso",                "na",                "nao",                "onde",                "para",                "parte",                "pra",                "que",                "quot",                "se",                "sou",                "temos",                "vai",                "vamos",                "voce",                "www"                ,"último","é","acerca","agora","algmas","alguns","ali","ambos","antes","apontar","aquela","aquelas","aquele","aqueles","aqui","atrás","bem","bom","cada","caminho","cima","com","como","comprido","conhecido","corrente","das","debaixo","dentro","desde","desligado","deve","devem","deverá","direita","diz","dizer","dois","dos",            "e","ela","ele","eles","em","enquanto","então","está","estão","estado","esta","estará","este","estes","esteve","estive","estivemos","estiveram","eu","fará","faz","fazer","fazia","fez","fim","foi","fora","horas","iniciar","inicio","ir","irá","ista","iste","isto","ligado","maioria","maiorias","mais","mas","mesmo","meu","muito","muitos","nós"
                                            ,"não","nome","nosso","novo","o","onde","os","ou","outro","para","parte","pegar","pelo","pessoas","pode","poderá","podia","por","porque","povo","promeiro","quê","qual","qualquer","quando","quem","quieto","são","saber","sem","ser","seu","somente","têm","tal","também","tem","tempo","tenho","tentar","tentaram","tente","tentei","teu","teve",
                                            "tipo","tive","todos","trabalhar","trabalho","tu","um","uma","umas","uns","usa","usar","veja","ver","verdade","verdadeiro","você",
                                            "a","agora","ainda","alguém","algum","alguma","algumas","alguns","ampla","amplas","amplo","amplos","ante","antes","ao","aos","após","aquela","aquelas","aquele","aqueles","aquilo","as","até","através","cada","coisa","coisas","com","como","contra","contudo","da","daquele","daqueles","das","de","dela","delas","dele","deles","depois","dessa","dessas","desse","desses","desta","destas","deste","deste","destes","deve","devem","devendo","dever","deverá","deverão","deveria","deveriam","devia","deviam","disse","disso","disto","dito","diz","dizem","do","dos","e","é","ela","elas","ele","eles","em","enquanto","entre","era","essa","essas","esse","esses","esta","está","estamos","estão","estas","estava","estavam","estávamos","este","estes","estou","eu","fazendo","fazer","feita","feitas","feito","feitos","foi","for","foram","fosse","fossem","grande","grandes","há","isso","isto","já","la","lá","lhe","lhes","lo","mas","me","mesma","mesmas","mesmo","mesmos","meu","meus","minha","minhas","muita","muitas","muito","muitos","na","não","nas","nem","nenhum","nessa","nessas","nesta","nestas","ninguém","no","nos","nós","nossa","nossas","nosso","nossos","num","numa","nunca","o","os","ou","outra","outras","outro","outros","para","pela","pelas","pelo","pelos","pequena","pequenas","pequeno","pequenos","per","perante","pode","pude","podendo","poder","poderia","poderiam","podia","podiam","pois","por","porém","porque","posso","pouca","poucas","pouco","poucos","primeiro","primeiros","própria","próprias","próprio","próprios","quais","qual","quando","quanto","quantos","que","quem","são","se","seja","sejam","sem","sempre","sendo","será","serão","seu","seus","si","sido","só","sob","sobre","sua","suas","talvez","também","tampouco","te","tem","tendo","tenha","ter","teu","teus","ti","tido","tinha","tinham","toda","todas","todavia","todo","todos","tu","tua","tuas","tudo","última","últimas","último","últimos","um","uma","umas","uns","vendo","ver","vez","vindo","vir","vos","vós",
                                            "abaixo", "www.", "video", "us-en", "plus", "se","que","foi","esta", "caso","assim","nao",".com","CI&amp;","CI&amp;T","#ciandt",".ciandt","&amp", "google"
            };

            foreach (string w in stopWords)
            {
                if (word.ToLower().Trim() == w.ToLower().Trim())
                {
                    return true;
                }
            }

            return false;
        }

        async Task SaveStringToLocalFile(string filename, List<string> lines)
        {
            // create a file with the given filename in the local folder; replace any existing file with the same name
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);

            await Windows.Storage.FileIO.WriteLinesAsync(file, lines);

        }

        private async void btnTagCloudByPost_Click(object sender, RoutedEventArgs e)
        {

            string line;
            List<string> lines = new List<string>();

            // Get all posts
            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            var posts = await svc.GetAllPostsAsync();

            this.txtMsg.Text = "Total rows : " + posts.Count().ToString();

            int totalRows = posts.Count();
            
            foreach (var post in posts)
            {
                line = post.Description;

                string[] words = line.Split(' ');

                foreach (var word in words)
                {
                    if (IsStopWord(word))
                        line = line.Replace(" " + word + " ", " ");

                    if (IsSpecialChar(word))
                        line = line.Replace(word, "");
                }

                lines.Add(line);

                this.lstLog.Items.Add("Cleaning line : " + lines.Count().ToString());
                this.lstLog.Items.Add(line);

            }

            // save to file
            await SaveStringToLocalFile("tagCloud5.txt", lines);

        }

        private async void btnTagCloudByLabel_Click(object sender, RoutedEventArgs e)
        {
            string line;
            List<string> lines = new List<string>();

            // Get all posts
            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            var posts = await svc.GetAllPostsAsync();

            this.txtMsg.Text = "Total rows : " + posts.Count().ToString();

            int totalRows = posts.Count();

            foreach (var post in posts)
            {
                line = post.PredictionLabelResult;

                if (line != null)
                    lines.Add(line);

            }

            // save to file
            await SaveStringToLocalFile("tagCloudLabel2.txt", lines);
        }

        private async void btnTagCloudByCategory_Click(object sender, RoutedEventArgs e)
        {
            string line;
            List<string> lines = new List<string>();

            // Get all posts
            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            var posts = await svc.GetAllPostsAsync();

            this.txtMsg.Text = "Total rows : " + posts.Count().ToString();

            int totalRows = posts.Count();

            foreach (var post in posts)
            {
                if (post.PredictionLabelResult != null)
                {
                    var categoryName = await svc.GetCategoryByLabelAsync(post.PredictionLabelResult);

                    line = categoryName;

                    if (line != null)
                        lines.Add(line);
                }

            }

            // save to file
            await SaveStringToLocalFile("tagCloudCategory.txt", lines);
        }

        private async void btnTagCloudByLM_Click(object sender, RoutedEventArgs e)
        {

            string line;
            List<string> lines = new List<string>();

            // Get all posts
            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            //var posts = await svc.GetExternalContentAsync("LOVE_MONDAYS");

            var posts = await svc.GetExternalContentAsync("GLASS_DOOR");

            this.txtMsg.Text = "Total rows : " + posts.Count().ToString();

            int totalRows = posts.Count();

            foreach (var post in posts)
            {
                //line = post.Pos;
                line = post.Cons;

                string[] words = line.Split(' ');

                foreach (var word in words)
                {
                    if (IsStopWord(word))
                        line = line.Replace(" " + word + " ", " ");

                    if (IsSpecialChar(word))
                        line = line.Replace(word, "");
                }

                lines.Add(line);

                this.lstLog.Items.Add("Cleaning line : " + lines.Count().ToString());
                this.lstLog.Items.Add(line);

            }

            // save to file
            await SaveStringToLocalFile("tagCloudLGLASS_CONS.txt", lines);

        }

     
    }
}
