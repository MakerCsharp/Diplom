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

namespace Проект.VIEW.AUTHORIZATION
{
    /// <summary>
    /// Логика взаимодействия для authorizationStuff.xaml
    /// </summary>
    public partial class authorizationStuff : Page
    {
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        public authorizationStuff()
        {
            InitializeComponent();
        }

        private void btnEnter(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginStuff.Text) && string.IsNullOrEmpty(PasswordStuff.Password))
            {
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Заполните все поля"));
                loginStuff.BorderBrush = Brushes.Red;
                PasswordStuff.BorderBrush = Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(loginStuff.Text))
            {
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите логин"));
                loginStuff.BorderBrush = Brushes.Red;
                return;
            }
            if (string.IsNullOrEmpty(PasswordStuff.Password))
            {

                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите пароль"));
                PasswordStuff.BorderBrush = Brushes.Red;
                return;
            }
            var EnterStuff = data.Stuff.Where(x => x.Login == loginStuff.Text && x.Password == PasswordStuff.Password).FirstOrDefault();
            if (EnterStuff!=null)
            {
                switch (EnterStuff.Role)
                {
                    case 1:
                        Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.Saler.PageSaler(EnterStuff));
                        break;
                    case 2:
                        Проект.CLAS.ClassFrameView.frameUser.Navigate(new Проект.VIEW.MANAGER.PageManager());
                        break;
                }
            }
            if (EnterStuff == null)
            {

                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Сотрудник не найден"));
            }
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Проект.CLAS.ClassFrameView.frameUser.GoBack();
        }

        private void updatetext(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(loginStuff.Text))
            {
                loginStuff.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(loginStuff.Text) != null)
            {

                loginStuff.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));

            }
        }

        private void updatepassword(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(PasswordStuff.Password))
            {
                PasswordStuff.BorderBrush = Brushes.Red;
            }
            if (string.IsNullOrEmpty(PasswordStuff.Password) != null)
            {

                PasswordStuff.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));

            }
        }
    }
}
