using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Windows;
using NLog;
using SorterVisualizer.Commands;
using SorterVisualizer.Tools;
using SorterVisualizer.Database;
using SorterVisualizer.Resources.Localization;

namespace SorterVisualizer.ViewModels
{
    public class RandomArrayCreationViewModel
    {
        private Logger _logger = LogManager.GetCurrentClassLogger();

        public RandomArrayCreationViewModel()
        {
            this.ArrayInfo = new ArrayCreationInfoWrapper();
            this.CreateArrayCommand = new CreateArrayCommand(CreateArray, CanCreateArray);
        }

        public ArrayCreationInfoWrapper ArrayInfo { get; set; }
        public ICommand CreateArrayCommand { get; private set; }
        public Action CloseViewAction { get; set; }

        public bool CanCreateArray(object parameter)
        {           
            return ArrayInfo.IsValid;
        }
        public void CreateArray(object parameter)
        {
            using (Database.SortersVisualizerDBEntities context = new Database.SortersVisualizerDBEntities())
            {
                if (!context.Database.Exists())
                {
                    MessageBox.Show(MessagesRandomArrayCreationWindow.DatabaseDoesntExistText,
                        MessagesRandomArrayCreationWindow.DatabaseConnectionText, MessageBoxButton.OK, MessageBoxImage.Error);

                    _logger.Error("Database doesn't exist");

                    if (CloseViewAction != null)
                    {
                        CloseViewAction();
                    }

                    return;
                }

                int[] array = new int[ArrayInfo.RowsNumb * ArrayInfo.ColumnsNumb];

                array = Tools.Utils.GetRandomArray(array.Length, (int)ArrayInfo.MinValue, (int)ArrayInfo.MaxValue);

                Database.InputArrays inputArray = new Database.InputArrays
                {
                    iNumberOfRows = ArrayInfo.RowsNumb,
                    iNumberOfColumns = ArrayInfo.ColumnsNumb,
                    vcInputArrayContent = string.Join(" ", array)
                };

                context.InputArrays.Add(inputArray);
                int rowsAffected = context.SaveChanges();

                if (rowsAffected > 0)
                {
                    MessageBox.Show(MessagesRandomArrayCreationWindow.ArraySuccessfullyCreatedText,
                        MessagesRandomArrayCreationWindow.OperationResultText, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show(MessagesRandomArrayCreationWindow.ArrayUnsuccessfullyCreatedText,
                        MessagesRandomArrayCreationWindow.OperationResultText, MessageBoxButton.OK, MessageBoxImage.Warning);

                    _logger.Error("Array insertion into database error");
                }
            }

            if (CloseViewAction != null)
            {
                CloseViewAction();
            }
        }

        /// <summary>
        /// Wrapper class for info about array parameters
        /// </summary>
        public class ArrayCreationInfoWrapper : INotifyPropertyChanged, IDataErrorInfo
        {
            private Logger _logger = LogManager.GetCurrentClassLogger();
            private int _columnsNumb;
            private int _rowsNumb;
            private int? _minValue;
            private int? _maxValue;
            private string[] _properties = { "ColumnsNumb", "RowsNumb", "MinValue", "MaxValue" };

            public ArrayCreationInfoWrapper()
            {

            }

            public event PropertyChangedEventHandler PropertyChanged;

            public string Error
            {
                get { return String.Empty; }
            }
            public string this[string propertyName]
            {
                get
                {
                    string errorText = String.Empty;

                    switch (propertyName)
                    {
                        case "ColumnsNumb":
                            {
                                errorText = ColumnsNumbValidation();

                                break;
                            }
                        case "RowsNumb":
                            {
                                errorText = RowsNumbValidation();

                                break;
                            }
                        case "MinValue":
                            {
                                errorText = MinValueValidation();
                                
                                break;
                            }
                        case "MaxValue":
                            {
                                errorText = MaxValueValidation();
                                
                                break;
                            }
                        default:
                            {
                                _logger.Error("Property named [{0}] - doesn't exist", propertyName);

                                throw new ArgumentException("Selected property doesn't exist", propertyName);
                            }
                    }

                    return errorText;
                }
            }
            public int ColumnsNumb
            {
                get
                {
                    return _columnsNumb;
                }
                set
                {
                    _columnsNumb = value;

                    OnPropertyChanged();
                }
            }
            public int RowsNumb
            {
                get
                {
                    return _rowsNumb;
                }
                set
                {
                    _rowsNumb = value;

                    OnPropertyChanged();
                }
            }
            public int? MinValue
            {
                get
                {
                    return _minValue;
                }
                set
                {
                    _minValue = value;

                    OnPropertyChanged();
                    OnPropertyChanged("MaxValue");
                }
            }
            public int? MaxValue
            {
                get
                {
                    return _maxValue;
                }
                set
                {
                    _maxValue = value;

                    OnPropertyChanged();
                    OnPropertyChanged("MinValue");
                }
            }
            public bool IsValid
            {
                get
                {
                    foreach (string str in _properties)
                    {
                        if (!string.IsNullOrEmpty(this[str]))
                        {
                            return false;
                        }
                    }

                    return true;
                }
            }

            private string ColumnsNumbValidation()
            {
                if (ColumnsNumb < 1 || ColumnsNumb > 1000)
                {
                    return MessagesRandomArrayCreationWindow.RowsAndColumnsValidationErrorText;
                }

                return string.Empty;
            }
            private string RowsNumbValidation()
            {
                if (RowsNumb < 1 || RowsNumb > 1000)
                {
                    return MessagesRandomArrayCreationWindow.RowsAndColumnsValidationErrorText;
                }

                return string.Empty;
            }
            private string MinValueValidation()
            {
                if (MinValue == null || MinValue >= MaxValue)
                {
                    return MessagesRandomArrayCreationWindow.ArrayRangeValidationErrorText;
                }

                return string.Empty;
            }
            private string MaxValueValidation()
            {
                if (MaxValue == null || MaxValue <= MinValue)
                {
                    return MessagesRandomArrayCreationWindow.ArrayRangeValidationErrorText;
                }

                return string.Empty;
            }
            protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
            {
                PropertyChangedEventHandler handler = PropertyChanged;

                if (handler != null)
                {
                    handler(this, new PropertyChangedEventArgs(propertyName));
                }
            }
        }
    }
}
