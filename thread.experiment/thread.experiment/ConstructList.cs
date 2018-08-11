using System;
using System.Collections.Generic;
using System.Text;

namespace thread.experiment
{
    public class ConstructList
    {
        public List<int> Generate(int max)
        {
            var list = new List<int>();

            for (int i = 0; i < max; i++)
            {
                list.Add(i);
            }

            return list;
        }

        
    }
}
