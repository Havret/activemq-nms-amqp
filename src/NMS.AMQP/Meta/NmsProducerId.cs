using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsProducerId : INmsResourceId
    {
        private long value;

        public NmsProducerId(NmsSessionId sessionId, long producerId)
        {
            this.SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId), "Session ID cannot be null");
            this.value = producerId;
        }

        public NmsSessionId SessionId { get; }
        public NmsConnectionId ConnectionId => SessionId.ConnectionId;
    }
}