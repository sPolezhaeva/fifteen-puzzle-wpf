using System.Windows;
using LevelGenerator;

namespace FifteenPuzzle.WPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnTileClick(object sender, RoutedEventArgs e)
        {
            // Handle tile click event
        }

        private void OnNewGameClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var generator = new PuzzleGenerator();
                int size = 4; 
                var board = generator.GeneratePuzzle(size);
                GameBoardControl.UpdateBoard(board);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("Ошибка при создании новой игры: " + ex.Message);
            }
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}