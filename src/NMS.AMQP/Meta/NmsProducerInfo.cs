using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsProducerInfo : INmsResource<NmsProducerId>
    {
        public NmsProducerInfo(NmsProducerId producerId)
        {
            Id = producerId ?? throw new ArgumentNullException(nameof(producerId), "Producer ID cannot be null");
        }

        public NmsProducerId Id { get; }
        public NmsSessionId SessionId => Id.SessionId;
        public IDestination Destination { get; set; }
    }
}