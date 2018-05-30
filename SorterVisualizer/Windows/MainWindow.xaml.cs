using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using CustomWPFControls;
using SorterVisualizer.Database;
using SorterVisualizer.ViewModels;
using SorterVisualizer.Windows;
using SorterVisualizer.Tools;

namespace SorterVisualizer.Windows
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            DataContext = new MainWindowViewModel(new WindowFactory())
            {
                CloseViewAction = this.Close
            };

            InitializeComponent();

            // Set default value
            slSortingSpeed.Value = slSortingSpeed.Maximum;

            //DataGrid dg = new DataGrid();

            //int[,] a = new int[,] { { 1, 2 }, { 3, 4 } };
            //int[,] b = new int[a.GetLength(0), a.GetLength(1)];

            //for (int i = 0; i < b.GetLength(0); i++)
            //{
            //    for (int j = 0; j < b.GetLength(1); j++)
            //    {
            //        b[j, i] = a[i, j];
            //    }
            //}

            //dg.ItemsSource = Utils.ConvertToOneDimensionalArray(b);
            //dg.AutoGenerateColumns = true;

            //tcSorters.Items.Add(new TabItem
            //    {
            //        Header = "Test",
            //        Content = dg
            //    }
            //    );
        }

        // Menu's tool strip items events handling          
        private void InitFromFile_Click(object sender, RoutedEventArgs e)
        {

        }
        private void LanguageRadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
