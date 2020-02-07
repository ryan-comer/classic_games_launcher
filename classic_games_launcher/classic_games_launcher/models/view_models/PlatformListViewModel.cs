using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace classic_games_launcher.models.view_models
{
    public class PlatformListViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private List<PlatformViewModel> viewModels;
        public List<PlatformViewModel> ViewModels
        {
            get
            {
                return viewModels;
            }
            set
            {
                viewModels = value;
                if(PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("ViewModels"));
                }
            }
        }

    }
}
