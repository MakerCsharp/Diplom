using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Проект.VIEW.MANAGER
{
    /// <summary>
    /// Логика взаимодействия для PageStatistics.xaml
    /// </summary>
    public partial class PageStatistics : Page
    {
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();


        public PageStatistics()
        {
           
            InitializeComponent();
            //StatiscticsSold.ChartAreas.Add(new ChartArea("Graph"));
           

            //var serios = new Series("Payments")
            //{

            //    IsValueShownAsLabel = true

            //};

            //StatiscticsSold.Series.Add(serios);
            //comboboxTypeDiogram.ItemsSource = Enum.GetValues(typeof(SeriesChartType));
        }

        private void UpdateChart(object sender, SelectionChangedEventArgs e)
        {
            //if (comboboxTypeDiogram.SelectedItem is SeriesChartType seriesChartType)
            //{
            //    Series currentserios = StatiscticsSold.Series.FirstOrDefault();
            //    currentserios.ChartType = seriesChartType;
            //    currentserios.Points.Clear();
            //    #region tovarsold 
            //    var tovarsold = (from OrderUser in data.OrderUser
            //                     group new { OrderUser.Tovar, OrderUser } by new
            //                     {
            //                         OrderUser.Tovar.idTovar,
            //                         OrderUser.Tovar.NameTovar
            //                     } into g
            //                     select new
            //                     {
            //                         g.Key.idTovar,
            //                         Column1 =(string)g.Key.NameTovar,
            //                         Column2 = (int?)g.Sum(p => p.OrderUser.CountTovar),
            //                         Column3 = (decimal?)g.Sum(p => p.OrderUser.Tovar.CostTovar)
            //                     }).ToList();
            //    #endregion

            //    foreach (var s in tovarsold)
            //    {
            //        currentserios.Points.AddXY(s.Column1, data.OrderUser.Where(x=>x.idTovar == s.idTovar).Sum(x=>x.CountTovar)) ;
            //    }
            //}
        }
    }
}
