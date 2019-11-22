using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsConnectionId
    {
        private string value;
        
        public NmsConnectionId(string connectionId)
        {
            if (string.IsNullOrWhiteSpace(connectionId))
            {
                throw new ArgumentException("Connection ID cannot be null or empty");
            }
        }

        public NmsConnectionId(NmsConnectionId id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "Connection ID cannot be null");
            }
            this.value = id.value;
        }
    }
}