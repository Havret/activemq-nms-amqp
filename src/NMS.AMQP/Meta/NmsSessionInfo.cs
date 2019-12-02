namespace Apache.NMS.AMQP.Meta
{
    public class NmsSessionInfo : INmsResource<NmsSessionId>
    {
        public NmsSessionInfo(NmsSessionId sessionId)
        {
            this.Id = sessionId;
        }

        public AcknowledgementMode AcknowledgementMode { get; set; }
        public NmsSessionId Id { get; }
    }
}