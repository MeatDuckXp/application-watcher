using System;
using System.Diagnostics;
using System.Linq;
using System.Timers;

namespace Core
{
    public class ProcessWatcher
    {
        private readonly string _processName;
        private readonly Action _callbackMethod;
        private Timer _scanTimer;

        public ProcessWatcher(Action callbackMethod, string processName, int scanInterval)
        {
            _processName = processName;
            _callbackMethod = callbackMethod;

            _scanTimer = new Timer(scanInterval);
            _scanTimer.Elapsed += _scanTimer_Elapsed;
        }

        public void StartWatch()
        {
            _scanTimer.Start();
            _scanTimer.AutoReset = true;
        }

        public void StopWatch()
        {
            _scanTimer.Stop();
        }

        private void _scanTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            var processes = Process.GetProcessesByName(_processName);
            if (!processes.Any())
            {
                _callbackMethod.Invoke();
                StopWatch();
            }
        }
    }
}
