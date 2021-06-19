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

namespace Проект
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Проект.CLAS.ClassFrameView.frameUser = frameWindow;
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.AUTHORIZATION.authorization());
            //Проект.CLAS.ClassFrameView.snackbar = SnakBar;
        }

        private void borMouseMove(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

     

        private void btnClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
         
        }
    }
}
