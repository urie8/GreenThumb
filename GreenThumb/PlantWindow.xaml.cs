using GreenThumb.Database;
using GreenThumb.Models;
using System.Linq;
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

        // Automatically updates the listview based on the users input in the searchbar
        private void txtSearchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            lstPlants.Items.Clear();
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            // Gets all the plants where the first letter starts with the searchbar input
            var plants = context.Plants.Where(p => p.Name.ToUpper().StartsWith(txtSearchbar.Text.ToUpper())).ToList();

            foreach (var plant in plants)
            {
                ListViewItem item = new();
                item.Tag = plant;
                item.Content = plant.Name;
                lstPlants.Items.Add(item);
            }

        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            AddPlantWindow addPlantWindow = new AddPlantWindow(_currentUser);
            addPlantWindow.Show();
            Close();
        }

        private void btnDetails_Click(object sender, RoutedEventArgs e)
        {
            if (lstPlants.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                Plant selectedPlant = (Plant)selectedItem.Tag;

                PlantDetailsWindow plantDetailsWindow = new(_currentUser, selectedPlant);
                plantDetailsWindow.Show();
                Close();
            }
            else
            {
                MessageBox.Show("No plant selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            if (lstPlants.SelectedItem != null)
            {
                ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
                Plant selectedPlant = (Plant)selectedItem.Tag;

                uow.PlantRepository.Delete(selectedPlant.PlantId);
                uow.Complete();
                UpdateUi();
            }
            else
            {
                MessageBox.Show("No plant selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new();
            mainWindow.Show();
            Close();
        }

        private void btnAddToGarden_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
            Plant selectedPlant = (Plant)selectedItem.Tag;
            Garden userGarden = uow.GardenRepository.GetByUserId(_currentUser.UserId);

            if (lstPlants.SelectedItem != null && !uow.GardenPlantsRepository.GardenPlantExists(userGarden.GardenId, selectedPlant.PlantId))
            {

                GardenPlants newGardenPlant = new()
                {
                    PlantId = selectedPlant.PlantId,
                    GardenId = userGarden.GardenId
                };

                uow.GardenPlantsRepository.Add(newGardenPlant);
                uow.Complete();

                var gardenPlant = uow.GardenPlantsRepository.GetByGardenAndPlantIdIncludePlants(newGardenPlant.GardenId, newGardenPlant.PlantId);

                MessageBox.Show($"{gardenPlant.Plant.Name} was added to your garden!", "Plant added", MessageBoxButton.OK, MessageBoxImage.Exclamation);

            }
            else if (uow.GardenPlantsRepository.GardenPlantExists(userGarden.GardenId, selectedPlant.PlantId))
            {
                MessageBox.Show("You already have this plant in your garden!", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                MessageBox.Show("No plant selected", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
            MyGardenWindow myGardenWindow = new(_currentUser);
            myGardenWindow.Show();
            Close();
        }
    }
}