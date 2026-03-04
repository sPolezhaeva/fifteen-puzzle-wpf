using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace FifteenPuzzle.WPF.Views
{
    public partial class GameBoard : UserControl
    {
        private int[,] _board;
        private int _size;

        public GameBoard()
        {
            InitializeComponent();
        }

        public void UpdateBoard(int[,] board)
        {
            if (board == null) return;
            _board = board;
            _size = board.GetLength(0);

            var items = new System.Collections.Generic.List<string>();
            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    var v = board[i, j];
                    items.Add(v == 0 ? string.Empty : v.ToString());
                }
            }
            TilesControl.ItemsSource = items;
            TilesControl.UpdateLayout();

            var uniform = FindVisualChild<System.Windows.Controls.Primitives.UniformGrid>(TilesControl);
            if (uniform != null)
            {
                uniform.Rows = _size;
                uniform.Columns = _size;
            }

            if (IsSolved())
            {
                WinOverlay.Visibility = Visibility.Visible;
            }
            else
            {
                WinOverlay.Visibility = Visibility.Collapsed;
            }
        }

        private void Tile_Click(object sender, RoutedEventArgs e){}
        
    }
}