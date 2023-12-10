using GreenThumb.Database;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new();
            registerWindow.Show();
            Close();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            string username = txtUsername.Text;
            string password = txtPassword.Password;
            if (txtUsername.Text == string.Empty || txtPassword.Password == string.Empty)
            {
                MessageBox.Show("Please enter both username and password", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
            else if (uow.UserRepository.SignInUser(username, password))
            {
                PlantWindow plantWindow = new(uow.UserRepository.SignedInUser);
                plantWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("User does not exist!", "Warning", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }
    }
}
