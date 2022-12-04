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
    class AddSystemRequirementsViewModel:BaseNotifyOfPropertyChanged
    {
        GameDTO newGame;
        public GameDTO NewGame
        {
            get => newGame;
            set
            {
                newGame = value;
                NotifyPropertyChanged();
            }
        }

        GameService gameService;
        public AddSystemRequirementsViewModel(GameService gameService)
        {
            this.gameService = gameService;
            AddGameCommand = new RelayCommand((param) => {

                gameService.AddOrUpdateGame(NewGame);
                Switcher.Switch(new AdministrationView());
            
            });

            GoBackCommand = new RelayCommand((param) => 
            {
                AddGameView view = new AddGameView();
                (view.DataContext as AddGameViewModel).NewGame = NewGame;
                Switcher.Switch(view);
            
            });


        }
     
        public ICommand AddGameCommand { get; set; }
        public ICommand GoBackCommand { get; set; }
    }
}
