using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Логика взаимодействия для PageListOrder.xaml
    /// </summary>
    public partial class PageListOrder : Page
    {

        DATABASE_CONNECTION.Stuff stuff1;
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        public PageListOrder(DATABASE_CONNECTION.Stuff stuff)
        {
            InitializeComponent();
            stuff1 = stuff;
            listOrder.ItemsSource = ListORDEUsers(status:2).ToList();

     
        }
        private void btnClickShow(object sender, MouseButtonEventArgs e)
        {
            var showOrderTovar = (listOrder.SelectedItem as DATABASE_CONNECTION.SHOW_Users_by);
            if (showOrderTovar == null)
            {
                return;
            }
            var showlistorder = data.OrderUser.Where(x => x.idUser == showOrderTovar.idUser && x.idStatus == 2);
            foreach (DATABASE_CONNECTION.OrderUser order in showlistorder)
            {
                order.idStuff = stuff1.idStuff;
            }
            data.SaveChanges();
            Проект.CLAS.ClassFrameView.frameUserMenu.Navigate(new Проект.VIEW.Saler.PageListTovarOrder(stuff:stuff1,user:showOrderTovar));
        }
        private List<DATABASE_CONNECTION.SHOW_Users_by> ListORDEUsers(int status, int? stuff = null)
        {
            if (stuff == null)
            {
                var listTovarUsers = data.Database.SqlQuery<DATABASE_CONNECTION.SHOW_Users_by>(" exec [dbo].[Procedure_get_listovar] @status ", new SqlParameter("@status", status)).ToList();
                return listTovarUsers;
            }
            if (stuff != null)
            {
                var listTovarUsers = data.Database.SqlQuery<DATABASE_CONNECTION.SHOW_Users_by>(" exec [dbo].[Procedure_get_listovar] @status,@staff", new SqlParameter("@status", status), new SqlParameter("@staff", stuff)).ToList();
                return listTovarUsers;
            }
            throw null;
        }

        private void btnOrderShow(object sender, RoutedEventArgs e)
        {

            listOrder.ItemsSource = ListORDEUsers(status: 2).ToList();
        }

        private void btnYourOrderShow(object sender, RoutedEventArgs e)
        {
            listOrder.ItemsSource = ListORDEUsers(status: 2, stuff: stuff1.idStuff).ToList();
        }
    }
}
