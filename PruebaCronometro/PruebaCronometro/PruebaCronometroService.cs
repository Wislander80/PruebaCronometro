using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Threading.Tasks;

namespace PruebaCronometro
{
    public class PruebaCronometroService
    {
        private readonly Timer localTimer;
        private DateTime startTime;
        private TimeSpan pausedTime;
        private bool isRunning;

        public event Action<TimeSpan> TimeUpdated;

        public PruebaCronometroService()
        {
            localTimer = new Timer(1000);
            localTimer.Elapsed += OnTimerElapsed;
        }

        public void Start()
        {
            if (!isRunning)
            {
                startTime = DateTime.Now - pausedTime;
                localTimer.Start();
                isRunning = true;
            }
        }

        public void Pause()
        {
            if (isRunning)
            {
                pausedTime = DateTime.Now - startTime;
                localTimer.Stop();
                isRunning = false;
            }
        }

        public void Stop()
        {
            localTimer.Stop();
            isRunning = false;
            pausedTime = TimeSpan.Zero;
            TimeUpdated?.Invoke(TimeSpan.Zero);
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            if (isRunning)
            {
                var elapsedTime = DateTime.Now - startTime;
                TimeUpdated?.Invoke(elapsedTime);
            }
        }
    }
}
