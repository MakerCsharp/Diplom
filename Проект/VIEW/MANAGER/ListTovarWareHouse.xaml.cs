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
    /// Логика взаимодействия для ListTovarWareHouse.xaml
    /// </summary>
    public partial class ListTovarWareHouse : Page
    {
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        public ListTovarWareHouse()
        {
            InitializeComponent();
            listTovarWarehouse.ItemsSource = data.Tovar.ToList();
        }

        private void TovarWareHouse(object sender, TextChangedEventArgs e)
        {
            listTovarWarehouse.ItemsSource = data.Tovar.Where(x=>x.NameTovar.Contains(txbSearchTovar.Text)).ToList();
        }
    }
}
