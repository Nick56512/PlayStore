using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlayStore.Infrastructure
{
    public interface INavigator
    {
        void Navigate(UserControl page);
        void NavigateMenu(UserControl menu);

    }
}
