using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Views;
using FINALPROJECT_OOP_ALUM.Models;
using System.Windows;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class PCBuildViewModel : NotifyPropertyChanged
    {
        public ICommand AddCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand ClearSelectedListCommand { get; set; }
        public ICommand ShowPastPCBuildConfigurationsCommand { get; set; }

        private ObservableCollection<Component> _inventory;
        public ObservableCollection<Component> _selectedList;
        public ObservableCollection<PCBuild> _pastPCBuildConfiguration;

        private Component _selectedItem;
        private int _quantity;
        private double _subtotal;
        private double _total;
        public Component component { get; set; }

        public ObservableCollection<Component> Inventory
        {
            get { return _inventory; }
            set
            {
                _inventory = value;
                OnPropertyChanged(nameof(Inventory));
            }
        }

        public ObservableCollection<Component> SelectedList
        {
            get { return _selectedList; }
            set
            {
                _selectedList = value;
                OnPropertyChanged();
                CalculateTotal();
            }
        }

        public ObservableCollection<PCBuild> PastPCBuildConfiguration
        {
            get { return _pastPCBuildConfiguration; }
            set
            {
                _pastPCBuildConfiguration = value;
                OnPropertyChanged(nameof(PastPCBuildConfiguration));
            }
        }

        public Component SelectedItem
        {
            get { return _selectedItem; }
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public int Quantity
        {
            get { return _quantity; }
            set { _quantity = value; OnPropertyChanged(); }
        }

        public double Subtotal
        {
            get { return _total; }
            set{  _total = value;  OnPropertyChanged();}
        }

        public double Total
        {
            get { return Math.Round(_subtotal,2); }
            set { _subtotal = value; OnPropertyChanged();}
        }

        private string GenerateUniqueID()
        {
            Random random = new Random();
            string ID = "";
            for (int i = 0; i < 7; i++)
            {
                int temp = random.Next(0, 10);
                ID += temp.ToString();
            }
            return ID;
        }

        public void CalculateTotal()
        {
            Subtotal = 0;
            for (int i = 0; i < SelectedList.Count; i++) Subtotal += SelectedList[i].ComponentPrice;
            Total = Subtotal;
        }

        public PCBuildViewModel()
        {
            Inventory = InventoryManagement.GetInventory();
            SelectedList = new ObservableCollection<Component>();
            PastPCBuildConfiguration = PCBuildManagement.DatabasePCBuild;

            AddCommand = new RelayCommand(AddToSelected,CanAddToSelected);
            SaveCommand = new RelayCommand(Save, CanSave);
            DeleteCommand = new RelayCommand(Delete, CanDelete);
            ClearSelectedListCommand = new RelayCommand(ClearSelected, CanClearSelected);
            ShowPastPCBuildConfigurationsCommand = new RelayCommand(ShowPastPCBuildConfigurations, CanShowPastPCBuildConfigurations);
        }

        private void AddToSelected(object obj)
        {

            if (SelectedItem != null && SelectedItem.ComponentQuantity > 0)
            {
                // Check if the component is already in the SelectedList
                var existingComponent = SelectedList.FirstOrDefault(c => c.ComponentID == SelectedItem.ComponentID);
                if (existingComponent != null)
                {
                    MessageBox.Show("A component of the same category is already selected.", "Category Limit Reached", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Check if there is already a component of the same category in the SelectedList 
                var sameCategoryComponents = SelectedList.Where(c => c.ComponentCategory == SelectedItem.ComponentCategory).ToList();
                if (sameCategoryComponents.Any())
                {
                    MessageBox.Show("Only one component per category can be selected.", "Category Limit Reached", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Decrease the quantity of the selected item
                if (SelectedItem.ComponentQuantity > 0) SelectedItem.ComponentQuantity--;
                else
                {
                    MessageBox.Show("This item is out of stock.", "Out of Stock", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                // Add the selected item to the SelectedList
                SelectedList.Add(SelectedItem);
                CalculateTotal();
            }
        }

        private void Save(object obj)
        {
            // Check if SelectedList contains components for all categories
            if (SelectedList.Count(component => component.ComponentCategory == Category.CPU) == 0 ||
                SelectedList.Count(component => component.ComponentCategory == Category.GPU) == 0 ||
                SelectedList.Count(component => component.ComponentCategory == Category.RAM) == 0 ||
                SelectedList.Count(component => component.ComponentCategory == Category.SSD) == 0 ||
                SelectedList.Count(component => component.ComponentCategory == Category.Mother_Board) == 0 ||
                SelectedList.Count(component => component.ComponentCategory == Category.PSU) == 0)
            {
                MessageBox.Show("Please select at least one component for each category before saving.", "Missing Components", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            else
            {

                string ID = GenerateUniqueID();
                List<Component> components = new List<Component>();
                components.AddRange(SelectedList);
                PCBuild newPCBuild = new PCBuild(ID, null, components, Total);
                PCBuildManagement.AddPCBuild(newPCBuild);
                SelectedList.Clear();
                Subtotal = 0;
                Total = 0;

            }
        }

        private void Delete(object obj)
        {
            if (SelectedItem != null)
            {
                // Find the selected item in the SelectedList
                var selectedItem = SelectedList.FirstOrDefault(item => item == SelectedItem);

                if (selectedItem != null)
                {
                    // Add one to the quantity in the InventoryList with the same ID
                    var matchingItem = Inventory.FirstOrDefault(item => item.ComponentID == selectedItem.ComponentID);
                    if (matchingItem != null) matchingItem.ComponentQuantity++;

                    SelectedList.Remove(selectedItem);
                    CalculateTotal();// Recalculate total
                }
            }

        }

        private void ClearSelected(object obj)
        {
            foreach (var selectedItem in SelectedList)
            {
                // Find the matching item in the inventory
                var matchingItem = Inventory.FirstOrDefault(inventoryItem => inventoryItem.ComponentID == selectedItem.ComponentID);

                // If a matching item is found, increment its quantity
                if (matchingItem != null) matchingItem.ComponentQuantity++;
            }

            SelectedList.Clear();
            Subtotal = 0;
            Total = 0;
        }

        private void ShowPastPCBuildConfigurations(object obj)
        {
            PastPCBuildConfigurationsWindow pastPCBuildConfigurationWindow = new PastPCBuildConfigurationsWindow();
            pastPCBuildConfigurationWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            pastPCBuildConfigurationWindow.Show();
        }

        private bool CanAddToSelected(object obj)
        {
            return true;
        }

        private bool CanSave(object arg)
        {
            return true;
        }

        private bool CanDelete(object arg)
        {
            return true;
        }

        private bool CanClearSelected(object obj)
        {
            return true;
        }

        private bool CanShowPastPCBuildConfigurations(object obj)
        {
            return true;
        }

    }
}
