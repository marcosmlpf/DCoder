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

                var posts = await svc.GetByStatusAsync(PredicctionStatus.NotProcessed.ToString());

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
                        await svc.UpdateAsync(post);

                    }
                    catch (Exception)
                    {
                        post.Status = PredicctionStatus.Error.ToString();

                        svc.UpdateAsync(post);
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
            const string ID = "enterpriseClimate2";
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

        

    }
}
