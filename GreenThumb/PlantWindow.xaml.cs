using GreenThumb.Models;
using System.Windows;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantWindow.xaml
    /// </summary>
    public partial class PlantWindow : Window
    {
        User _currentUser;
        public PlantWindow(User user)
        {
            _currentUser = user;
            InitializeComponent();

            lblUsername.Content = user.Username;
        }
    }
}
