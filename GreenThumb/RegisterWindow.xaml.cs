using GreenThumb.Database;
using GreenThumb.Models;
using System.Collections.Generic;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            string username = txtUsername.Text;

            List<User> users = uow.UserRepository.GetAll();

            foreach (User user in users)
            {
                if (user.Username == username)
                {
                    MessageBox.Show("Username already taken!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                    break;
                }
                else
                {
                    User newUser = new()
                    {
                        Username = txtUsername.Text,
                        Password = txtPassword.Password
                    };

                    uow.UserRepository.Add(newUser);
                    uow.Complete();

                    MainWindow mainWindow = new();
                    mainWindow.Show();
                    Close();
                }
            }

        }
    }
}
