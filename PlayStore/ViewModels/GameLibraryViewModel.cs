using PlayStore.BLL.DTO;
using PlayStore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.ViewModels
{
    class GameLibraryViewModel:BaseNotifyOfPropertyChanged
    {
        ObservableCollection<GameDTO> games;
        public ObservableCollection<GameDTO> Games
        {
            get => games;
            set
            {
                games = value;
                GetInfo();
                NotifyPropertyChanged();
            }
        }
        string info;
        public string Info 
        { 
            get=>info; 
            
            set
            {
                info = value;
                NotifyPropertyChanged();
            }
        }

        public void GetInfo()
        {
            if (!(Games is null))
            {
                if (Games.Count > 0)
                {
                    Info = $"Кол-во игр в вашей библиотеке: {Games.Count}";
                }
                else
                {
                    Info = $"У вас пока нет игр";
                }
            }
            else
                Info= $"У вас пока нет игр";
        }
    }
}
