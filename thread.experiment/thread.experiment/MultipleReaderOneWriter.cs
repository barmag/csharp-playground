using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace thread.experiment
{
    /// <summary>
    /// Producer consumer thread safety problem
    /// Handle the case where multiple threads can have:
    /// - One writer can access the shared data
    /// - Multiple readers can access the data simultaneously
    /// - Readers cannot access the data while being written
    /// </summary>
    public class MultipleReaderOneWriter
    {
        private readonly List<int> _data = new List<int>();
        private const int Delay = 1000;

        private readonly object _counterSync = new object();
        private int _resourceCounter = 0;

        // Exclusive lock ... one reader, and one writer
        public void Write()
        {
            lock (_counterSync)
            {
                while (_resourceCounter != 0)
                {
                    Monitor.Wait(_counterSync);
                }

                _resourceCounter = -1;
            }
            lock (_data)
            {
                // Read data
                int count = _data.Count;
                // Simulate a slow write
                Console.WriteLine("Beginning to write item No: {0}", count);
                Thread.Sleep(Delay);
                _data.Add(count);
                Console.WriteLine("Done writing: {0}", _data.Count);
                _resourceCounter = 0;
            }
        }

        public int Read()
        {
            lock (_counterSync)
            {
                while (_resourceCounter == -1)
                {
                    Monitor.Wait(_counterSync);
                }

                Interlocked.Increment(ref _resourceCounter);
            }
            
            {
                //Interlocked.Increment(ref _readers);
                Console.WriteLine("readers: {0}", _resourceCounter);
                Thread.Sleep(Delay);
                Interlocked.Decrement(ref _resourceCounter);
                Console.WriteLine("end reading, reader: {0}", _resourceCounter);
                lock (_counterSync)
                {
                    if (_resourceCounter == 0)
                    {
                        Monitor.Pulse(_counterSync);
                    }
                }

                return _data.Count;
            }
        }
    }
}
