﻿using GreenThumb.Database;
using GreenThumb.Models;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace GreenThumb
{
    /// <summary>
    /// Interaction logic for AddPlantWindow.xaml
    /// </summary>
    public partial class AddPlantWindow : Window
    {
        User _currentUser;
        public AddPlantWindow(User user)
        {
            InitializeComponent();
            _currentUser = user;
        }

        private void btnAddPlant_Click(object sender, RoutedEventArgs e)
        {
            if (txtName.Text == string.Empty || txtFamily.Text == string.Empty || txtDescription.Text == string.Empty)
            {
                MessageBox.Show("Please enter all the inputs", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                GreenThumbDbContext context = new();
                GreenThumbUow uow = new(context);

                List<Instruction> instructions = new();

                foreach (ListViewItem item in lstInstructions.Items)
                {
                    Instruction instruction = (Instruction)item.Tag;
                    instructions.Add(instruction);
                }

                Plant newPlant = new()
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Family = txtFamily.Text,
                    Instructions = instructions
                };

                // If a plant with the given name already exists a warning is shown
                if (uow.PlantRepository.PLantExists(newPlant.Name))
                {
                    MessageBox.Show("Plant already exists", "Warning", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else
                {
                    uow.PlantRepository.Add(newPlant);
                    uow.Complete();

                    PlantWindow plantWindow = new(_currentUser);
                    plantWindow.Show();
                    Close();
                }
            }
        }

        private void btnAddInstruction_Click(object sender, RoutedEventArgs e)
        {
            if (txtInstructionType.Text == string.Empty || txtInstructionDescription.Text == string.Empty)
            {
                MessageBox.Show("Please enter all the instruction information", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                Instruction newInstrution = new()
                {
                    InstructionType = txtInstructionType.Text,
                    Description = txtInstructionDescription.Text,
                };

                ListViewItem item = new();
                item.Tag = newInstrution;
                item.Content = $"{newInstrution.InstructionType} | {newInstrution.Description}";
                lstInstructions.Items.Add(item);

                txtInstructionType.Clear();
                txtInstructionDescription.Clear();
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