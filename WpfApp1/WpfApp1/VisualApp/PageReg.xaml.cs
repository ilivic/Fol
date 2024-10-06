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
using WpfApp1.AdoAPP;

namespace WpfApp1.VisualApp
{
    /// <summary>
    /// Логика взаимодействия для PageReg.xaml
    /// </summary>
    public partial class PageReg : Page
    {
        public PageReg()
        {
            InitializeComponent();
            CmbRole.ItemsSource = App.Connection.Roles.ToList();
        }

        private void ClEventGoRevers(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ClEventGoReg(object sender, RoutedEventArgs e)
        {
            try
            {
                var _role = (CmbRole.SelectedItem as Roles);
                Users _user = new Users()
                { Login = TxtLogin.Text, Pass = TxtPassword.Password, Name = TxtName.Text, Roles = _role };
                App.Connection.Users.Add(_user);
                App.Connection.SaveChanges();
                MessageBox.Show("Регистрация прошла: \n Успешно", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
                NavigationService.Navigate(new PageLogin());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
