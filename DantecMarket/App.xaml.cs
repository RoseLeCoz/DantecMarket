using DantecMarket.Vues;

namespace DantecMarket
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Registration());
        }
    }
}
