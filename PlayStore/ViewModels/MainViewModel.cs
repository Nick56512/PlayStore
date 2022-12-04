
using PlayStore.Infrastructure;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlayStore.ViewModels
{
    class MainViewModel:BaseNotifyOfPropertyChanged,INavigator
    {
        UserControl currentView;
        public UserControl CurrentView 
        { 
            get=>currentView;
            set
            {
                currentView = value;
                NotifyPropertyChanged();
            }
        }

        UserControl currentMenu;
        public UserControl CurrentMenu
        {
            get => currentMenu;
            set
            {
                currentMenu = value;
                NotifyPropertyChanged();
            }
        }

        public void CheckSaveProfile()
        {
            //string text=FileStyleUriParser.WriteAll()
        }

        public MainViewModel()
        {
            Switcher.ContentArea = this;

            AuthorizationView view = new AuthorizationView();
            if(!(view.DataContext as AuthorizationViewModel).CheckSaveProfile())
            {
                 CurrentView = new UserMainView();
                
                CurrentMenu = new UserMenu();
            }
        }

        public void Navigate(UserControl page)
        {
            CurrentView = page;
        }
        public void NavigateMenu(UserControl menu)
        {
            CurrentMenu = menu;
        
        }

    }
}
