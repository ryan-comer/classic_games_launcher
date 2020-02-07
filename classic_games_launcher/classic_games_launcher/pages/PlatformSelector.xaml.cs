using classic_games_launcher.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using classic_games_launcher.data.data_sources;
using classic_games_launcher.models.view_models;
using System.ComponentModel;

namespace classic_games_launcher.pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PlatformSelector : ContentView
    {
        public ICommand ImageClickedCommand { private set; get; }

        private PlatformListViewModel platformList;
        public PlatformListViewModel PlatformList
        {
            get
            {
                if(platformList == null)
                {
                    platformList = new PlatformListViewModel();
                }

                return platformList;
            }
            set
            {
                platformList = value;
            }
        }

        public PlatformSelector()
        {
            InitializeComponent();
            BindingContext = this;
            ImageClickedCommand = new Command((obj) =>
            {
                PlatformImageClicked(obj);
            });

            initializePlatforms();
        }

        private void initializePlatforms()
        {
            // Get the platforms
            Task<List<Platform>> getPlatformsTask = PlatformsSource.GetPlatforms();
            getPlatformsTask.ContinueWith(task =>
            {
                var platformViewModels = new List<PlatformViewModel>();
                var platforms = task.Result;

                // Initialize the view models
                foreach (var platform in platforms)
                {
                    platformViewModels.Add(new PlatformViewModel(platform));
                }

                // Update the property
                PlatformList.ViewModels = platformViewModels;
            });
        }

        // User clicked a platform selection
        private void PlatformImageClicked(object sender)
        {
            PlatformViewModel viewModel = (PlatformViewModel)sender;
            // Go to the new page
            /*((MainPage)App.Current.MainPage).SetContent(new classic_games_launcher.pages.GameListPage(
                platform
                ));*/
        }
    }
}