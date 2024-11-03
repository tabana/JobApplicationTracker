using JobApplicationTracker.ViewModel;

namespace JobApplicationTracker
{
    public partial class MainPage : ContentPage
    {
        private readonly TrackingService trackingService;

        public MainPage(TrackingService trackingService, MainViewModel mainViewModel)
        {
            InitializeComponent();
            this.trackingService = trackingService;
            BindingContext = mainViewModel;

            trackingService.Initialize().Wait();
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = (Picker)sender;
            await trackingService.SetApplicant(((Applicant)picker.SelectedItem).Id);
        }

        private void JobApplicationList_ItemTapped(object sender, ItemTappedEventArgs e)
        {

        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            await trackingService.SaveApplicant();
        }
    }
}
