using System;
using System.Collections.Generic;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using thread.experiment;

namespace thread.experient.test
{
    [TestClass]
    public class ProducerConsumerTest
    {
        [TestMethod]
        public void VerifySequential()
        {
            var r = new Random();
            var producerConsumer = new MultipleReaderOneWriter();
            var count = 0;
            var readers = new List<Thread>();
            for (int i = 0; i < 10; i++)
            {
                var reader = new Thread(() =>
                {
                    count = producerConsumer.Read();
                });
                reader.Start();
                readers.Add(reader);
                Thread.Sleep(r.Next(1, 50));
            }
            var writer = new Thread(() =>
            {
                producerConsumer.Write();
            });

            writer.Start();
            writer.Join();
            foreach (var reader in readers)
            {
                reader.Join();
            }

            count = producerConsumer.Read();
            Assert.AreEqual(1, count);
        }
    }
}
