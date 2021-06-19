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
using System.Windows.Forms;

namespace Проект.VIEW.AUTHORIZATION
{
    /// <summary>
    /// Логика взаимодействия для authorization.xaml
    /// </summary>
    public partial class authorization : Page
    {

        
        public authorization()
        {
            InitializeComponent();
        }
        private void btnEnterUser(object sender, RoutedEventArgs e)
        {
            #region
            //var s =  Проект.CLAS.ClassFrameView.snackbar.MessageQueue;
            Проект.DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
            var enterUser = data.Client.Where(x => x.Login == txblogin.Text && x.Password == txbPAssword.Password).FirstOrDefault();
            #endregion
            if (string.IsNullOrEmpty(txbPAssword.Password) && string.IsNullOrEmpty(txblogin.Text))
            {
                txbPAssword.BorderBrush = Brushes.Red;
                txblogin.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Заполните все поля"));
                return;
            }
            if (string.IsNullOrEmpty(txbPAssword.Password))
            {
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введеите пароль"));
            }
            if (string.IsNullOrEmpty(txblogin.Text))
            {
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введеите логин"));
            }
            if (enterUser!=null)
            {
                Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.CLIENT.PageClient(enterUser));

                //Task.Factory.StartNew(() => s.Enqueue("Добро пожаловать"));
            }
            if (enterUser == null)
            {
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Пользователь ненайден"));
            }
        }

        private void btnAuthorizationStuff(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.AUTHORIZATION.authorizationStuff());
        }

        private void btnAddClient(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.REGISTRATION.PageRegistrationClient());
        }

        private void textupdate(object sender, TextChangedEventArgs e)
       {
            if (string.IsNullOrEmpty(txblogin.Text))
            {
                txblogin.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(txblogin.Text)!=null)
            {

                txblogin.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243) );

            }
        }

        private void paswordUpdate(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txbPAssword.Password))
            {
                txbPAssword.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(txbPAssword.Password) != null)
            {

                txbPAssword.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));

            }
        }
    }
}
