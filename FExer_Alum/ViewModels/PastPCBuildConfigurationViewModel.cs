using FINALPROJECT_OOP_ALUM.Commands;
using FINALPROJECT_OOP_ALUM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FINALPROJECT_OOP_ALUM.ViewModels
{
    public class PastPCBuildConfigurationViewModel : NotifyPropertyChanged
    {

        public ICommand CancelCommand { get; set; }

        private PCBuild _selectedPCBuild;
        private ObservableCollection<PCBuild> _pcBuild;

        public PCBuild SelectedPCBuild
        {
            get { return _selectedPCBuild; }
            set
            {
                _selectedPCBuild = value;
                OnPropertyChanged("SelectedPCBuild");
            }
        }

        public ObservableCollection<PCBuild> PCBuild
        {
            get { return _pcBuild; }
            set
            {
                _pcBuild = value;
                OnPropertyChanged(nameof(PCBuild));
            }
        }

        public PastPCBuildConfigurationViewModel()
        {
            PCBuild = PCBuildManagement.DatabasePCBuild;
            CancelCommand = new RelayCommand(Cancel, CanCancel);
        }

        private bool CanCancel(object obj)
        {
            return true;
        }

        private void Cancel(object obj)
        {
            Window PastPCBuildwindow = obj as Window;
            PastPCBuildwindow.Close();
        }
    }
}
