using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;

namespace Apache.NMS.AMQP.Util
{
    // TODO: Change to interl
    public class IdGenerator2
    {
        public const string DEFAULT_PREFIX = "ID:";

        private readonly string prefix;
        private long sequence;
        private static string hostName;

        static IdGenerator2()
        {
            try
            {
                 hostName = Dns.GetHostName();
            }
            catch (Exception e)
            {
                Tracer.Error($"Could not generate host name prefix from DNS lookup: {e}");
            }
            
            hostName = SanitizeHostName(hostName);
        }

        public IdGenerator2(string prefix = DEFAULT_PREFIX)
        {
            this.prefix = prefix + (hostName != null ? hostName + ":" : "");
        }

        public string GenerateId() => $"{prefix}{Guid.NewGuid()}:{Interlocked.Increment(ref sequence)}";

        public static string SanitizeHostName(string hostName)
        {
            var sanitizedHostname = string.Concat(GetASCIICharacters(hostName));
            if (sanitizedHostname.Length != hostName.Length)
            {
                Tracer.Info($"Sanitized hostname from: {hostName} to: {sanitizedHostname}");
            }

            return sanitizedHostname;
        }

        private static IEnumerable<char> GetASCIICharacters(string hostName) => hostName.Where(ch => ch < 127);
    }
}