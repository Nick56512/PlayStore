using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PlayStore.Infrastructure
{
    public  class Switcher
    {
        public static INavigator ContentArea { get; set; }
        public static void Switch(UserControl page)
        {
            ContentArea.Navigate(page);
        }
        public static void SwitchMenu(UserControl menu)
        {
            ContentArea.NavigateMenu(menu);
        }
    }
}
