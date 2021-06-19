using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Проект.VIEW.Saler
{
    /// <summary>
    /// Логика взаимодействия для PageSaler.xaml
    /// </summary>
    public partial class PageSaler : Page
    {
        DATABASE_CONNECTION.Stuff Stuff1;
        public PageSaler(DATABASE_CONNECTION.Stuff stuff)
        {
            InitializeComponent();
            Stuff1 = stuff;
            Проект.CLAS.ClassFrameView.frameUserMenu = frNavigateSaller;
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.Saler.PageListOrder(Stuff1));
        }

        private void btnShowListOrder(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.Saler.PageListOrder(Stuff1));
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.AUTHORIZATION.authorization());
        }
    }
}
