using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace FifteenPuzzle.WPF.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TileViewModel> _tiles;
        private int _emptyTileIndex;

        public ObservableCollection<TileViewModel> Tiles
        {
            get => _tiles;
            set
            {
                _tiles = value;
                OnPropertyChanged(nameof(Tiles));
            }
        }

        public ICommand MoveCommand { get; }

        public MainViewModel()
        {
            Tiles = new ObservableCollection<TileViewModel>();
            MoveCommand = new RelayCommand<int>(MoveTile);
            InitializeGame();
        }

        private void InitializeGame()
        {}

        private void MoveTile(int tileIndex)
        {}

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}