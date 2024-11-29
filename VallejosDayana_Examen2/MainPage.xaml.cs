namespace VallejosDayana_Examen2
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void NavigateToPage1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

     
        private async void NavigateToPage2(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page2());
        }
    }

}
