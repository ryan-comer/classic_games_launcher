using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace classic_games_launcher.models.view_models
{
    public class PlatformViewModel : INotifyPropertyChanged
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                notifyPropertyChanged("Name");
            }
        }

        private string image;
        public string Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
                notifyPropertyChanged("Image");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public PlatformViewModel(Platform platform)
        {
            this.Name = platform.Name;
            this.Image = platform.Image;
        }

        private void notifyPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
