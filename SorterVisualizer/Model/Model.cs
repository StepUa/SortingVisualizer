using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using ISorterProject;

namespace SorterVisualizer.Model
{
    public class MainModel
    {
        /// <summary>
        /// Default minimum value for sorting speed delay in milliseconds.
        /// </summary>
        private const int _minimumSortSpeedDelay = 1;
        /// <summary>
        /// Default maximum value for sorters. Specified in the specification.
        /// </summary>
        private const int _maximumNumberOfSorters = 9;
        private static MainModel _model;
        private static object _syncInitialization = new object();
        private List<Sorter> _loadedSorters;
        private Sorter[] _selectedSorters;
        private int[,] _arrayForSorting;

        protected MainModel()
        {

        }

        public event EventHandler ArrayForSortingChange;
        public event EventHandler SelectedSortersChange;

        /// <summary>
        /// Default minimum value for sorting speed delay in milliseconds.
        /// </summary>
        public int MinimumSortSpeedDelay
        {
            get
            {
                return _minimumSortSpeedDelay;
            }
        }
        /// <summary>
        /// Default maximum value for sorters. Specified in the specification.
        /// </summary>
        public int MaximumNumberOfSorters
        {
            get
            {
                return _maximumNumberOfSorters;
            }
        }
        public List<Sorter> LoadedSorters
        {
            get
            {
                return _loadedSorters;
            }

            set
            {
                if (value != null)
                {
                    _loadedSorters = new List<Sorter>(value);
                }
                else
                {
                    _loadedSorters = value;
                }
            }
        }
        public Sorter[] SelectedSorters
        {
            get
            {
                return _selectedSorters;
            }
            set
            {
                if (value != null)
                {
                    _selectedSorters = new Sorter[value.Length];

                    Array.Copy(value, _selectedSorters, value.Length);
                }
                else
                {
                    _selectedSorters = value;
                }

                OnSelectedSortersChange(EventArgs.Empty);
            }
        }
        public int[,] ArrayForSorting
        {
            get
            {
                return _arrayForSorting;
            }
            set
            {
                if (value != null)
                {
                    _arrayForSorting = new int[value.GetLength(0), value.GetLength(1)];

                    Array.Copy(value, _arrayForSorting, value.Length);
                }
                else
                {
                    _arrayForSorting = value;
                }

                OnArrayForSortingChange(EventArgs.Empty);
            }
        }
        /// <summary>
        /// Represent array id from database
        /// </summary>
        public int? SelectedArrayID { get; set; }

        public static MainModel GetModel()
        {
            if (_model == null)
            {
                lock (_syncInitialization)
                {
                    if (_model == null)
                    {
                        _model = new MainModel();
                    }
                }
            }

            return _model;
        }
        public void SetSortingOverEventHandlerForAllSorters(EventHandler<SortedArrayEventArgs> handler)
        {
            if (_selectedSorters != null)
            {
                for (int i = 0; i < _selectedSorters.Length; i++)
                {
                    _selectedSorters[i].SortingOver += handler;
                }
            }
        }
        public void SetSwapRisedEventHandlerForAllSorters(EventHandler<ArrayIndexesEventArgs> handler)
        {
            if (_selectedSorters != null)
            {
                for (int i = 0; i < _selectedSorters.Length; i++)
                {
                    _selectedSorters[i].SwapRaised += handler;
                }
            }
        }
        public void SetSortingSpeedDelayForAllSorters(int delay)
        {
            for (int i = 0; i < _selectedSorters.Length; i++)
            {
                _selectedSorters[i].SortingSpeedDelay = delay;
            }
        }
        public void LoadSorters()
        {
            string folderName = Properties.Settings.Default.FolderNameWithDLLs;

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                "\\" + folderName;

            string[] pluginFiles = Directory.GetFiles(path, "*.dll");

            _loadedSorters = new List<Sorter>();

            for (int i = 0; i < pluginFiles.Length; i++)
            {
                Assembly dll = Assembly.LoadFrom(pluginFiles[i]);

                foreach (Type type in dll.GetExportedTypes())
                {
                    if (typeof(Sorter).IsAssignableFrom(type))
                    {
                        _loadedSorters.Add((Sorter)Activator.CreateInstance(type));

                        if (_loadedSorters.Count == _maximumNumberOfSorters)
                        {
                            return;
                        }
                    }
                }
            }
        }
        public void LoadArray()
        {
            string fileName = Properties.Settings.Default.FileNameWithArray;

            string path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) +
                "\\" + fileName;

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("The system cannot find the file", path);
            }

            List<int> list = new List<int>();

            int arraySize = -1;

            using (StreamReader streamReader = new StreamReader(path, System.Text.Encoding.Default))
            {
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] substrings = line.Split(' ');

                    if (arraySize == -1) // size initialization
                    {
                        if (!Int32.TryParse(substrings[0], out arraySize))
                        {
                            throw new InvalidCastException("File content not valid");
                        }
                        else
                        {
                            continue;
                        }
                    }

                    for (int i = 0; i < substrings.Length; i++)
                    {
                        int tmp;

                        if (!Int32.TryParse(substrings[i], out tmp))
                        {
                            throw new InvalidCastException("File content not valid");
                        }

                        list.Add(tmp);
                    }
                }
            }

            ArrayForSorting = new int[arraySize, arraySize];

            for (int i = 0, k = 0; i < arraySize; i++)
            {
                for (int j = 0; j < arraySize; j++, k++)
                {
                    ArrayForSorting[i, j] = list[k];
                }
            }
        }

        protected virtual void OnArrayForSortingChange(EventArgs e)
        {
            EventHandler handler = ArrayForSortingChange;

            if (handler != null)
            {
                handler(this, e);
            }
        }
        protected virtual void OnSelectedSortersChange(EventArgs e)
        {
            EventHandler handler = SelectedSortersChange;

            if (handler != null)
            {
                handler(this, e);
            }
        }
    }
}
