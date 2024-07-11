using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PruebaCronometro
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PruebaCronometroViewModel _pruebaCronometroViewModel;
        public MainWindow()
        {
            InitializeComponent();
            _pruebaCronometroViewModel = new PruebaCronometroViewModel();
            DataContext = _pruebaCronometroViewModel;
            var binding = new System.Windows.Data.Binding("TimeDisplay")
            {
                Source = _pruebaCronometroViewModel
            };
            TimeDisplay.SetBinding(TextBlock.TextProperty, binding);
        }

        private void StartButton_Click(object sender, RoutedEventArgs e) => _pruebaCronometroViewModel.Start();
        private void PauseButton_Click(object sender, RoutedEventArgs e) => _pruebaCronometroViewModel.Pause();
        private void StopButton_Click(object sender, RoutedEventArgs e) => _pruebaCronometroViewModel.Stop();
    }
}
