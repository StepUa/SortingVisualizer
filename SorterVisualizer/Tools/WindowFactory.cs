using System;
using System.Windows;

namespace SorterVisualizer.Tools
{
    class WindowFactory : IViewFactory
    {
        public bool CanCreate(object viewType)
        {   
            return viewType.GetType() is Type;
        }
        /// <summary>
        /// Window creator
        /// </summary>
        /// <param name="viewType">Any type that inherited from Window</param>
        /// <param name="parameter">DataContext for window</param>
        /// <exception cref="InvalidCastException"></exception>
        /// <returns>Operation result</returns>
        public void CreateView(Type viewType, object parameter = null)
        {
            object window = Activator.CreateInstance(viewType);

            if (parameter != null)
            {
                ((Window)window).DataContext = parameter;
            }
            
            ((Window)window).ShowDialog();            
        }
    }
}
