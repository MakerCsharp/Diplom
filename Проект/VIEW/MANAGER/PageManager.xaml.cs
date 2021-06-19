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

namespace Проект.VIEW.MANAGER
{
    /// <summary>
    /// Логика взаимодействия для PageManager.xaml
    /// </summary>
    public partial class PageManager : Page
    {
        public PageManager()
        {
            InitializeComponent();
            Проект.CLAS.ClassFrameView.frameUserMenu = Stufflist;
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.MANAGER.PageDeliveryTovar());
            
        }

        private void btnShowDelivery(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.MANAGER.PageDeliveryTovar());
        }

        private void btnShowSupplier(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.MANAGER.PageListSupplier());
        }

        private void btnShowListTovarWareHouse(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate( new Проект.VIEW.MANAGER.ListTovarWareHouse());
        }

        private void btnShowStuff(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate( new Проект.VIEW.MANAGER.PageStuff());
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.AUTHORIZATION.authorization());
        }

        private void btnAddStuff(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate( new Проект.VIEW.REGISTRATION.PageRegStuff());
        }

        private void BtnShowStatisticsTovarSold(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.MANAGER.PageStatistics());
        }
    }
}
