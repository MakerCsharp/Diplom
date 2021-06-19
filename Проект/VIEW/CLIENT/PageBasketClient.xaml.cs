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
    /// Логика взаимодействия для PageBasketClient.xaml
    /// </summary>
    public partial class PageBasketClient : Page
    {
        Проект.DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        DATABASE_CONNECTION.Client client1;
        public PageBasketClient(DATABASE_CONNECTION.Client client)
        {
            InitializeComponent();
            client1 = client;


            var order= data.OrderUser.Where(x => x.idUser == client.idUser && x.idStatus == 1).ToList();
            if (order.Sum(x => x.Tovar.CostTovar * x.CountTovar) == 0)
            {
                SumTovar.Text = "0,00";

            }
            else
            {
                try
                {
                    SumTovar.Text = order.Sum(x => x.Tovar.CostTovar * x.CountTovar).ToString();
                }
                catch
                {
                    SumTovar.Text = "0";
                }
            }
            ListOrder.ItemsSource = order;
        }

        private void btnPlus(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            DATABASE_CONNECTION.OrderUser orderUser = button.DataContext as DATABASE_CONNECTION.OrderUser;
            var UserPlusData = data.OrderUser.Where(x => x.idOrder == orderUser.idOrder).FirstOrDefault();
            UserPlusData.CountTovar = UserPlusData.CountTovar + 1;
            var order = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idStatus == 1).ToList();
            SumTovar.Text = order.Sum(x => x.Tovar.CostTovar * x.CountTovar+1).ToString();
            var order2 = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idStatus == 1).ToList();
            ListOrder.ItemsSource = order2;
            data.SaveChanges();
        }

        private void btnMinus(object sender, RoutedEventArgs e)
        {
            var order = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idStatus == 1 ).ToList();
            Button button = sender as Button;
            DATABASE_CONNECTION.OrderUser orderUser = button.DataContext as DATABASE_CONNECTION.OrderUser;
            var UserdataMinus = data.OrderUser.Where(x => x.idOrder == orderUser.idOrder).FirstOrDefault();
            int CountTovar = UserdataMinus.CountTovar;
            if (CountTovar-1 <= 0)
            {
                var Message = MessageBox.Show("Удалить товар?", "Информация", MessageBoxButton.YesNo);
                if (Message == MessageBoxResult.Yes)
                {
                    DATABASE_CONNECTION.OrderUser user = data.OrderUser.Where(x => x.idOrder == orderUser.idOrder).FirstOrDefault();
                    user.idStatus = 3;
                    user.DataComplite = DateTime.Now;
                    data.SaveChanges();
                   
                }
            }
            UserdataMinus.CountTovar = UserdataMinus.CountTovar - 1;
            SumTovar.Text = order.Sum(x => x.Tovar.CostTovar * x.CountTovar).ToString();
            ListOrder.ItemsSource = order.Where(x=>x.idStatus==1);
            data.SaveChanges();
        }

        private void ClikcComplitOrder(object sender, RoutedEventArgs e)
        {
            var dataTovar = data.Tovar.ToList();
            var messageQueue = SnakBar.MessageQueue;
            var userdata = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idStatus == 1);
            if (userdata.LongCount()<1)
            {
                Task.Factory.StartNew(() => messageQueue.Enqueue("В корзине нет товаров"));
                return;
            }
            
            foreach(Проект.DATABASE_CONNECTION.OrderUser user in userdata)
            {
                foreach (DATABASE_CONNECTION.Tovar tovar in dataTovar)
                {
                    if (user.idTovar == tovar.idTovar)
                    {
                        
                        if (user.CountTovar>tovar.CountTovarWareHoue)
                        {
                            Task.Factory.StartNew(() => messageQueue.Enqueue($"Количество заказов в корзине больше чем количество товара на складе "));
                            return;
                        }
                    }
                }
            }
           
            foreach (DATABASE_CONNECTION.OrderUser orderUser in userdata)
            {
                orderUser.idStatus = 2;
            }
            data.SaveChanges();
            var order = data.OrderUser.Where(x => x.idUser == client1.idUser && x.idStatus == 1).ToList();
            ListOrder.ItemsSource = order;
            SumTovar.Text = "0,00";
            Task.Factory.StartNew(() => messageQueue.Enqueue("Заказ оформлен"));
        }
    }
}
