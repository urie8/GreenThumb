using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for MyGardenWindow.xaml
    /// </summary>
    public partial class MyGardenWindow : Window
    {
        User _currentUser;
        public MyGardenWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
            UpdateUi();
            lblUsername.Content = user.Username;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(_currentUser);
            plantWindow.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;

            GardenPlants selectedGardenPlant = (GardenPlants)selectedItem.Tag;

            uow.GardenPlantsRepository.DeleteCompositeKey(selectedGardenPlant.GardenId, selectedGardenPlant.PlantId);
            uow.Complete();
            UpdateUi();

        }
        public void UpdateUi()
        {
            lstPlants.Items.Clear();
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            // Gets the garden from current users user id
            Garden userGarden = uow.GardenRepository.GetByUserId(_currentUser.UserId);

            // Creates a list of gardenplants from the users garden including the plants
            var userGardenPlants = uow.GardenPlantsRepository.GetByGardenIdWithPlants(userGarden.GardenId);

            foreach (var gardenPlant in userGardenPlants)
            {
                ListViewItem item = new();
                item.Tag = gardenPlant;
                item.Content = gardenPlant.Plant.Name;
                lstPlants.Items.Add(item);
            }
        }
    }
}