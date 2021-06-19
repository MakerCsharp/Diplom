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

namespace Проект.VIEW.REGISTRATION
{
    /// <summary>
    /// Логика взаимодействия для PageRegStuff.xaml
    /// </summary>
    public partial class PageRegStuff : Page
    {
        DATABASE_CONNECTION.Stuff Stuff = new DATABASE_CONNECTION.Stuff();
        DATABASE_CONNECTION.DataBaseSaleTovar3Entities data = new DATABASE_CONNECTION.DataBaseSaleTovar3Entities();
        public PageRegStuff()
        {
            InitializeComponent();
            DataContext = Stuff;
            combRole.ItemsSource = data.RoleUser.Where(x=>x.idRole!=2).ToList();
            combSex.ItemsSource = data.Sex.ToList();
            DateClient.SelectedDate = DateTime.Now;
        }

        private void btnSaveClient(object sender, RoutedEventArgs e)
        {
            if (Stuff.Name == null && Stuff.SerName == null
               && Stuff.Patronym == null && Stuff.PhoneNumber == null
               && Stuff.Adress == null  && Stuff.Login == null && Stuff.Password == null)
            {
                NameClient.BorderBrush = Brushes.Red;
                //---
                LastNameClient.BorderBrush = Brushes.Red;
                //---
                SecondNameClient.BorderBrush = Brushes.Red;
                PhoneNumber.BorderBrush = Brushes.Red;
                //---
                DateClient.BorderBrush = Brushes.Red;
                //---
                AdressClient.BorderBrush = Brushes.Red;
                //---
                combRole.BorderBrush = Brushes.Red;
                combSex.BorderBrush = Brushes.Red;
                //---
                LoginUSer.BorderBrush = Brushes.Red;
                //---
                Password.BorderBrush = Brushes.Red;
                //---
                Password.BorderBrush = Brushes.Red;
                //---
                RePassword.BorderBrush = Brushes.Red;
                //---
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Заполните все поля"));
                return;
            }
            if (Stuff.Name== null)
            {
                NameClient.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите имя"));
                return;
            }
            if (Stuff.SerName == null)
            {
                SecondNameClient.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите фамилию"));
                return;
            }
            if (Stuff.Patronym == null)
            {
                LastNameClient.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите отчество"));
                return;
            }
            if (Stuff.PhoneNumber == null)
            {
                PhoneNumber.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите номер телефона"));
                return;
            }
            if (Stuff.Login == null)
            {
                LoginUSer.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите Login"));
                return;
            }
            if (Stuff.Password == null)
            {
                Password.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите Пароль"));
                return;
            }
            if (Stuff.RoleUser == null)
            {

                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите должность сотрудника"));
                return;

            }
            if (Stuff.Login != null)
            {
                var s = Stuff.Login;

                if (data.Client.Where(x => x.Login == s).Any())
                {
                    var messageQueue = SnakBar.MessageQueue;
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Такой пользователь уже зарегистрирован "));
                    return;
                }
            }
            if (Stuff.Password != null)
            {
                if (string.IsNullOrEmpty(RePassword.Text))
                {
                    RePassword.BorderBrush = Brushes.Red;
                     var messageQueue = SnakBar.MessageQueue;
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Введите поторно пароль"));
                    return;
                }
                if (Password.Text != RePassword.Text)
                {
                    var messageQueue = SnakBar.MessageQueue;
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Пароли не совпадают"));
                    return;
                }
                if (Password.Text.Length < 8)
                {

                    var messageQueue = SnakBar.MessageQueue;
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Пароль должен быть больше 8 символов"));
                    return;
                }
                var s = Password.Text;

                if (data.Client.Where(x => x.Password == s).Any())
                {
                    var messageQueue = SnakBar.MessageQueue;
                    Task.Factory.StartNew(() => messageQueue.Enqueue("Введите другой пароль "));
                    return;
                }
            }
            

            if (Stuff.Sex1 == null)
            {
                combSex.BorderBrush = Brushes.Red;
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("Введите ваш пол "));
                return;
            }
            if (Stuff.idStuff == 0)
            {
                data.Stuff.Add(Stuff);
                data.SaveChanges();
                var messageQueue = SnakBar.MessageQueue;
                Task.Factory.StartNew(() => messageQueue.Enqueue("пользователь добавлен"));
            }
        }

        private void showName(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NameClient.Text) != null)
            {
                NameClient.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void showSername(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(SecondNameClient.Text) != null)
            {
                SecondNameClient.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void showPhone(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(PhoneNumber.Text) != null)
            {
                PhoneNumber.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void showDate(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(DateClient.Text) != null)
            {
                DateClient.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }

        }

        private void showAdress(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(AdressClient.Text) != null)
            {
                AdressClient.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void Showgender(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(combSex.Text) != null)
            {
                combSex.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void Showrole(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(combRole.Text))
            {
                combRole.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void ShowLogin(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LoginUSer.Text) != null)
            {
                LoginUSer.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void ShowPassword(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Password.Text) != null)
            {
                Password.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }

        private void ShowrePassword(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(RePassword.Text) != null)
            {
                RePassword.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
            else
            {
                RePassword.BorderBrush = Brushes.Red;
            }
        }

        private void showLastname(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(LastNameClient.Text) != null)
            {
                LastNameClient.BorderBrush = new SolidColorBrush(Color.FromRgb(33, 150, 243));
            }
        }
    }
}
