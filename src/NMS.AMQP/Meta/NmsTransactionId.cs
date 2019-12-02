using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsTransactionId : INmsResourceId
    {
        public NmsTransactionId(NmsConnectionId connectionId, long transactionId)
        {
            this.ConnectionId = connectionId ?? throw new ArgumentNullException(nameof(connectionId), "Connection ID cannot be null");
            this.Value = transactionId;
        }
        
        public NmsConnectionId ConnectionId { get; }
        public long Value { get; }

        public override string ToString() => $"TX: {ConnectionId}:{Value}";
    }
}