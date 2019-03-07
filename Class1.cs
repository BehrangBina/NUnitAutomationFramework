using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace NUnitAutomationFramework
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void TestAdd()
        {
            Assert.True(4+4>0,"4+4>0");
            Assert.AreEqual(2+2,4,"4");
        }
        [Test]
        public void TestSubtract()
        {
            Assert.True(4 - 4 == 0, "4-4==0");
            Assert.AreEqual(2 -2, 0, "0");
        }
    }
}
