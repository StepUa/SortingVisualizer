using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using SorterVisualizer.ViewModels;

namespace SorterVisualizer.Windows
{
    public partial class SortMethodsWindow : Window
    {
        public SortMethodsWindow()
        {
            this.DataContext = new SortMethodsSelectionViewModel { CloseViewAction = new Action(this.Close) };

            InitializeComponent();
        }
    }
}
