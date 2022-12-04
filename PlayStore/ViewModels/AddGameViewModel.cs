using Microsoft.Win32;
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
    class AddGameViewModel:BaseNotifyOfPropertyChanged
    {
        GameDTO newGame;
        public GameDTO NewGame 
        { 
            get=>newGame; 
            set
            {
                newGame = value;
                GetScreens();
                NotifyPropertyChanged();
            }
        }
        string screenshot1;
        public string Screenshot1
        {
            get => screenshot1;
            set
            {
                screenshot1 = value;
                NotifyPropertyChanged();
            }
        }
        string screenshot2;
        public string Screenshot2
        {
            get => screenshot2;
            set
            {
                screenshot2 = value;
                NotifyPropertyChanged();
            }
        }
        string screenshot3;
        public string Screenshot3
        {
            get => screenshot3;
            set
            {
                screenshot3 = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<GenreDTO> Genres { get; set; }
        public ObservableCollection<DeveloperDTO> Developers { get; set; }


        GameService gameService;
        GenreService genreService;
        DeveloperService developerService;
       
        public string NewGenre { get; set; }
        public string NewDeveloper { get; set; }
        

        public AddGameViewModel(GameService gameService,GenreService genreService,DeveloperService developerService)
        {
            this.gameService = gameService;
            this.genreService = genreService;
            this.developerService = developerService;
            NewGame = new GameDTO();
            CreateCommands();
            Screenshot1 = "https://img.icons8.com/ios/452/picture.png";
            Screenshot2 = "https://img.icons8.com/ios/452/picture.png";
            Screenshot3 = "https://img.icons8.com/ios/452/picture.png";

            Genres = new ObservableCollection<GenreDTO>(genreService.GetAll());
            Developers = new ObservableCollection<DeveloperDTO>(developerService.GetAll());

        }

        private string UploadPictures()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Files|*.jpg;*.jpeg;*.png";
            if (openFileDialog.ShowDialog() != false)
            {
                return openFileDialog.FileName;
            }
            return null;
        }
        public void UploadScreenshots()
        { //??????????????????????????????????????
            NewGame.Photos = new List<PhotoDTO>();
            if(screenshot1!= "https://img.icons8.com/ios/452/picture.png")
            {
                NewGame.Photos.Add(new PhotoDTO { Photo = Screenshot1 }); ;
            }
            if (screenshot2 != "https://img.icons8.com/ios/452/picture.png")
            {
                NewGame.Photos.Add(new PhotoDTO { Photo = Screenshot2 });
            }
            if (screenshot3 != "https://img.icons8.com/ios/452/picture.png")
            {
                NewGame.Photos.Add(new PhotoDTO { Photo=Screenshot3});
            }
        }

        private void GoToSystemRequirements(object parametr)
        {
            if(NewGenre!=null)
            {
                NewGame.Genre = new GenreDTO { GenreName = NewGenre };
            }
            if (NewDeveloper != null)
            {
                NewGame.Developer = new DeveloperDTO { DeveloperName = NewDeveloper };
            }

            SystemRequirementsView view = new SystemRequirementsView();
            (view.DataContext as AddSystemRequirementsViewModel).NewGame = NewGame;
            Switcher.Switch(view);
        }

        private string UploadScreenPicture()
        {
            string path = UploadPictures();
            if (path != null)
            {
                return path;
            }
            return "https://img.icons8.com/ios/452/picture.png";
        }
     
        private void CreateCommands()
        {
            UploadCoverCommand = new RelayCommand((param)=> {

                newGame.Cover = UploadPictures();
                NewGame = newGame;
            });

            AddSystemRequirementsCommand = new RelayCommand((param) => {

                UploadScreenshots();
                GoToSystemRequirements(param);
               
            });
            UploadScreenshot1 = new RelayCommand((param) => {

                Screenshot1=UploadScreenPicture();
               
            });

            UploadScreenshot2 = new RelayCommand((param) => {

                Screenshot2 = UploadScreenPicture();

            });
            UploadScreenshot3 = new RelayCommand((param) => {

                Screenshot3 = UploadScreenPicture();

            });
        }
        private void GetScreens()
        {
            try
            {
                if (NewGame.Photos != null)
                {
                    List<PhotoDTO> Photos = (NewGame.Photos as List<PhotoDTO>);

                    if (Photos[0] != null)
                    {
                        Screenshot1 = Photos[0].Photo;
                    }
                    if (Photos[1] != null)
                    {
                        Screenshot2 = Photos[1].Photo;
                    }
                    if (Photos[2] != null)
                    {
                        Screenshot3 = Photos[2].Photo;
                    }
                }
            }
            catch { }
        }

        public ICommand UploadCoverCommand { get; set; }
        public ICommand AddSystemRequirementsCommand { get; set; }
        public ICommand UploadScreenshot1 { get; set; }
        public ICommand UploadScreenshot2 { get; set; }
        public ICommand UploadScreenshot3 { get; set; }
    }
}
