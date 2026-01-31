using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using FINALPROJECT_OOP_ALUM.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class InventoryManagementViewModel : NotifyPropertyChanged
    {

        public ICommand ShowEditInventoryWindowCommand { get; set; }
        public ICommand ShowAddInventoryWindowCommand { get; set; }
        public ICommand DeleteInventoryCommand {  get; set; }


        private ObservableCollection<Component> _inventory;
        private Component _selectedItem;

        public ObservableCollection<Component> Inventory
        {
            get { return _inventory; }
            set
            {
                _inventory = value;
                OnPropertyChanged(nameof(Inventory));
            }
        }

        public Component SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public InventoryManagementViewModel()
        {
            Inventory = InventoryManagement.GetInventory();
            ShowEditInventoryWindowCommand = new RelayCommand(ShowEditInventoryWindow, CanShowEditInventoryWindow);
            ShowAddInventoryWindowCommand = new RelayCommand(ShowAddInventoryWindow, CanShowAddInventoryWindow);
            DeleteInventoryCommand = new RelayCommand(DeleteInventory, CanDeleteInventory);

        }

        private void ShowAddInventoryWindow(object obj)
        {
            AddInventoryWindow addInventoryWindow = new AddInventoryWindow();
            addInventoryWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            addInventoryWindow.Show();
        }

        private void ShowEditInventoryWindow(object obj)
        {
            EditInventoryWindow editInventoryWindow = new EditInventoryWindow();
            EditInventoryViewModel editInventoryViewModel = new EditInventoryViewModel(SelectedItem); // forda edit 
            editInventoryWindow.DataContext = editInventoryViewModel; //

            editInventoryWindow.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            editInventoryWindow.Show();
        }

        private void DeleteInventory(object obj)
        {
            InventoryManagement.DeleteInventory(SelectedItem);
        }

        private bool CanShowAddInventoryWindow(object obj)
        {
            return true;
        }

        private bool CanShowEditInventoryWindow(object obj)
        {
            return true;
        }
        private bool CanDeleteInventory(object obj)
        {
            return true;
        }

    }

}

