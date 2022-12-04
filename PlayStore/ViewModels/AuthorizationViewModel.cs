using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Models;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PlayStore.ViewModels
{
    class AuthorizationViewModel:BaseNotifyOfPropertyChanged
    {
        public string Login { get; set; }

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

        UserService userService;
        AdminService adminService;

        public bool SaveProfile { get; set; }
        


        public AuthorizationViewModel(UserService userService,AdminService adminService)
        {
            this.userService = userService;
            this.adminService = adminService;
            AuthorizationCommand = new RelayCommand(Authorization);
            SaveProfile = false;
            GoRegistrationCommand = new RelayCommand((param) => {

                Switcher.Switch(new RegistrationView());
            });
        }

        public void AuthorizationUser(UserDTO user)
        {
            UserMenu userMenu = new UserMenu();
            (userMenu.DataContext as UserMenuViewModel).CurrentUser = user;
            Switcher.SwitchMenu(userMenu);

            UserMainView mainView = new UserMainView();
            (mainView.DataContext as UserMainViewModel).CurrentUser = user;

            Switcher.Switch(mainView);
        }
        public void AuthorizationAdmin(AdminDTO admin)
        {
            AdministrationMenu Menu = new AdministrationMenu();
            (Menu.DataContext as AdministrationMenuViewModel).CurrentAdmin = admin;
            Switcher.SwitchMenu(Menu);

            Switcher.Switch(new AdministrationView());
        }

        public bool CheckSaveProfile()
        {
            string text = File.ReadAllText("profile.txt");
            string[] data = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            try
            {
                UserDTO user = userService.Authorization(data[0], data[1]);
                AdminDTO admin = adminService.Authorization(data[0], data[1]);
                if (user != null)
                {
                    AuthorizationUser(user);
                    return true;
                }
                else if (admin != null)
                {
                    AuthorizationAdmin(admin);
                    return true;
                }
                return false;
            }
            catch { return false; }
        }


        private void Authorization(object parametr)
        {
            var passwordBox = parametr as PasswordBox;
            try
            {     UserDTO user = userService.Authorization(
                    Encryptor.Encrypt(Login), 
                    Encryptor.Encrypt(passwordBox.Password));

                AdminDTO admin = adminService.Authorization(Login, passwordBox.Password);
           
                if (user != null)
                {
                    AuthorizationUser(user);

                    if (SaveProfile)
                    {

                        File.WriteAllText("profile.txt", $"{Encryptor.Encrypt(Login)}" +

                           $" {Encryptor.Encrypt(passwordBox.Password)}");

                    }
                }
                else if (admin != null)
                {
                    AuthorizationAdmin(admin);
                    if (SaveProfile)
                    {

                        File.WriteAllText("profile.txt", $"{Login}" +

                         $" {passwordBox.Password}");

                    }
                }
                else
                    Info = "Неверный логин или пароль";
            }
            catch { }
           
        }

        public ICommand AuthorizationCommand { get; set; }
        public ICommand GoRegistrationCommand { get; set; }

    }
}
