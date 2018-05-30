using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using System.ComponentModel;
using System.Globalization;
using NLog;
using SorterVisualizer.Model;
using SorterVisualizer.Tools;
using SorterVisualizer.Resources.Localization;
using SorterVisualizer.Commands;

namespace SorterVisualizer.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();
        private MainModel _sortersModel = Model.MainModel.GetModel();
        private IViewFactory _viewFactory;
        private bool _sortingIsStarted;
        private double _sortingSpeedDelay;

        public MainWindowViewModel(IViewFactory viewFactory = null)
        {
            _viewFactory = viewFactory;

            CommandsInit();

            PropertyChanged += (sender, e) =>
            {
                if (string.IsNullOrEmpty(e.PropertyName))
                {
                    return;
                }

                if (e.PropertyName == Utils.GetMemberName(() => this.SortingSpeedDelay))
                {
                    int sortingSpeedDelay = _sortersModel.MinimumSortSpeedDelay + (int)(SortingSpeedDelay * 100d);

                    // TODO: implement interaction with Sorter in Threads
                    // ***code here***
                }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand StartSortingCommand { get; private set; }
        public ICommand StopSortingCommand { get; private set; }
        public ICommand OpenViewCommand { get; private set; }
        public ICommand SelectAppLanguageCommand { get; private set; }
        public bool SortingIsStarted
        {
            get
            {
                return _sortingIsStarted;
            }
            private set
            {
                _sortingIsStarted = value;

                OnPropertyChanged();
            }
        }
        public double SortingSpeedDelay
        {
            get
            {
                return _sortingSpeedDelay;
            }
            set
            {
                _sortingSpeedDelay = value;

                OnPropertyChanged();
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

        // OpenViewCommand
        public bool CanOpenView(object parameter)
        {
            return !SortingIsStarted && _viewFactory != null && _viewFactory.CanCreate(parameter);
        }
        public void OpenView(object parameter)
        {
            try
            {
                _viewFactory.CreateView((Type)parameter);
            }
            catch (InvalidCastException exception)
            {
                _logger.Error("Invalid parameter was passed to create view method: {0} || Source: {1}",
                    exception.Message, exception.Source);
            }
        }
        // SelectAppLanguageCommand
        public bool CanSelectAppLanguage(object parameter)
        {
            if (!(parameter is string))
            {
                _logger.Error("Parameter that was given to select app language method is not string. Type: {0}",
                    parameter.GetType().ToString());

                return false;
            }

            try
            {
                CultureInfo.GetCultureInfo((string)parameter);
            }
            catch (CultureNotFoundException exception)
            {
                _logger.Error("Invalid culture name [{0}] was passed to language selection method. Info: {1}",
                    exception.InvalidCultureName, exception.Message);

                return false;
            }

            CultureInfo futureCulture = CultureInfo.GetCultureInfo((string)parameter);

            bool isCurrentCulture = futureCulture.Equals(CultureInfo.CurrentCulture) && futureCulture.Equals(CultureInfo.CurrentUICulture);

            return !SortingIsStarted && !isCurrentCulture && App.AppLanguages.Contains(futureCulture);
        }
        public void SelectAppLanguage(object parameter)
        {
            try
            {
                string cultureName = (string)parameter;

                Properties.Settings.Default.Language = cultureName;
                Properties.Settings.Default.Save();

                // TODO: add dialog for closing app
                if (CloseViewAction != null)
                {
                    CloseViewAction.Invoke();
                }
            }
            catch (InvalidCastException exception)
            {
                _logger.Error("SelectAppLanguage execution error: [invalid type was given]: {0} || Target: {1}",
                    exception.Message, exception.TargetSite);
            }
        }
        //
        protected virtual void OnPropertyChanged([System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            PropertyChangedEventHandler handler = PropertyChanged;

            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        private void CommandsInit()
        {
            this.OpenViewCommand = new OpenViewCommand(OpenView, CanOpenView);
            this.SelectAppLanguageCommand = new SelectAppLanguageCommand(SelectAppLanguage, CanSelectAppLanguage);
        }
    }
}
