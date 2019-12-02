using System.Threading;

namespace Apache.NMS.AMQP.Util
{
    // TODO: Make Internal
    public class AtomicLong
    {
        private long value;

        public AtomicLong(long initialValue = 0)
        {
            this.value = initialValue;
        }

        public long IncrementAndGet()
        {
            return Interlocked.Increment(ref value);
        }

        public static implicit operator long(AtomicLong atomicLong)
        {
            return atomicLong.value;
        }
    }
}