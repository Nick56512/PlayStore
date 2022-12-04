using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Models;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PlayStore.ViewModels
{
    class AdministrationViewModel
    {
        public ObservableCollection<GameDTO> Games { get; set; }

        GameService gameService;

        public GameDTO CurrentGame { get; set; }

        public AdministrationViewModel(GameService gameService)
        {  
            this.gameService = gameService;
            Games = new ObservableCollection<GameDTO>(gameService.GetAll());
            
            //CurrentGame = new GameDTO();
           
            RemoveGameCommand = new RelayCommand((param) =>
            {
               
                    if (CurrentGame != null)
                    {
                        gameService.RemoveGame(CurrentGame);
                        Games.Remove(CurrentGame);
                    }
                
            });
            UpdateGameCommand = new RelayCommand((param) =>
            {
                if(CurrentGame!=null)
                {
                    AddGameView view = new AddGameView();
                    (view.DataContext as AddGameViewModel).NewGame = CurrentGame;
                   
                    Switcher.Switch(view);
                }

            });
           


        }
       
        public ICommand RemoveGameCommand { get; set; }
        public ICommand UpdateGameCommand { get; set; }
        
        
    }

}
