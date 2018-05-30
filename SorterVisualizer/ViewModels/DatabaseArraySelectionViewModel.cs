using System;
using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;
using System.Windows;
using NLog;
using SorterVisualizer.Model;
using SorterVisualizer.Database;
using SorterVisualizer.Commands;
using SorterVisualizer.Resources.Localization;
using ISorterProject;

namespace SorterVisualizer.ViewModels
{
    public class DatabaseArraySelectionViewModel
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private MainModel _sortersModel = Model.MainModel.GetModel();
        private DatabaseInfoWrapper[] _inputArrays;
        private int? _arrayID;

        public DatabaseArraySelectionViewModel()
        {
            this.SelectArrayCommand = new SelectArrayCommand(SelectArray, CanSelect);
            this.ApplyArrayIDCommand = new ApplyArrayIDCommand(ApplyArrayID, CanApply);
            this.InputArraysInit();
        }

        public DatabaseInfoWrapper[] InputArrays
        {
            get
            {
                return _inputArrays;
            }
        }
        public MainModel SortersModel
        {
            get
            {
                return _sortersModel;
            }
        }
        public Action CloseViewAction { get; set; }
        public ICommand SelectArrayCommand { get; private set; }
        public ICommand ApplyArrayIDCommand { get; private set; }

        /// <summary>
        /// Get input arrays from database
        /// </summary>
        private void InputArraysInit()
        {
            using (Database.SortersVisualizerDBEntities context = new Database.SortersVisualizerDBEntities())
            {
                if (!context.Database.Exists())
                {
                    MessageBox.Show(MessagesArrayInitializationFromDatabaseWindow.DatabaseDoesntExistText,
                        MessagesRandomArrayCreationWindow.DatabaseConnectionText, MessageBoxButton.OK, MessageBoxImage.Error);

                    _logger.Error("Database doesn't exist");

                    if (CloseViewAction != null)
                    {
                        CloseViewAction();
                    }

                    return;
                }

                _inputArrays = (from item in context.InputArrays
                                select new DatabaseInfoWrapper
                                {
                                    ArrayId = item.iInputArrayId,
                                    NumberOfColumns = item.iNumberOfColumns,
                                    NumberOfRows = item.iNumberOfRows
                                }).ToArray();
            }
        }
        // SelectIDCommand
        public bool CanSelect(object parameter)
        {
            return parameter is DatabaseInfoWrapper;
        }
        public void SelectArray(object parameter)
        {
            _arrayID = ((DatabaseInfoWrapper)parameter).ArrayId;
        }
        // ApplyIDCommand
        public bool CanApply(object parameter)
        {
            return _arrayID != null;
        }
        public void ApplyArrayID(object parameter)
        {
            _sortersModel.SelectedArrayID = _arrayID;

            if (CloseViewAction != null)
            {
                CloseViewAction();
            }
        }

        /// <summary>
        /// Wrapper class for database info
        /// </summary>
        public class DatabaseInfoWrapper
        {
            public int ArrayId { get; set; }
            public int NumberOfColumns { get; set; }
            public int NumberOfRows { get; set; }
        }
    }
}
