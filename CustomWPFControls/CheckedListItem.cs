using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace CustomWPFControls
{
    public class CheckedListItem<T> : INotifyPropertyChanged
    {
        private bool _isChecked;
        private T _item;

        public CheckedListItem()
        {

        }
        public CheckedListItem(T item, bool isChecked = false)
        {
            Item = item;
            IsChecked = isChecked;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public T Item
        {
            get
            {
                return _item;
            }
            set
            {
                _item = value;

                OnPropertyChanged();
            }
        }
        public bool IsChecked
        {
            get
            {
                return _isChecked;
            }
            set
            {
                _isChecked = value;

                OnPropertyChanged();
            }
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
