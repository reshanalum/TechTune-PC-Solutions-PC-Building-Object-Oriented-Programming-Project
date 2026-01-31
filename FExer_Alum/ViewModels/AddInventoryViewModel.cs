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
    public class AddInventoryViewModel : NotifyPropertyChanged
    {
        //this command represents the action that should be done when the "save" button is clicked
        public ICommand AddComponentCommand { get; set; }
        public ICommand CancelCommand { get; set; }

        private string _componentID;
        private string _componentName;
        private string _componentBrand;
        private string _componentModel;
        private double _componentPrice;
        private Category _componentCategory;
        private int _componentQuantity;

        public List<Category> ECategory { get; } = new List<Category>() { Category.CPU, Category.GPU, Category.RAM, Category.SSD, Category.Mother_Board, Category.PSU };

        public string ComponentID
        {
            get { return _componentID; }
            set { _componentID = value; }
        }

        public string ComponentName
        {
            get { return _componentName; }
            set { _componentName = value; }
        }

        public string ComponentBrand
        {
            get { return _componentBrand; }
            set { _componentBrand = value; }
        }

        public string ComponentModel
        {
            get { return _componentModel; }
            set { _componentModel = value; }
        }

        public double ComponentPrice
        {
            get { return _componentPrice; }
            set { _componentPrice = value; }
        }

        public Category ComponentCategory
        {
            get { return _componentCategory; }
            set { _componentCategory = value; }
        }

        public int ComponentQuantity
        {
            get { return _componentQuantity; }
            set { _componentQuantity = value; }
        }

        private string GenerateComponentID()
        {
            Random random = new Random();
            return random.Next(1000000, 10000000).ToString();
        }

        public AddInventoryViewModel()
        {
            AddComponentCommand = new RelayCommand(AddComponent, CanAddComponent);
            CancelCommand = new RelayCommand(Cancel, CanCancel);

            ComponentID = GenerateComponentID();
        }

        private void AddComponent(object obj)
        {
            Component newComponent = new Component(this.ComponentID, this.ComponentName, this.ComponentBrand, this.ComponentModel, this.ComponentPrice, this.ComponentCategory, this.ComponentQuantity);
            if (newComponent.ComponentQuantity > 0)
            {
                InventoryManagement.AddInventory(newComponent);

                string message = $"{ComponentName} has been added to the database with the ID: {ComponentID} ";
                string caption = "Information";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon);
                var addComponentWindow = obj as Window;
                addComponentWindow.Close();
            }
            else
            {
                string message = $"Product is no longer available ";
                string caption = "Information";
                MessageBoxButton button = MessageBoxButton.OK;
                MessageBoxImage icon = MessageBoxImage.Information;
                MessageBox.Show(message, caption, button, icon);
            }

        }

        private void Cancel(object obj)
        {
            var addComponentWindow = obj as Window;
            addComponentWindow.Close();
        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private bool CanAddComponent(object obj)
        {
            return true;
        }

    }
}

