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
using WpfApp1.ClassApp;

namespace WpfApp1.VisualApp
{
    /// <summary>
    /// Логика взаимодействия для PageLogin.xaml
    /// </summary>
    public partial class PageLogin : Page
    {
        public PageLogin()
        {
            InitializeComponent();
        }

        private void CLEventGoReg(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new PageReg());
        }

        private void ClEventGoLogin(object sender, RoutedEventArgs e)
        {

            if (TxtLogin.Text != "" && TxtPassword.Password != "")
            {
                var _user = App.Connection.Users.Where(z => z.Login == TxtLogin.Text && z.Pass == TxtPassword.Password).FirstOrDefault();
                if (_user != null)
                {
                    MessageBox.Show($"Доброго времени суток \n{_user.Name}");
                    ClassCorr.corrUser=_user;
                    NavigationService.Navigate(new PageMenu());

                }
            }
            else
            {
                MessageBox.Show("Не все поля заполнены");
            }
        }
    }
}
