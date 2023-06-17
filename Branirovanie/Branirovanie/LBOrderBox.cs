using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using Branirovanie.ParserCore;

namespace Branirovanie
{
    class LBOrderBox : ComboBox
    {
        public ObservableCollection<FoodSource> Foods { get; set; }

        public LBOrderBox(string sn, ObservableCollection<FoodSource> fs)
        {
            
        }
    }
}
