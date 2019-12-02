namespace Apache.NMS.AMQP.Meta
{
    public class NmsSessionId : INmsResourceId
    {
        private readonly long value;

        public NmsSessionId(NmsConnectionId connectionId, long value)
        {
            this.ConnectionId = connectionId;
            this.value = value;
        }
        
        public NmsConnectionId ConnectionId { get; }
    }
}