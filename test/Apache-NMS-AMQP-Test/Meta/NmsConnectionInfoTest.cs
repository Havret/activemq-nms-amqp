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
    }
}