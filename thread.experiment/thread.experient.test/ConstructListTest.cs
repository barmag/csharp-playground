using Microsoft.VisualStudio.TestTools.UnitTesting;
using thread.experiment;

namespace thread.experient.test
{
    [TestClass]
    public class ConstructListTest
    {
        [TestMethod]
        public void VerifyLength()
        {
            var max = 1000;
            var listConstructor = new ConstructList();
            var list = listConstructor.Generate(max);
            Assert.AreEqual(max, list.Count);
        }
    }
}
