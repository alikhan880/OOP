using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EndPoint;
namespace TestCurr
{
    [TestFixture]
    public class CurrTest
    {
        private const string val = "$100";
        [Test]
        public void Test1()
        {
            var cl = new TestCurrency();
            Assert.AreEqual(val, cl.ObtainCurrency());
        }
    }
}
