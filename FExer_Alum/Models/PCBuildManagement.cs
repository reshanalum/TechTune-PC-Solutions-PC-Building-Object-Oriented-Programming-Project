using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FINALPROJECT_OOP_ALUM.Models
{
    public class PCBuildManagement
    {
        public static ObservableCollection<PCBuild> DatabasePCBuild{ get; set; } = new ObservableCollection<PCBuild>();

        public static void AddPCBuild (PCBuild pcBuild)
        {
            DatabasePCBuild.Add(pcBuild);
        }

    }
}
