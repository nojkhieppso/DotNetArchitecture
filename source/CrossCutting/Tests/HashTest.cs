using Microsoft.VisualStudio.TestTools.UnitTesting;
using Solution.CrossCutting.Security;
using System;

namespace Solution.CrossCutting.Tests
{
    [TestClass]
    public class HashTest
    {
        public HashTest()
        {
            Hash = new Hash();
        }

        private IHash Hash { get; }

        [TestMethod]
        public void HashCreate()
        {
            Assert.IsNotNull(Hash.Create(nameof(Hash)));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashCreateEmpty()
        {
            Hash.Create(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HashCreateNull()
        {
            Hash.Create(null);
        }
    }
}
