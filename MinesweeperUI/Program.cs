using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MinesweeperUI
{
    internal class Program
    {
        private static Grid _grid;
        private static char[] _board;

        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            var window = new Window();
            _grid = CreateGrid();
            CreateLabels(_grid, 81);
            window.Content = _grid;

            _board = "  2f00000  2bB 113".PadRight(81, ' ').ToCharArray();
            UpdateView();

            app.Run(window);
        }

        private static void CreateLabels(Grid boardPanel, int size)
        {
            for (var index = 0; index < size; index++)
            {
                var col = index % 9;
                var row = index / 9;
                var button = new Button
                {
                    FontSize = 50,
                };
                button.Click += ButtonClick;
                boardPanel.Children.Add(button);
                Grid.SetColumn(button, col);
                Grid.SetRow(button, row);
            }
        }

        private static void ButtonClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var index = _grid.Children.IndexOf(button);
            _board[index] = 'X';
            UpdateView();
        }

        private static void UpdateView()
        {
            for (var index = 0; index < _grid.Children.Count; index++)
            {
                var content = _board[index] switch
                {
                    'b' => "\ud83d\udca3",
                    'B' => "\ud83d\udca5",
                    'f' => "\u2691",
                    _ => _board[index].ToString()
                };
                var color = _board[index] switch
                {
                    '1' => Color.FromRgb(50, 50, 200),
                    '2' => Color.FromRgb(0, 150, 0),
                    '3' => Color.FromRgb(200, 0, 0),
                    'B' => Color.FromRgb(255, 100, 0),
                    'f' => Color.FromRgb(100, 100, 100),
                    _ => Color.FromRgb(0, 0, 0),
                };
                UIElement uiElement = _grid.Children[index];
                var button = (Button)uiElement;
                button.Content = content;
                button.Foreground = new SolidColorBrush(color);
                button.IsEnabled = content == " ";
            }
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
