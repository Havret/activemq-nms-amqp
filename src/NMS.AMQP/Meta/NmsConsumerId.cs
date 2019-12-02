using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsConsumerId : INmsResourceId
    {
        private long value;

        public NmsConsumerId(NmsSessionId sessionId, long consumerId)
        {
            this.SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId), "Session ID cannot be null");
            this.value = consumerId;

        }

        public NmsSessionId SessionId { get; }
        public NmsConnectionId ConnectionId => SessionId.ConnectionId;
    }
}