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
    class InfoByGameViewModel:BaseNotifyOfPropertyChanged
    {
        GameDTO game;
        public GameDTO Game 
        { 
            get=>game; 
            set
            {
                game = value;
                NotifyPropertyChanged();
            }
        }
        ObservableCollection<PhotoDTO> screenshots;
        public ObservableCollection<PhotoDTO> Screenshots 
        { 
            get=>screenshots;
            set
            {
                screenshots = value;
                NotifyPropertyChanged();
            }
        }
        public CartDTO Cart { get; set; }
        public UserDTO User { get; set; }

        CartService cartService;
        public InfoByGameViewModel(CartService cartService)
        {
            this.cartService = cartService;
            AddToCartCommand = new RelayCommand((param) => {

                try
                {
                    cartService.AddGameToCart(Cart, Game);

                    UserMenu menu = new UserMenu();
                    (menu.DataContext as UserMenuViewModel).CurrentUser = User;
                    Switcher.SwitchMenu(menu);
                }
                catch { Switcher.Switch(new AuthorizationView()); }


            });
        }

        public ICommand AddToCartCommand { get; set; }
    }
}
