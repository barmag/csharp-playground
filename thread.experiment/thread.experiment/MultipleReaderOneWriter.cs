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
        private const int DELAY = 1000;

        // Exclusive lock ... one reader, and one writer
        public void Write()
        {
            lock (_data)
            {
                // Read data
                int count = _data.Count;
                // Simulate a slow write
                Console.WriteLine("Beginning to write item No: {0}", count);
                Thread.Sleep(DELAY);
                _data.Add(count);
                Console.WriteLine("Done writing: {0}", _data.Count);
            }
        }

        private int _readers = 0;
        public int Read()
        {
            lock (_data)
            {
                Interlocked.Increment(ref _readers);
                Console.WriteLine("readers: {0}", _readers);
                Thread.Sleep(DELAY);
                Interlocked.Decrement(ref _readers);
                Console.WriteLine("end reading, reader: {0}", _readers);
                return _data.Count;
            }
        }
    }
}
