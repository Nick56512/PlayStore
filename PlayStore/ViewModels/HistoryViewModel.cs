using PlayStore.BLL.DTO;
using PlayStore.BLL.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlayStore.ViewModels
{
    class HistoryViewModel
    {
        public ObservableCollection<HistoryDTO> History { get; set; }

        HistoryService historyService;
        public HistoryDTO CurrentItem { get; set; }

        public HistoryViewModel(HistoryService historyService)
        {
            this.historyService = historyService;
            History = new ObservableCollection<HistoryDTO>(historyService.GetAll());
        }
    }
}
