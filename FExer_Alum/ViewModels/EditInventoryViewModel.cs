using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    class EditInventoryViewModel: NotifyPropertyChanged
    {
        public ICommand SaveChangesCommand1 { get; set; }
        public ICommand CancelChangesCommand { get; set; }

        private Component _selectedItem;
        public string? _newName;
        public string? _newBrand;
        public string? _newModel;
        public double _newPrice;
        public Category? _newCategory;
        public int? _newQuantity;

        public Component SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }

        public string? NewName
        {
            get { return _newName; }
            set
            {
                _newName = value;
                OnPropertyChanged(nameof(NewName));
            }
        }

        public string? NewBrand
        {
            get { return _newBrand; }
            set
            {
                _newBrand = value;
                OnPropertyChanged(nameof(NewBrand));
            }
        }

        public string? NewModel
        {
            get { return _newModel; }
            set
            {
                _newModel = value;
                OnPropertyChanged(nameof(NewModel));
            }
        }

        public double NewPrice
        {
            get { return _newPrice; }
            set
            {
                _newPrice = value;
                OnPropertyChanged(nameof(NewPrice));
            }
        }

        public Category? NewCategory
        {
            get { return _newCategory; }
            set
            {
                _newCategory = value;
                OnPropertyChanged(nameof(NewCategory));
            }
        }
        public IEnumerable<Category> CategoryOptions
        {
            get { return Enum.GetValues(typeof(Category)).Cast<Category>(); }
        }

        public int? NewQuantity
        {
            get { return _newQuantity; }
            set
            {
                _newQuantity = value;
                OnPropertyChanged(nameof(NewQuantity));
            }
        }

        public EditInventoryViewModel(Component selectedItem)
        {
            SelectedItem = selectedItem;
            NewName = selectedItem.ComponentName;
            NewBrand = selectedItem.ComponentBrand;
            NewModel = selectedItem.ComponentModel;
            NewPrice = selectedItem.ComponentPrice;
            NewCategory = selectedItem.ComponentCategory;
            NewQuantity = selectedItem.ComponentQuantity;

            SaveChangesCommand1 = new RelayCommand(SaveChanges, CanSaveChanges);
            CancelChangesCommand = new RelayCommand(CancelChanges, CanCancelChanges);
        }

        private void SaveChanges(object obj)
        {
            InventoryManagement.EditInventory(SelectedItem, NewName, NewBrand, NewModel, NewPrice, NewCategory, NewQuantity);

            string message = $"Changes saved!";
            string caption = "Information";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Information;
            MessageBox.Show(message, caption, button, icon);

            var editComponentWin = obj as Window;
            editComponentWin.Close();
        }

        private void CancelChanges(object obj)
        {
            throw new NotImplementedException();
        }

        private bool CanSaveChanges(object obj)
        {
            return true;
        }

        private bool CanCancelChanges(object obj)
        {
            return true;
        }
    }
}
