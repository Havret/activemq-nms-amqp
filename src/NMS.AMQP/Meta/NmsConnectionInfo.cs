using System;

namespace Apache.NMS.AMQP.Meta
{
    public class NmsConnectionInfo : INmsResource<NmsConnectionId>
    {
        public NmsConnectionInfo(NmsConnectionId connectionId)
        {
            this.Id = connectionId ?? throw new ArgumentNullException(nameof(connectionId));
        }

        public NmsConnectionId Id { get; }
        public bool IsExplicitClientId { get; private set; }
        public string ClientId { get; private set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public Uri ConfiguredUri { get; set; }
        public long RequestTimeout { get; set; }
        public long SendTimeout { get; set; }
        public bool LocalMessageExpiry { get; set; }

        public void SetClientId(string clientId, bool explicitClientId)
        {
            this.ClientId = clientId;
            this.IsExplicitClientId = explicitClientId;
        }

        protected bool Equals(NmsConnectionInfo other)
        {
            return Equals(Id, other.Id);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((NmsConnectionInfo) obj);
        }

        public override int GetHashCode()
        {
            return Id != null ? Id.GetHashCode() : 0;
        }
    }
}