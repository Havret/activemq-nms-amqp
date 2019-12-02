using System.Threading.Tasks;
using Apache.NMS.AMQP.Util;
using NUnit.Framework;

namespace NMS.AMQP.Test
{
    [TestFixture]
    public class AtomicLongTest
    {
        [Test]
        public void TestIncrementAndGetIsThreadSafe()
        {
            var atomicLong = new AtomicLong(1);

            Parallel.For(1, 10_000, l => atomicLong.IncrementAndGet());

            Assert.AreEqual(10_000, (long) atomicLong);
        }
    }
}