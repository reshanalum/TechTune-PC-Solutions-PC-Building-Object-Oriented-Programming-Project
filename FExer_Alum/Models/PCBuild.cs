using FINALPROJECT_OOP_ALUM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public class PCBuild: NotifyPropertyChanged
    {
        public string _id;
        public string? _name;
        public List<Component> _components;
        public double? _totalPrice;

        public string? ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        public string? Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public List<Component>? Components
        {
            get { return _components; }
            set
            {
                _components = value;
                OnPropertyChanged(nameof(Components));
            }
        }

        public double? TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged(nameof(TotalPrice));
            }
        }
        public PCBuild(string id, string? name, List<Component> components, double? totalPrice)
        {
            ID = id;
            Name = name;
            Components = components;
            TotalPrice = totalPrice;
        }

    }
}
