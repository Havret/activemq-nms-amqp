using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsConnectionInfo
    {
        private readonly NmsConnectionId connectionId;

        public NmsConnectionInfo(NmsConnectionId connectionId)
        {
            this.Id = connectionId ?? throw new ArgumentNullException(nameof(connectionId));
        }

        public NmsConnectionId Id { get; }
    }
}