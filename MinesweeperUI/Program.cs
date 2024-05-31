using System.Windows;

namespace MinesweeperUI
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            var app = new Application();
            var window = new Window();
            app.Run(window);
        }
    }
}
