using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Models;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayStore.ViewModels
{
    class AdministrationMenuViewModel:BaseNotifyOfPropertyChanged
    {
        AdminDTO currentAdmin;
        public AdminDTO CurrentAdmin
        {
            get => currentAdmin;
            set
            {
                currentAdmin = value;
                NotifyPropertyChanged();
            }
        }
        GameService gameService;

        public string GameName { get; set; }

        public AdministrationMenuViewModel(GameService gameService)
        {
            this.gameService = gameService;

            SearchGameCommand = new RelayCommand((param) => 
            {
                if (GameName != null)
                {
                    AdministrationView view = new AdministrationView();
                    (view.DataContext as AdministrationViewModel).Games = new ObservableCollection<GameDTO>(gameService.FindByName(GameName));
                    Switcher.Switch(view);
                }

            });




            ExitProfileCommand = new RelayCommand((param) => {

                CurrentAdmin = new AdminDTO();
        
                Switcher.Switch(new AuthorizationView());
                Switcher.SwitchMenu(new UserMenu());
                File.WriteAllText("profile.txt", "");

            });
            AddNewGameCommand = new RelayCommand((param) =>
            {
                Switcher.Switch(new AddGameView());

            });

            ExportToExcelCommand = new RelayCommand((param) =>
            {
                ExcelParser.ExportToExcel(gameService.GetAll());

            });

            GoToMainAdminCommand = new RelayCommand((param) => {

                Switcher.Switch(new AdministrationView());
            
            });

        }

        public ICommand ExportToExcelCommand { get; set; }
        public ICommand ExitProfileCommand { get; set; }
        public ICommand AddNewGameCommand { get; set; }
        public ICommand SearchGameCommand { get; set; }
        public ICommand GoToMainAdminCommand { get; set; }
    }
}
