using MachineLearningEngine.Common;
using MachineLearningEngine.GoogleAPI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Items Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234233

namespace MachineLearningEngine
{
    /// <summary>
    /// A page that displays a collection of item previews.  In the Split Application this page
    /// is used to display and select one of the available groups.
    /// </summary>
    public sealed partial class ModelTrainingPage : Page
    {
        private NavigationHelper navigationHelper;
        private ObservableDictionary defaultViewModel = new ObservableDictionary();

        /// <summary>
        /// This can be changed to a strongly typed view model.
        /// </summary>
        public ObservableDictionary DefaultViewModel
        {
            get { return this.defaultViewModel; }
        }

        /// <summary>
        /// NavigationHelper is used on each page to aid in navigation and 
        /// process lifetime management
        /// </summary>
        public NavigationHelper NavigationHelper
        {
            get { return this.navigationHelper; }
        }

        public ModelTrainingPage()
        {
            this.InitializeComponent();
            this.navigationHelper = new NavigationHelper(this);
            this.navigationHelper.LoadState += navigationHelper_LoadState;
        }

        /// <summary>
        /// Populates the page with content passed during navigation.  Any saved state is also
        /// provided when recreating a page from a prior session.
        /// </summary>
        /// <param name="sender">
        /// The source of the event; typically <see cref="NavigationHelper"/>
        /// </param>
        /// <param name="e">Event data that provides both the navigation parameter passed to
        /// <see cref="Frame.Navigate(Type, Object)"/> when this page was initially requested and
        /// a dictionary of state preserved by this page during an earlier
        /// session.  The state will be null the first time a page is visited.</param>
        private void navigationHelper_LoadState(object sender, LoadStateEventArgs e)
        {

            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            var posts = svc.GetAllPostsAsync().Result.Take(10).ToList();

            this.defaultViewModel["Items"] = posts;
        }

        #region NavigationHelper registration

        /// The methods provided in this section are simply used to allow
        /// NavigationHelper to respond to the page's navigation methods.
        /// 
        /// Page specific logic should be placed in event handlers for the  
        /// <see cref="GridCS.Common.NavigationHelper.LoadState"/>
        /// and <see cref="GridCS.Common.NavigationHelper.SaveState"/>.
        /// The navigation parameter is available in the LoadState method 
        /// in addition to page state preserved during an earlier session.

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedTo(e);
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            navigationHelper.OnNavigatedFrom(e);
        }

        #endregion

        #region Apply Label

        private void btnApplyRecognition_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

            this.ApplyLabel(selectedItem);
        }

        private void btnApplyBenefits_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

            this.ApplyLabel(selectedItem);
        }

        private void btnApplyCellebration_Click(object sender, RoutedEventArgs e)
        {
            MenuFlyoutItem selectedItem = sender as MenuFlyoutItem;

            this.ApplyLabel(selectedItem);
        }

        private void ApplyLabel(MenuFlyoutItem selectedItem)
        {
            if (selectedItem != null)
            {
                foreach (var post in this.itemGridView.SelectedItems)
                {
                    ((ServiceReference1.Post)post).PredictionLabelResult = selectedItem.Tag.ToString().ToUpper();
                    ((ServiceReference1.Post)post).Status =  PredicctionStatus.Reprocess.ToString();
                    ((ServiceReference1.Post)post).PredictionDate = System.DateTime.Now;

                    ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

                    svc.UpdatePostAsync((ServiceReference1.Post)post);
                }
            }

            this.itemGridView.SelectedItems.Clear();

        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.BottomAppBar.IsOpen = this.itemGridView.SelectedItems.Count > 0;
        }

        #endregion

        #region Start/Stop prediction

        private void btnStop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnPause_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {

        }

        #endregion

        #region PopUp

        private void ClosePopupClicked(object sender, RoutedEventArgs e)
        {
            // if the Popup is open, then close it 
            if (StandardPopup.IsOpen) { 
                StandardPopup.IsOpen = false;
                this.itemGridView.IsEnabled = true;
            }
        }

        private void ViewClicked(object sender, RoutedEventArgs e)
        {
            // open the Popup if it isn't open already 
            if (!StandardPopup.IsOpen)
            {
                StandardPopup.IsOpen = true;
                
                var content = ((Button)e.OriginalSource).CommandParameter.ToString();
                this.itemGridView.IsEnabled = false;

                this.PopupContent.Text = content;


            }
        }

        private void OnLayoutUpdated(object sender, object e)
        {
            if (grdPopup.ActualWidth == 0 && grdPopup.ActualHeight == 0)
            {
                return;
            }

            double ActualHorizontalOffset = this.StandardPopup.HorizontalOffset;
            double ActualVerticalOffset = this.StandardPopup.VerticalOffset;

            double NewHorizontalOffset = (Window.Current.Bounds.Width - grdPopup.ActualWidth) / 2;
            double NewVerticalOffset = (Window.Current.Bounds.Height - grdPopup.ActualHeight) / 2;

            if (ActualHorizontalOffset != NewHorizontalOffset || ActualVerticalOffset != NewVerticalOffset)
            {

                this.StandardPopup.HorizontalOffset = NewHorizontalOffset;
                this.StandardPopup.VerticalOffset = NewVerticalOffset;
            }
        }

        #endregion

        private void btnRetrain_Click(object sender, RoutedEventArgs e)
        {
            // buscar na base todos os marcados com reprocess
            ServiceReference1.PredictionDataServiceClient svc = new ServiceReference1.PredictionDataServiceClient();

            var posts = svc.GetPostByStatusAsync(PredicctionStatus.Reprocess.ToString()).Result.Take(10).ToList();

            // fazer loop 
            PredictionHelper prediction = new PredictionHelper();

            prediction.TrainedmodelsUpdate(this.LoadTrainData(posts));
        }


        private List<object> LoadTrainData(IEnumerable<ServiceReference1.Post> posts)
        {
            List<object> list = new List<object>();

            foreach (var item in posts)
            {
                list.Add(string.Format("{0},{1}",item.PredictionLabelResult, item.Description));
            }

            return list;
        }
   
    }
}
