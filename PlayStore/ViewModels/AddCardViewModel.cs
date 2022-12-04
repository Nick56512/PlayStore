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
    class AddCardViewModel:BaseNotifyOfPropertyChanged
    {
        UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                CheckCardUser();
                NotifyPropertyChanged();
            }
        }
        CardService cardService;

        CardDTO card;
        public CardDTO Card 
        {
            get => card;
            set
            {
                card = value;
                NotifyPropertyChanged();
            }
                
        }

        private void CheckCardUser()
        {
            Card = cardService.GetCardByUserId(CurrentUser);

            if(Card is null)
            {
                Card = new CardDTO();
            }
        }
        public AddCardViewModel(CardService cardService)
        {
            this.cardService = cardService;
            AddCardCommand = new RelayCommand((param) =>
            {

                Card.Balance = 1500;

                Card.UserId = CurrentUser.Id;

                cardService.AddOrUpdateCard(Card);
               

                UserMainView listGames = new UserMainView();
                (listGames.DataContext as UserMainViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(listGames);

            });
        }




        public ICommand AddCardCommand { get; set; }

    }
}
