using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using PlayStore.Infrastructure;
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
    class UserMenuViewModel:BaseNotifyOfPropertyChanged
    {
        public ObservableCollection<GenreDTO> Genres { get; set; }

        GenreDTO genre;
        public GenreDTO CurrentGenre
        {
            get => genre;
            set
            {
                genre = value;
                NotifyPropertyChanged();
                GetGamesInCurrentGenre();
            }
        }
        UserDTO currentUser;
        public UserDTO CurrentUser
        {
            get => currentUser;
            set
            {
                currentUser = value;
                VisibleForAuthorizationButton = "Collapsed";
                VisibleUserProfile = "Visible";
                CalculateQuantityGamesInCart();
                NotifyPropertyChanged();
            }
        }
        string visAuthoriz;
        public string VisibleForAuthorizationButton
        {
            get => visAuthoriz;
            set
            {
                visAuthoriz = value;
                NotifyPropertyChanged();
            }
        }
        string visUserProfile;
        public string VisibleUserProfile
        {
            get => visUserProfile;
            set
            {
                visUserProfile = value;
                NotifyPropertyChanged();
            }
        }
        int quantityGames;
        public int QuantityGames 
        {
            get => quantityGames;
            set
            {
                quantityGames = value;
                NotifyPropertyChanged();
            }
        }
      



        public string GameName { get; set; }

        GameService gameService;
        GenreService genreService;


        public UserMenuViewModel(GameService gameService,GenreService genreService)
        {
            this.genreService = genreService;
            this.gameService = gameService;
            Genres = new ObservableCollection<GenreDTO>(genreService.GetAll());
            CreateCommands();
            VisibleForAuthorizationButton = "Visible";
            VisibleUserProfile = "Hidden";
        }
        private void CreateCommands()
        {
            SearchGameCommand = new RelayCommand((param) => {

                if (GameName != null)
                {
                    UserMainView listGames = new UserMainView();
                    (listGames.DataContext as UserMainViewModel).Games = new ObservableCollection<GameDTO>(gameService.FindByName(GameName));
                    (listGames.DataContext as UserMainViewModel).CurrentUser = CurrentUser;
                    Switcher.Switch(listGames);
                }
            });
            GetNewGamesCommand = new RelayCommand((param) => {

                var games = gameService.GetAll().Where((game) =>
                {
                    if (game.ReleaseDate != null)
                    {
                        int releaseYear = game.ReleaseDate.Value.Date.Year;
                        return releaseYear == DateTime.Today.Date.Year;
                    }
                    return false;
                });
                UserMainView listGames = new UserMainView();
                (listGames.DataContext as UserMainViewModel).Games = new ObservableCollection<GameDTO>(games);
                (listGames.DataContext as UserMainViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(listGames);
            });
            AuthorizationCommand = new RelayCommand((param) =>
            {
               // try
               // {
                 //   if (CurrentUser.Email is null||CurrentUser is null)
                 //   {
                        Switcher.Switch(new AuthorizationView());
                 //   }
               // }
                //catch { }
            });

            WatchingCartCommand = new RelayCommand((param) =>
            {
                CartView view = new CartView();
                (view.DataContext as CartViewModel).User = CurrentUser;
                (view.DataContext as CartViewModel).CartGames = new ObservableCollection<GameDTO>(CurrentUser.Cart.Games);
                Switcher.Switch(view);
            });

            WatchingGameLibraryCommand = new RelayCommand((param) => 
            {
                GameLibraryView view = new GameLibraryView();
                (view.DataContext as GameLibraryViewModel).Games = new ObservableCollection<GameDTO>(CurrentUser.Games);
                Switcher.Switch(view);
            });

            ExitProfileCommand = new RelayCommand((param) => {

                CurrentUser = new UserDTO();
                VisibleForAuthorizationButton = "Visible";
                VisibleUserProfile = "Hidden";
                Switcher.Switch(new AuthorizationView());
                File.WriteAllText("profile.txt","");

            });

            AddCardCommand = new RelayCommand((param) => {

                AddCardView view = new AddCardView();
                (view.DataContext as AddCardViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(view);
            
            });
            GetAllGames = new RelayCommand((param) => {

                UserMainView listGames = new UserMainView();
                (listGames.DataContext as UserMainViewModel).Games = new ObservableCollection<GameDTO>(gameService.GetAll());
                (listGames.DataContext as UserMainViewModel).CurrentUser = CurrentUser;
                Switcher.Switch(listGames);

            });

        }

        private void GetGamesInCurrentGenre()
        {
            UserMainView listGames = new UserMainView();
            (listGames.DataContext as UserMainViewModel).Games =new ObservableCollection<GameDTO>(CurrentGenre.Games);
            Switcher.Switch(listGames);
        }
        public void CalculateQuantityGamesInCart()
        {
            if(!(CurrentUser.Cart is null))
            {
                QuantityGames = CurrentUser.Cart.Games.Count();
            }
        }


        public ICommand SearchGameCommand { get; set; }
        public ICommand GetNewGamesCommand { get; set; }
        public ICommand AuthorizationCommand { get; set; }
        public ICommand AddCardCommand { get; set; }
        public ICommand WatchingCartCommand { get; set; }
        public ICommand WatchingGameLibraryCommand { get; set; }
        public ICommand ExitProfileCommand { get; set; }
        public ICommand GetAllGames { get; set; }
      
    }
}
