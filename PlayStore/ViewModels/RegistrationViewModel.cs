
using Microsoft.Win32;
using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Input;


namespace PlayStore.ViewModels
{
    public class RegistrationViewModel:BaseNotifyOfPropertyChanged
    {
        UserDTO user;
        public UserDTO NewUser 
        { 
            get=>user;
            set
            {
               user=value ;
               NotifyPropertyChanged();
            }
        }
        string info;
        public string Info 
        { 
            get=>info;
            set
            {
                info = value;
                NotifyPropertyChanged();
            }
        }
        public RegistrationViewModel()
        {
            NewUser = user;
            Info = "*Поля со звездочкой обязательны!";
            CreateCommands();
            NewUser = new UserDTO
            {
                Photo= "https://emblemsbf.com/img/77006.webp"
            };

        }
        private void GoToNextRegistration(object param)
        {
                if (NewUser.Name != null)
                {
                    if (NewUser.Surname != null)
                    {
                        if (NewUser.Email != null)
                        {
                            CreateLoginAndPasswordView view = new CreateLoginAndPasswordView();
                            (view.DataContext as CreateLoginAndPasswordViewModel).NewUser = NewUser;
                            Switcher.Switch(view);
                        }
                        else Info = "*Укажите свою почту";
                    }
                    else Info = "*Укажите свою фамилию";
                }
                else Info = "*Укажите свое имя";
        }
        
        private void CreateCommands()
        {
            GoNextPageCommand = new RelayCommand(GoToNextRegistration);
            UploadAvatarCommand = new RelayCommand((param) =>
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png";
                if(openFileDialog.ShowDialog()!=false)
                {
                    user.Photo = openFileDialog.FileName; 
                    NewUser = user;
                }
            });
        }

        public ICommand GoNextPageCommand { get; set; }
        public ICommand UploadAvatarCommand { get; set; }
    }
}
