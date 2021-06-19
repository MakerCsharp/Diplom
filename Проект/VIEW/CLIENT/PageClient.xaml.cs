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

namespace Проект.VIEW.CLIENT
{
    /// <summary>
    /// Логика взаимодействия для PageListTovar.xaml
    /// </summary>
    public partial class PageClient : Page
    {
        DATABASE_CONNECTION.Client client;
        public PageClient()
        {
            InitializeComponent();

            
        }
        public PageClient(DATABASE_CONNECTION.Client enterUser):this()
        {
            client = enterUser;
            Проект.CLAS.ClassFrameView.frameUserMenu = ListUser;
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.CLIENT.PageListTovar(client));

        }
        private void btnShowTovar(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.CLIENT.PageListTovar(client));
        }

        private void btnhShowBasket(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.CLIENT.PageBasketClient(client));
        }

        private void HamburgerMenu_ViewStateChanged(object sender, DevExpress.Xpf.WindowsUI.HamburgerMenuViewStateChangedEventArgs e)
        {
            MessageBox.Show("Привет");
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.AUTHORIZATION.authorization());
        }

       
    }
}
