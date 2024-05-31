using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinesweeperUI
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var board = "  2f00000  2bB 113".PadRight(81, ' ');

            var app = new Application();
            var window = new Window();

            var boardPanel = CreateGrid();

            for (var index = 0; index < board.Length; index++)
            {
                var col = index % 9;
                var row = index / 9;
                var content = board[index] switch
                {
                    'b' => "\ud83d\udca3",
                    'B' => "\ud83d\udca5",
                    'f' => "\u2691",
                    _ => board[index].ToString()
                };
                var color = board[index] switch
                {
                    '1' => Color.FromRgb(50, 50, 200),
                    '2' => Color.FromRgb(0, 150, 0),
                    '3' => Color.FromRgb(200, 0, 0),
                    'B' => Color.FromRgb(255, 100, 0),
                    'f' => Color.FromRgb(100, 100, 100),
                    _ => Color.FromRgb(0, 0, 0),
                };
                var label = new Button
                {
                    Content = content,
                    Foreground = new SolidColorBrush(color),
                    FontSize = 50,
                    IsEnabled = content == " ",
                };
                boardPanel.Children.Add(label);
                Grid.SetColumn(label, col);
                Grid.SetRow(label, row);
            }

            window.Content = boardPanel;

            app.Run(window);
        }

        private static Grid CreateGrid()
        {
            var height = new GridLength(90);
            var width = new GridLength(90);

            var boardPanel = new Grid();
            for (int i = 0; i < 9; i++)
            {
                var rowDefinition = new RowDefinition() { Height = height };
                boardPanel.RowDefinitions.Add(rowDefinition);
            }

            for (int i = 0; i < 9; i++)
            {
                var columnDefinition = new ColumnDefinition() { Width = width };
                boardPanel.ColumnDefinitions.Add(columnDefinition);
            }
            return boardPanel;
        }
    }
}
