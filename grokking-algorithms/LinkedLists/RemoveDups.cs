using NUnit.Framework;
using System.Collections.Generic;
using System;

namespace LinkedLists
{
    class RemoveDups
    {
        internal static LinkedList<int> Execute(LinkedList<int> list)
        {
            var root = list.First;
            if (root == null)
            {
                return list;
            }
            while(root.Next != null)
            {
                var racePointer = root.Next;
                while(racePointer != null)
                {
                    if (racePointer.Value == root.Value)
                    {
                        var temp = racePointer.Next;
                        list.Remove(racePointer);
                        racePointer = temp;
                    }
                    else
                    {
                        racePointer = racePointer.Next;
                    }
                }
                root = root.Next;
            }
            return list;
        }
    }

    [TestFixture]
    class RemoveDupsTest
    {
        [Test]
        public void TestWithNoDuplicates()
        {
            var expected = new LinkedList<int>(new int[] { 1, 2, 3 });
            var l = new LinkedList<int>(new int[] { 1, 2, 3 });
            var r = RemoveDups.Execute(l);
            Assert.AreEqual(r.Count, expected.Count);
        }

        [Test]
        public void TestWithOneDup()
        {
            var expectedCount = 3;
            var l = new LinkedList<int>(new int[] { 1, 2, 3, 2 });
            l = RemoveDups.Execute(l);
            Assert.AreEqual(expectedCount, l.Count);
        }

        [Test]
        public void TestWithMultiDuplicates()
        {
            var expectedCount = 5;
            var l = new LinkedList<int>(new int[] { 1, 2, 3, 2 , 1, 5, 5, 2, 8});
            l = RemoveDups.Execute(l);
            Assert.AreEqual(expectedCount, l.Count);
        }
    }
}
