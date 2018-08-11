using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace thread.experiment
{
    public class ConstructList
    {
        private class Args
        {
            public List<int> TheList { get; set; }
            public int Max { get; set; }
        }
        public List<int> Generate(int max)
        {
            var list = new List<int>();
            var i = 0;
            //while (list.Count < max)
            //{
            //    list.Add(i++);
            //}

            //return list;
            list.Add(0);
            var t1 = new Thread(doWork1);
            var t2 = new Thread(doWork2);

            var args = new Args(){Max = max, TheList = list};
            t1.Start(args);
            t2.Start(args);

            t1.Join();
            t2.Join();
            return list;
        }

        private void doWork1(object args)
        {
            var typed = args as Args;

            // this effectively makes the code run in a single thread
            // the mutex is 
            lock (typed)
            {
                while (typed.TheList.Count < typed.Max)
                {
                    //lock (typed)
                    {
                        typed.TheList.Add(typed.TheList[typed.TheList.Count - 1] + 1);
                    }
                }
            }
        }

        private void doWork2(object args)
        {
            var typed = args as Args;
            lock (typed)
            {
                while (typed.TheList.Count < typed.Max)
                {
                    //lock (typed)
                    {
                        typed.TheList.Add(typed.TheList[typed.TheList.Count - 1] + 1);
                    }
                }
            }
        }
    }
}
