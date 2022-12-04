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
    class CartViewModel : BaseNotifyOfPropertyChanged
    {
        CartService cartService;
        CardService cardService;

        UserDTO user;
        public UserDTO User
        {
            get=>user;
            set
            {
                user = value;
                CalculateBalanceInCard();
                NotifyPropertyChanged();
            }
        
        }


        decimal price;
        public decimal Price
        {
            get => price;
            set
            {
                price = value;
                NotifyPropertyChanged();
            }
        }
        decimal balance;
        public decimal Balance
        {

            get => balance;
            set
            {
                balance = value;
                NotifyPropertyChanged();
            }
        
        }



        ObservableCollection<GameDTO> cartGames;
        public ObservableCollection<GameDTO> CartGames
        {
            get => cartGames;
            set
            {
                cartGames = value;
                CalculatePrice();
                
                NotifyPropertyChanged();
            }
        }

        public GameDTO CurrentGame { get; set; }
        private void SwitchToMenu()
        {
            UserMenu menu = new UserMenu();
            (menu.DataContext as UserMenuViewModel).CurrentUser = user;
            Switcher.SwitchMenu(menu);
        }


        public CartViewModel(CartService cartService,CardService cardService,UserService userService)
        {
            this.cartService = cartService;
            this.cardService = cardService;
            DeleteGameCommand = new RelayCommand((param) => {

                cartService.DeleteGameInCart(User.Cart, CurrentGame);
                CartGames.Remove(CurrentGame);
                CalculatePrice();


                SwitchToMenu();
            });
            BuyGamesCommand = new RelayCommand((param) =>
            {
                if(Balance>=price)
                {
                    CardDTO card = cardService.GetCardByUserId(User);
                    if (!(card is null))
                    {
                        card.Balance -= Price;
                        cardService.AddOrUpdateCard(card);
                        Balance = card.Balance;

                        if (User.Games is null)
                            User.Games = new List<GameDTO>();
         
                        foreach(var item in CartGames)
                        {
                            userService.AddGameToLibrary(User, item);
                            user.Games.Add(item);
                        }
                        User.Cart.Games = new List<GameDTO>();
                        CartGames = new ObservableCollection<GameDTO>();

                        SwitchToMenu();



                    }
                }

            });

        }
        private void CalculatePrice()
        {
            if(User.Cart!=null)
            {
                Price = cartService.GetAllPrice(User.Cart);
            }
        }
        private void CalculateBalanceInCard()
        {
            CardDTO card = cardService.GetCardByUserId(User);
            if(!(card is null))
            {
                Balance = card.Balance;
            }
        }


        public ICommand DeleteGameCommand { get; set; }
        public ICommand BuyGamesCommand { get; set; }
       

        

    }
}
