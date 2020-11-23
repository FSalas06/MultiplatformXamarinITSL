using agenda_its.Database;
using agenda_its.Views;
using Xamarin.Forms;

namespace agenda_its
{
    public partial class App : Application
    {
        public static INavigation GlobalNavigation { get; set; }

        ///DB-STEP 3 - Access data in X.F.
        private static PokeDataBase database;
        public static PokeDataBase Database
        {
            get
            {
                if (database == null)
                {
                    database = new PokeDataBase();
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MainView())
            {
                BarBackgroundColor = Color.Red,
            };

            GlobalNavigation = MainPage.Navigation;
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
