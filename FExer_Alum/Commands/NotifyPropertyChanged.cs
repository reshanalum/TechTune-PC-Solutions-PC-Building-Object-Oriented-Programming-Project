using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using FINALPROJECT_OOP_ALUM.ViewModels;

namespace FINALPROJECT_OOP_ALUM.Commands
{
    public class NotifyPropertyChanged: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)  PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
