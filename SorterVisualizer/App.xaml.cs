using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using System.Windows;
using SorterVisualizer.Model;
using SorterVisualizer.Windows;
using SorterVisualizer.ViewModels;
using System.Threading;

namespace SorterVisualizer
{
    public partial class App : Application
    {
        private static readonly CultureInfo[] _appLanguages = new CultureInfo[]
        {
            CultureInfo.GetCultureInfo("en-US"),
            CultureInfo.GetCultureInfo("ru-RU"),
            CultureInfo.GetCultureInfo("uk-UA")
        };

        public static CultureInfo[] AppLanguages
        {
            get
            {
                return _appLanguages;
            }
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            if (!string.IsNullOrEmpty(SorterVisualizer.Properties.Settings.Default.Language))
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(SorterVisualizer.Properties.Settings.Default.Language);
                Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(SorterVisualizer.Properties.Settings.Default.Language);
            }
        }
    }
}
