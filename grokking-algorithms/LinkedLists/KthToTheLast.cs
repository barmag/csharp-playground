using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    class KthToTheLast
    {
        internal static int Execute(LinkedList<int> l, int k)
        {
            int counter = 0;
            var node = l.First;
            var lastNode = l.First;
            Queue<LinkedListNode<int>> candidates = new Queue<System.Collections.Generic.LinkedListNode<int>>();
            while(node != null)
            {
                lastNode = node;
                node = node.Next;
                counter++;
                if (counter > k && candidates.Count > 0)
                {
                    candidates.Dequeue();
                }
                candidates.Enqueue(lastNode);
            }
            
            return candidates.Dequeue().Value;
        }
    }

    [TestFixture]
    class KthToTheLastTest
    {
        [Test]
        public void KthToTheLastBasic()
        {
            var l = new LinkedList<int>(new int[] {1,2,3,4,5,6,7,8,9});
            var expected = 7;
            int actual = KthToTheLast.Execute(l, 3);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void KthToTheLastKFirstElement()
        {
            var l = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var expected = 1;
            int actual = KthToTheLast.Execute(l, 9);
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KthToTheLastKLatElement()
        {
            var l = new LinkedList<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 });
            var expected = 9;
            int actual = KthToTheLast.Execute(l, 0);
            Assert.AreEqual(expected, actual);
        }
    }
}
