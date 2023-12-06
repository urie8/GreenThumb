using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

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
            UpdateUi();

        }

        public void UpdateUi()
        {
            lstPlants.Items.Clear();
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);


            var plants = uow.PlantRepository.GetAll();

            foreach (var plant in plants)
            {
                ListViewItem item = new();
                item.Tag = plant;
                item.Content = plant.Name;
                lstPlants.Items.Add(item);
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            lstPlants.Items.Clear();

            string plantName = txtSearchbar.Text;

            var searchedPlant = uow.PlantRepository.GetByName(plantName);

            ListViewItem item = new();
            item.Tag = searchedPlant;
            item.Content = searchedPlant.Name;
            lstPlants.Items.Add(item);

        }
    }
}
