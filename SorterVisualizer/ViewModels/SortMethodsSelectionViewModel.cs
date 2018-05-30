using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SorterVisualizer.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SorterVisualizer.Commands;
using System.Windows;
using NLog;
using ISorterProject;
using CustomWPFControls;
using SorterVisualizer.Resources.Localization;

namespace SorterVisualizer.ViewModels
{
    public class SortMethodsSelectionViewModel
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private MainModel _sortersModel = Model.MainModel.GetModel();

        public SortMethodsSelectionViewModel()
        {
            SortersWrapper();

            this.SelectCommand = new SelectSortersCommand(SelectSorters, CanSelect);
            this.VerifyCollectionCommand = new VerifyCollectionCommand(VerifyCollection, CanVerify);
        }

        public Action CloseViewAction { get; set; }
        public ICommand SelectCommand { get; private set; }
        public ICommand VerifyCollectionCommand { get; private set; }
        public ObservableCollection<CheckedListItem<Sorter>> Sorters { get; set; }
        public MainModel SortersModel
        {
            get
            {
                return _sortersModel;
            }
        }

        // SelectCommand
        public bool CanSelect(object parameter)
        {
            if (Sorters == null)
            {
                return false;
            }

            return Sorters.Any(item => item.IsChecked == true);
        }
        public void SelectSorters(object parameter)
        {
            _sortersModel.SelectedSorters = (from listItem in Sorters
                                             where listItem.IsChecked == true
                                             select listItem.Item).ToArray();

            if (CloseViewAction != null)
            {
                CloseViewAction();
            }
        }
        // VerifyCollectionCommand
        public bool CanVerify(object parameter)
        {
            return parameter is int;
        }
        public void VerifyCollection(object parameter)
        {
            if (((int)parameter) == 0)
            {
                MessageBox.Show( MessagesSortMethodsListWindow.SortingNumberIsZeroErrorText,
                               MessagesSortMethodsListWindow.WarningCaption, MessageBoxButton.OK, MessageBoxImage.Warning);

                if (CloseViewAction != null)
                {
                    CloseViewAction();
                }
            }
        }
        /// <summary>
        /// Wrap loaded sorters into CheckedListItems
        /// </summary>
        private void SortersWrapper()
        {
            Sorters = new ObservableCollection<CheckedListItem<Sorter>>();

            _sortersModel.LoadSorters();

            foreach (Sorter sorter in _sortersModel.LoadedSorters)
            {
                Sorters.Add(new CheckedListItem<Sorter>(sorter));
            }
        }
    }
}
