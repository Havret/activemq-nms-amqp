using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsConsumerInfo : INmsResource<NmsConsumerId>
    {
        public NmsConsumerInfo(NmsConsumerId consumerId)
        {
            Id = consumerId ?? throw new ArgumentNullException(nameof(consumerId), "Consumer ID cannot be null");
        }

        public NmsConsumerId Id { get; }
        public NmsSessionId SessionId => Id.SessionId;
        public IDestination Destination { get; set; }
        public string Selector { get; set; }
        public bool NoLocal { get; set; }
        public string SubscriptionName { get; set; }
        public bool IsDurable { get; set; }
        public bool LocalMessageExpiry { get; set; }
    }
}