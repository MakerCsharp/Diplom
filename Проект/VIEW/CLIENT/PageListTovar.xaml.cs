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
    public partial class PageListTovar : Page
    {
        Проект.DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        DATABASE_CONNECTION.Client client1;

        public PageListTovar(DATABASE_CONNECTION.Client client)
        {
           
            client1 = client;
            InitializeComponent();


            lvListTovars.ItemsSource = data.Tovar.Where(x => x.CountTovarWareHoue > 0).ToList();

        }
      
        private void NameListTovarMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            var selectTovar = lvListTovars.SelectedItem as DATABASE_CONNECTION.Tovar;
            bool statustovar = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idTovar == selectTovar.idTovar && x.idStatus == 1).Any();
            var order = new DATABASE_CONNECTION.OrderUser();
            if (statustovar == true)
            {
                var user = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idTovar == selectTovar.idTovar && x.idStatus == 1).FirstOrDefault();
                user.CountTovar = user.CountTovar + 1;
                data.SaveChanges();
            }
            if (statustovar == false)
            {
                order.idUser = client1.idUser;
                order.idTovar = selectTovar.idTovar;
                order.idStatus = 1;
                order.CountTovar = 1;
                data.OrderUser.Add(order);
                data.SaveChanges();
            }
            var messageQueue = SnakBar.MessageQueue;
            lvListTovars.ItemsSource = data.Tovar.Where(x => x.CountTovarWareHoue > 0).ToList();
            Task.Factory.StartNew(() => messageQueue.Enqueue("Товар добавлен в корзину "));

        }

        private void showTovar(object sender, TextChangedEventArgs e)
        {
            lvListTovars.ItemsSource = data.Tovar.Where(x => x.CountTovarWareHoue > 0).Where(x=>x.NameTovar.Contains(SerchTovar.Text)).ToList();
        }
    }
}
