using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Models;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlayStore.ViewModels
{
    class CreateLoginAndPasswordViewModel:BaseNotifyOfPropertyChanged
    {
        UserDTO user;
        public UserDTO NewUser
        {
            get => user;
            set
            {
                user = value;
                NotifyPropertyChanged();
            }
        }
        UserService userService;
        AdminService adminService;

        string info;
        public string Info
        {
            get => info;
            set
            {
                info = value;
                NotifyPropertyChanged();
            }
        }
        private async void Registartion(object param)
        {
           
                var passwordBox = param as PasswordBox;
                if (NewUser.Login.Length > 6)
                {
                    if (passwordBox.Password!= null)
                    {
                        if (userService.CheckSameLogin(Encryptor.Encrypt(NewUser.Login))==null)
                        {
                             if (adminService.CheckSameLogin(NewUser.Login) == null)
                             {
                                   if(NewUser.Photo!="")    




                                  NewUser.Cart = new CartDTO();

                                  NewUser.Password = Encryptor.Encrypt(passwordBox.Password);
                                  NewUser.Login = Encryptor.Encrypt(NewUser.Login);

                                  Switcher.Switch(new AuthorizationView());
                                  await userService.AddUser(NewUser);
                             }
                             else
                             {
                                Info = "* пользователь с таким логином уже существует";
                             }

                           
                        }
                        else
                            Info = "* пользователь с таким логином уже существует";
                    }
                    else
                        Info = "* Вы не указали пароль";
                }
                else Info = "* длина логина должна быть более 6 символов";
          
        }

        public CreateLoginAndPasswordViewModel(UserService userService,AdminService adminService)
        {
           
            this.userService = userService;
            this.adminService = adminService;

            RegistrationCommand = new RelayCommand(Registartion);

            GoBackCommand = new RelayCommand((param) => {

                RegistrationView view = new RegistrationView();

                (view.DataContext as RegistrationViewModel).NewUser = NewUser;
                Switcher.Switch(view);
                
            });
        }
        public ICommand RegistrationCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
    }
}
