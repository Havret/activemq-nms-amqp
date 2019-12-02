using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsTransactionInfo : INmsResource<NmsTransactionId>
    {
        public NmsTransactionInfo(NmsSessionId sessionId, NmsTransactionId transactionId)
        {
            this.SessionId = sessionId ?? throw new ArgumentNullException(nameof(sessionId), "Session ID cannot be null");
            this.Id = transactionId ?? throw new ArgumentNullException(nameof(transactionId), "Transaction ID cannot be null");
        }

        public NmsTransactionId Id { get; }
        public NmsSessionId SessionId { get; }
        public bool IsInDoubt { get; private set; }
        public byte[] ProviderTxId { get; set; }

        public void SetInDoubt()
        {
            IsInDoubt = true;
        }
    }
}