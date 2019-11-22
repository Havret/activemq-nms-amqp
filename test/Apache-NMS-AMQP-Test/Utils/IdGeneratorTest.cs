using System.Linq;
using Apache.NMS.AMQP.Util;
using NUnit.Framework;

namespace NMS.AMQP.Test.Utils
{
    [TestFixture]
    public class IdGeneratorTest
    {
        [Test]
        public void TestSanitizeHostName()
        {
            Assert.AreEqual("somehost.lan", IdGenerator2.SanitizeHostName("somehost.lan"));

            // include a UTF-8 char in the text \u0E08 is a Thai elephant
            Assert.AreEqual("otherhost.lan", IdGenerator2.SanitizeHostName("other\u0E08host.lan"));
        }

        [Test]
        public void TestDefaultPrefix()
        {
            var generator = new IdGenerator2();
            string generated = generator.GenerateId();
            Assert.True(generated.StartsWith(IdGenerator2.DEFAULT_PREFIX));
            Assert.IsFalse(generated.Substring(IdGenerator2.DEFAULT_PREFIX.Length).StartsWith(":"));
        }

        [Test]
        public void TestNonDefaultPrefix()
        {
            var idGenerator = new IdGenerator2("TEST-");
            var generated = idGenerator.GenerateId();
            Assert.IsFalse(generated.StartsWith(IdGenerator2.DEFAULT_PREFIX));
            Assert.IsFalse(generated.Substring("TEST-".Length).StartsWith(":"));
        }

        [Test]
        public void TestIdIndexIncrements()
        {
            var generator = new IdGenerator2();
            var sequences = Enumerable.Repeat(0, 5)
                                      .Select(x => generator.GenerateId())
                                      .Select(x => x.Split(':').Last())
                                      .Select(int.Parse);

            CollectionAssert.AreEqual(new[] { 1, 2, 3, 4, 5 }, sequences);
        }
    }
}