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
            ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
            Plant selectedPlant = (Plant)selectedItem.Tag;

            PlantDetailsWindow plantDetailsWindow = new(_currentUser, selectedPlant);
            plantDetailsWindow.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            ListViewItem selectedItem = (ListViewItem)lstPlants.SelectedItem;
            Plant selectedPlant = (Plant)selectedItem.Tag;

            uow.PlantRepository.Delete(selectedPlant.PlantId);
            uow.Complete();
            UpdateUi();
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

            GardenPlants newGardenPlant = new()
            {
                PlantId = selectedPlant.PlantId,
                GardenId = userGarden.GardenId
            };

            uow.GardenPlantsRepository.Add(newGardenPlant);
            uow.Complete();

        }

        private void btnMyGarden_Click(object sender, RoutedEventArgs e)
        {
            MyGardenWindow myGardenWindow = new(_currentUser);
            myGardenWindow.Show();
            Close();
        }
    }
}