using GreenThumb.Database;
using GreenThumb.Models;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for PlantDetailsWindow.xaml
    /// </summary>
    public partial class PlantDetailsWindow : Window
    {
        User _currentUser;
        Plant _selectedPlant;
        public PlantDetailsWindow(User user, Plant selectedPlant)
        {
            InitializeComponent();

            _currentUser = user;
            _selectedPlant = selectedPlant;

            GreenThumbDbContext context = new();
            GreenThumbUow uow = new(context);

            txtName.Text = selectedPlant.Name;
            txtDescription.Text = selectedPlant.Description;
            txtFamily.Text = selectedPlant.Family;

            // Get all the instructions from the selected plant 
            var instructions = uow.InstructionRepository.GetAllWithPlantId(selectedPlant.PlantId);

            foreach (var instruction in instructions)
            {
                ListViewItem item = new();
                item.Tag = instruction;
                item.Content = $"{instruction.InstructionType} | {instruction.Description}";
                lstInstructions.Items.Add(item);
            }

        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            PlantWindow plantWindow = new(_currentUser);
            plantWindow.Show();
            Close();
        }
    }
}
