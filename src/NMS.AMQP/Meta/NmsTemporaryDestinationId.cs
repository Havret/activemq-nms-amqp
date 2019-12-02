using Apache.NMS.AMQP.Meta;

namespace Apache.NMS.AMQP
{
    public class NmsTemporaryDestinationId : INmsResourceId
    {
        private readonly long value;

        public NmsTemporaryDestinationId(NmsConnectionId connectionId, long value)
        {
            this.ConnectionId = connectionId;
            this.value = value;
        }

        public NmsConnectionId ConnectionId { get; }

        public override string ToString()
        {
            return $"{ConnectionId}:{value}";
        }
    }
}