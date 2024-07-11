using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace PruebaCronometro
{
    public class PruebaCronometroViewModel: INotifyPropertyChanged
    {
        private readonly PruebaCronometroModel _pruebaCronometroModel;
        private readonly PruebaCronometroService _pruebaCronometroService;
        private readonly Dispatcher _dispatcher;

        public event PropertyChangedEventHandler PropertyChanged;

        public string TimeDisplay => _pruebaCronometroModel.ElapsedTime.ToString(@"hh\:mm\:ss");

        public PruebaCronometroViewModel()
        {
            _pruebaCronometroModel = new PruebaCronometroModel();
            _pruebaCronometroService = new PruebaCronometroService();
            _dispatcher = Dispatcher.CurrentDispatcher;

            _pruebaCronometroService.TimeUpdated += OnTimeUpdated;
        }

        private void OnTimeUpdated(TimeSpan elapsedTime)
        {
            _dispatcher.Invoke(() =>
            {
                _pruebaCronometroModel.UpdateElapsedTime(elapsedTime);
                OnPropertyChanged(nameof(TimeDisplay));
            });
        }

        public void Start() => _pruebaCronometroService.Start();
        public void Pause() => _pruebaCronometroService.Pause();
        public void Stop()
        {
            _pruebaCronometroService.Stop();
            _pruebaCronometroModel.Reset();
            OnPropertyChanged(nameof(TimeDisplay));
        }

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
