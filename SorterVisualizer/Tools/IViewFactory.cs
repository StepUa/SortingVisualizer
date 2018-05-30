using System;

namespace SorterVisualizer.Tools
{
    public interface IViewFactory
    {
        bool CanCreate(object viewType);
        void CreateView(Type viewType, object parameter = null);
    }
}
