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
using System.Windows.Shapes;

namespace Проект.VIEW.CHECK
{
    /// <summary>
    /// Логика взаимодействия для WindowCheck.xaml
    /// </summary>
    public partial class WindowCheck : Window
    {
        DATABASE_CONNECTION.Invoice invoice1;
        DATABASE_CONNECTION.Stuff stuff1;
        DATABASE_CONNECTION.SHOW_Users_by user1;
        DateTime date_time = DateTime.Now;

        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();


        public WindowCheck(DATABASE_CONNECTION.Stuff stuff,DATABASE_CONNECTION.SHOW_Users_by user)
        {
            InitializeComponent();
            ///Параметры 
            stuff1 = stuff;
            user1 = user;

            ///Параметры 
            DATABASE_CONNECTION.Invoice invoice2 = new DATABASE_CONNECTION.Invoice();
            invoice2.idSuppler = stuff1.idStuff;
            invoice2.idUser = user1.idUser;
            invoice2.StatusInvoce = 1;
            invoice2.DataComplite = date_time;
            invoice2.FinalCost = data.VIEW_Tovar_status_2.Where(x => x.idUser == user1.idUser).Sum(x => x.Sum);
            data.Invoice.Add(invoice2);
            data.SaveChanges();
            invoice1 = invoice2;
            //// вывод изображение на  окно чека 
            SHOWVIEW();
        }

        private void btnPrintInvoce(object sender, RoutedEventArgs e)
        {

            this.Close();
            var user = data.OrderUser.Where(y => y.idUser == user1.idUser && y.idStatus == 2);
            foreach (DATABASE_CONNECTION.OrderUser order in user)
            {
                order.idStatus = 4;
                order.DataComplite = Convert.ToDateTime(dateComplite.Text);
                order.Invoce = invoice1.idInvoce;
                //data.Invoice.Where(y => y.idUser == user1.idUser && y.StatusInvoce == 1 &&
                //y.idSuppler == stuff1.idStuff).Select(x => x.idInvoce).FirstOrDefault();
                var s = data.Tovar.Where(x => x.idTovar == order.idTovar).FirstOrDefault();
                s.CountTovarWareHoue = s.CountTovarWareHoue - order.CountTovar;
            }

            var invocseinsertdata = invoice1;
            invocseinsertdata.StatusInvoce = 2;
            data.SaveChanges();

            PrintDialog prints = new PrintDialog();
            if (prints.ShowDialog() == true)
            {
                prints.PrintVisual(WindowsViewPrint, "invoce");
            }
        }
        public void SHOWVIEW()
        {
            listviewtovarUserBasket.ItemsSource = data.VIEW_Tovar_status_2.Where(x => x.idUser == user1.idUser && x.idStatus == 2).ToList();
            numberinvoce.Text = data. Invoice.Where(y => y.idUser == user1.idUser && y.StatusInvoce == 1 && y.idSuppler == stuff1.idStuff).Select(x => x.idInvoce).FirstOrDefault().ToString();
            txbCost.Text = data.VIEW_Tovar_status_2.Where(y => y.idUser == user1.idUser).Sum(x => x.Sum).ToString();
            decimal shows = (decimal)data.VIEW_Tovar_status_2.Where(y => y.idUser == user1.idUser).Sum(x => x.Sum);
            txbCostTax.Text = Convert.ToString((shows + ((shows * 20) / 100)));
            txbCostTax.Text = Convert.ToString((shows + ((shows * 20) / 100)));
            dateComplite.Text = date_time.ToString("f");
        }









    }
}
