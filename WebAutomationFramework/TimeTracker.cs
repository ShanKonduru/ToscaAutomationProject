using System;
using System.Collections.Generic;
using System.Diagnostics;
namespace Shan.WebAutomationFramework
{
    public static class TimeTracker
    {
        private readonly static Dictionary<string, Stopwatch> _stopwatches = new Dictionary<string, Stopwatch>();

        /// <summary>
        /// Start tracking time for a specific process.
        /// </summary>
        /// <param name="processName">The name of the process to track.</param>
        public static void Start(string processName)
        {
            if (!_stopwatches.ContainsKey(processName))
            {
                _stopwatches[processName] = Stopwatch.StartNew();
            }
            else
            {
                throw new InvalidOperationException($"Time tracking for process '{processName}' has already started.");
            }
        }

        /// <summary>
        /// Stop tracking time for a specific process and get the elapsed time.
        /// </summary>
        /// <param name="processName">The name of the process to stop tracking.</param>
        /// <returns>The elapsed time in milliseconds.</returns>
        public static long Stop(string processName)
        {
            if (_stopwatches.TryGetValue(processName, out var stopwatch))
            {
                stopwatch.Stop();
                return stopwatch.ElapsedMilliseconds;
            }
            else
            {
                throw new InvalidOperationException($"Time tracking for process '{processName}' has not started.");
            }
        }

        /// <summary>
        /// Convert elapsed time in milliseconds to 'HH:MM:SS:MS' format.
        /// </summary>
        /// <param name="elapsedTime">The elapsed time in milliseconds.</param>
        /// <returns>The elapsed time in the 'HH:MM:SS:MS' format.</returns>
        public static string GetElapsedTime(long elapsedTime)
        {
            TimeSpan timeSpan = TimeSpan.FromMilliseconds(elapsedTime);
            return $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2}:{timeSpan.Milliseconds:D3}";
        }

        /// <summary>
        /// Get the elapsed time for a specific process and stop tracking.
        /// </summary>
        /// <param name="processName">The name of the process to get the elapsed time for.</param>
        /// <returns>The elapsed time in the 'HH:MM:SS:MS' format.</returns>
        public static string ToString(string processName)
        {
            if (_stopwatches.TryGetValue(processName, out var stopwatch))
            {
                stopwatch.Stop();
                var elapsedTime = stopwatch.Elapsed;
                return $"{elapsedTime.Hours:D2}:{elapsedTime.Minutes:D2}:{elapsedTime.Seconds:D2}:{elapsedTime.Milliseconds:D3}";
            }
            else
            {
                throw new InvalidOperationException($"Time tracking for process '{processName}' has not started.");
            }
        }
    }
}