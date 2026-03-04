using System.ComponentModel;

namespace FifteenPuzzle.WPF.ViewModels
{
    public class TileViewModel : INotifyPropertyChanged
    {
        private int _value;
        private bool _isEmpty;

        public int Value
        {
            get => _value;
            set
            {
                _value = value;
                OnPropertyChanged(nameof(Value));
            }
        }

        public bool IsEmpty
        {
            get => _isEmpty;
            set
            {
                _isEmpty = value;
                OnPropertyChanged(nameof(IsEmpty));
            }
        }

        public TileViewModel(int value, bool isEmpty)
        {
            Value = value;
            IsEmpty = isEmpty;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}