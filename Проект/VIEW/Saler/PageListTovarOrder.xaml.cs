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
    /// Логика взаимодействия для PageListTovarOrder.xaml
    /// </summary>
    public partial class PageListTovarOrder : Page
    {
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        DATABASE_CONNECTION.OrderUser order;
        DATABASE_CONNECTION.Stuff stuff1;
        DATABASE_CONNECTION.SHOW_Users_by user1;
        public PageListTovarOrder(DATABASE_CONNECTION.SHOW_Users_by user , DATABASE_CONNECTION.Stuff stuff)
        {
            InitializeComponent();
            user1 = user;
            stuff1 = stuff;
            listtovarView.ItemsSource = data.OrderUser.Where(x => x.idUser == user.idUser && x.idStatus == 2 ).ToList();
        }

        private void btnCompliteOrder(object sender, RoutedEventArgs e)
        {
            var user = data.OrderUser.Where(x => x.idUser == user1.idUser && x.idStatus == 2);
            DATABASE_CONNECTION.Invoice invoice = new DATABASE_CONNECTION.Invoice();
            Проект.VIEW.CHECK.WindowCheck check = new CHECK.WindowCheck(stuff1,user1);
            check.Show();
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.Saler.PageListOrder(stuff1));
        }

        private void Clikcbtnplus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            order = button.DataContext as DATABASE_CONNECTION.OrderUser;
            var userorder = data.OrderUser.Where(x => x.idOrder == order.idOrder).FirstOrDefault();
            userorder.CountTovar = userorder.CountTovar + 1;
            data.SaveChanges();
            listtovarView.ItemsSource = data.OrderUser.Where(y => y.idUser == user1.idUser && y.idStatus == 2).ToList();
        }

        private void ClikcbtnMinus(object sender, RoutedEventArgs e)
        {
            Button btnPlus = sender as Button;
            order = btnPlus.DataContext as DATABASE_CONNECTION.OrderUser;
            var userorder = data.OrderUser.Where(x => x.idOrder == order.idOrder).FirstOrDefault();
            if (userorder.CountTovar - 1 <= 0)
            {
                var datas = MessageBox.Show("Удалить товар?", "Информация", MessageBoxButton.YesNo);
                if (datas == MessageBoxResult.Yes)
                {
                    DATABASE_CONNECTION.OrderUser user = data.OrderUser.Where(x => x.idOrder == order.idOrder).FirstOrDefault();
                    user.idStatus = 3;
                    user.DataComplite = DateTime.Now;
                    data.SaveChanges();
                    listtovarView.ItemsSource = data.OrderUser.Where(y => y.idUser == user1.idUser && y.idStatus == 2).ToList();
                }
                return;
            }
            userorder.CountTovar = userorder.CountTovar - 1;
            data.SaveChanges();
            listtovarView.ItemsSource = data.OrderUser.Where(y => y.idUser == user1.idUser && y.idStatus == 2).ToList();
        }
    }
}
