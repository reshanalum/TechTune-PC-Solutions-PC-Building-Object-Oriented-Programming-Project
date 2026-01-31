using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using FINALPROJECT_OOP_ALUM.Commands;


namespace FINALPROJECT_OOP_ALUM.Models
{
    public enum Category
    {
        CPU, GPU, RAM, SSD, Mother_Board, PSU
    }
    public class Component: NotifyPropertyChanged
    {
        private string? _componentID;
        private string? _componentName;
        private string? _componentBrand;
        private string? _componentModel;
        public double _componentPrice;
        private Category? _componentCategory;
        public string? ComponentID
        {
            get { return _componentID; }
            set
            {
                _componentID = value;
                OnPropertyChanged(nameof(ComponentID));
            }
        }

        public string? ComponentName
        {
            get { return _componentName; }
            set
            {
                _componentName = value;
                OnPropertyChanged(nameof(ComponentName));
            }
        }

        public string? ComponentBrand
        {
            get { return _componentBrand; }
            set
            {
                _componentBrand = value;
                OnPropertyChanged(nameof(ComponentBrand));
            }
        }

        public string? ComponentModel
        {
            get { return _componentModel; }
            set
            {
                _componentModel = value;
                OnPropertyChanged(nameof(ComponentModel));
            }
        }


        public double ComponentPrice
        {
            get { return _componentPrice; }
            set
            {
                _componentPrice = value;
                OnPropertyChanged(nameof(ComponentPrice));
            }
        }

        public Category? ComponentCategory
        {
            get { return _componentCategory; }
            set
            {
                _componentCategory = value;
                OnPropertyChanged(nameof(ComponentCategory));
            }
        }

        private int? _componentQuantity;
        public int? ComponentQuantity
        {
            get { return _componentQuantity; }
            set
            {
                _componentQuantity = value;
                OnPropertyChanged(nameof(ComponentQuantity));
            }
        }

        public Component() { }
        public Component(string?componentID, string? componentName, string? componentBrand, string? componentModel, double componentPrice, Category? componentCategory, int? componentQuantity)
        {
            ComponentID = componentID;
            ComponentName = componentName;
            ComponentBrand = componentBrand;
            ComponentModel = componentModel;
            ComponentPrice = componentPrice;
            ComponentCategory = componentCategory;
            ComponentQuantity = componentQuantity;
        }


    }
}
