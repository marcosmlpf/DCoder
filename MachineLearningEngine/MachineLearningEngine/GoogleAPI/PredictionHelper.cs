using Google.Apis.Auth.OAuth2;
using Google.Apis.Drive.v2;
using Google.Apis.Prediction.v1_6;
using Google.Apis.Services;
using MachineLearningEngine.ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MachineLearningEngine.GoogleAPI
{
    public class PredictionHelper
    {
        private UserCredential credential;

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

        public async Task<Post> Predict(string postDescription)
        {
            const string API_KEY = "AIzaSyB1eYnBdNSAjwwK1rMSw7hBlsi2Wh4ulRY";
            const string PROJECT = "163818756296";
            const string ID = "enterpriseClimate4";
            var processePost = new Post();

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

                input.InputValue = new Google.Apis.Prediction.v1_6.Data.Input.InputData() { CsvInstance = values };

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

        public Post ParsePredcitionReturn(Google.Apis.Prediction.v1_6.Data.Output output)
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

        public async void TrainedmodelsUpdate(IList<object> newTrainData)
        {
            const string API_KEY = "AIzaSyB1eYnBdNSAjwwK1rMSw7hBlsi2Wh4ulRY";
            const string PROJECT = "163818756296";
            const string ID = "enterpriseClimate4";
            var processePost = new Post();

            await AuthenticateAsync();

            var service = new Google.Apis.Prediction.v1_6.PredictionService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "Prediction Sample",
                ApiKey = API_KEY,
            });

            try
            {
                var body = new Google.Apis.Prediction.v1_6.Data.Update();

                //IList<object> values = "RECOGNITION,Fulano recebeu o prêmio de melhor do mundo".Split(',');

                //string[] str = new string[1];
                //str[0] = postDescription;

                //IList<object> values = str;

                body.CsvInstance = newTrainData;
                body.Output = "RECOGNITION";

                var predictResult = service.Trainedmodels.Update(body, PROJECT, ID);

                var output = await predictResult.ExecuteAsync();

                System.Text.StringBuilder sb = new System.Text.StringBuilder();

            }
            catch (Exception ex)
            {

                throw;
            }

        }
    }
}
