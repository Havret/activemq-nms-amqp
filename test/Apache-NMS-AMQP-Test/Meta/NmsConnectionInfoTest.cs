using System;
using Apache.NMS.AMQP.Meta;
using Apache.NMS.AMQP.Util;
using NUnit.Framework;

namespace NMS.AMQP.Test.Meta
{
    [TestFixture]
    public class NmsConnectionInfoTest
    {
        private NmsConnectionId firstId;
        private NmsConnectionId secondId;

        [SetUp]
        public void SetUp()
        {
            var generator = new IdGenerator2();
            firstId = new NmsConnectionId(generator.GenerateId());
            secondId = new NmsConnectionId(generator.GenerateId());
        }

        [Test]
        public void TestExceptionWhenCreatedWithNullConnectionId()
        {
            Assert.Catch<ArgumentNullException>(() => new NmsConnectionInfo(null));
        }

        [Test]
        public void TestCreate()
        {
            var info = new NmsConnectionInfo(firstId);
            Assert.AreSame(firstId, info.Id);
            Assert.NotNull(info.ToString());
        }

        [Test]
        public void TestHashCode()
        {
            var first = new NmsConnectionInfo(firstId);
            var second = new NmsConnectionInfo(secondId);
            
            Assert.AreEqual(first.GetHashCode(), first.GetHashCode());
            Assert.AreEqual(second.GetHashCode(), second.GetHashCode());
            Assert.AreNotEqual(first.GetHashCode(), second.GetHashCode());
        }

        [Test]
        public void TestEquals()
        {
            var first = new NmsConnectionInfo(firstId);
            var second = new NmsConnectionInfo(secondId);
            
            Assert.AreEqual(first, first);
            Assert.AreEqual(second, second);
            
            Assert.IsFalse(first.Equals(second));
            Assert.IsFalse(second.Equals(first));
        }

        [Test]
        public void TestIsExplicitClientId()
        {
            var info = new NmsConnectionInfo(firstId);
            Assert.IsFalse(info.IsExplicitClientId);
            info.SetClientId("something", true);
            Assert.IsTrue(info.IsExplicitClientId);
        }
    }
}