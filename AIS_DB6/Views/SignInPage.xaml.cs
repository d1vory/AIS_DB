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

namespace AIS_DB6.Views
{
    /// <summary>
    /// Логика взаимодействия для SignInPage.xaml
    /// </summary>
    public partial class SignInPage : Page
    {
        public SignInPage()
        {
            InitializeComponent();
        }

        private void SignInBt_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBLogin.Text) ||
                String.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
           
            // todo switch to main window

            if (TBLogin.Text.Equals("admin") && PBPassword.Password.Equals("admin"))
            {
                NavigationService.Navigate(new AdminMainPage());
                //navigate to admin page

            }
            else
            {
                if (TBLogin.Text.Equals("director") && PBPassword.Password.Equals("director"))
                {
                    //navigate to director page
                    NavigationService.Navigate(new DirectorPage());
                }
                else
                {
                    MessageBox.Show("Wrong login or password!");
                }

            }
            

           
        }

        private void CancelBt_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0); // Application.Close(); MainWindow.Close();
        }

        private void SignUpBt_OnClick(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TBLogin.Text) ||
                String.IsNullOrWhiteSpace(PBPassword.Password))
            {
                MessageBox.Show("Login or password is empty!");
                return;
            }
            MessageBox.Show($"User with name {TBLogin.Text} was created");
            // todo switch to main window
        }
    }
}
