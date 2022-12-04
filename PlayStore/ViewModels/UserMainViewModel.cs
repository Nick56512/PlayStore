using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
using PlayStore.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PlayStore.ViewModels
{
    class UserMainViewModel:BaseNotifyOfPropertyChanged
    {
        ObservableCollection<GameDTO> games;
        public ObservableCollection<GameDTO> Games 
        { 
            get=>games; 
            
            set
            {
                games = value;
                NotifyPropertyChanged();
            }
        }
        public GameDTO SelectedGame { get; set; }

        GameService gameService;
        CartService cartService;

        UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                NotifyPropertyChanged();
            }
        }

        public UserMainViewModel(GameService gameService,CartService cartService)
        {
            this.gameService = gameService;
            this.cartService = cartService;

            Games = new ObservableCollection<GameDTO>(gameService.GetAll());
            CurrentUser = new UserDTO();

            InfoByGameCommand = new RelayCommand((param) => 
            {
                if (SelectedGame != null)
                {
                    try
                    {
                        InfoByGameView view = new InfoByGameView();
                        (view.DataContext as InfoByGameViewModel).Game = SelectedGame;
                        (view.DataContext as InfoByGameViewModel).Screenshots = new ObservableCollection<PhotoDTO>(SelectedGame.Photos);
                        (view.DataContext as InfoByGameViewModel).Cart = CurrentUser.Cart;
                        (view.DataContext as InfoByGameViewModel).User = CurrentUser;
                        Switcher.Switch(view);
                    }
                    catch { }
                }
               
            });
            AddInCart = new RelayCommand((param) => {

                try
                {
                    if (CurrentUser.Login != null)
                    {
                        cartService.AddGameToCart(CurrentUser.Cart, SelectedGame);

                        UserMenu menu = new UserMenu();
                        (menu.DataContext as UserMenuViewModel).CurrentUser = CurrentUser;
                        Switcher.SwitchMenu(menu);

                    }
                    else
                    {
                        Switcher.Switch(new AuthorizationView());
                    }
                }
                catch { Switcher.Switch(new AuthorizationView()); }

            });
        }

        public ICommand InfoByGameCommand { get; set; }
        public ICommand AddInCart { get; set; }
    }
}
