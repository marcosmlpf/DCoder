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

        private async Task<string> Predict(Post post)
        {
            const string API_KEY = "AIzaSyB1eYnBdNSAjwwK1rMSw7hBlsi2Wh4ulRY";
            const string PROJECT = "163818756296";
            const string ID = "attrictionModel";

            decimal verySatisfied = 0;
            decimal satisfied = 0;
            decimal indifferent = 0;
            decimal unSatisfied = 0;
            decimal risky = 0;
            decimal unsatisfied = 0;

            var service = new Google.Apis.Prediction.v1_6.PredictionService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Prediction Sample",
                ApiKey = API_KEY,
            });

            try
            {
                var input = new Google.Apis.Prediction.v1_6.Data.Input();

                IList<object> values = "Java,100,1,Observed,Commerce,6,3,3,Observed".Split(',');

                input.InputValue = new Google.Apis.Prediction.v1_6.Data.Input.InputData() { CsvInstance = values };

                var predictResult = service.Trainedmodels.Predict(input, PROJECT, ID);

                var output = await predictResult.ExecuteAsync();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                foreach (var item in output.OutputMulti)
                {
                    sb.Append(item.Label + " - " + item.Score + System.Environment.NewLine);

                    switch (item.Label)
                    {
                        case "\"Very Satisfied\"":
                            verySatisfied = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                        case "\"Satisfied\"":
                            satisfied = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                        case "\"Indifferent\"":
                            indifferent = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                        case "\"UnSatisfied\"":
                            unSatisfied = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                        case "\"Risky\"":
                            risky = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                        case "\"Unsatisfied\"":
                            unsatisfied = (decimal.Parse(item.Score.Replace(".", ",")) * 100) * 10;
                            break;
                    }
                }


                return output.OutputLabel;

                //var outPutPredictVm = new OutPutPredictVM()
                //{
                //    OutputLabel = output.OutputLabel,
                //    OutputMulti = sb.ToString(),
                //    VerySatisfied = ((int)verySatisfied).ToString(),
                //    Satisfied = ((int)satisfied).ToString(),
                //    Indifferent = ((int)indifferent).ToString(),
                //    Unsatisfied = ((int)unsatisfied).ToString(),
                //    Risky = ((int)risky).ToString()
                //};


            }
            catch (Exception ex)
            {

                throw;
            }

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

                await AuthenticateAsync();

                // Call predict for each post
                foreach (var post in posts)
                {
                    var label = await Predict(post);

                    this.lstLog.Items.Add("Updating post: " + label + " - " + post.Id.ToString() + " - " + post.Description + "...");

                    // Update predict
                    post.PredictionLabelResult = label;

                    post.Status = PredicctionStatus.Processed.ToString();

                    await svc.UpdateAsync(post);
                }
            }
            catch (Exception ex)
            {
                MessageDialog m = new MessageDialog(ex.Message);
                m.ShowAsync();
                
            }

            this.lstLog.Items.Add("Finished");
        }
    }
}
