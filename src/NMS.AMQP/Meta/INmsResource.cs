namespace Apache.NMS.AMQP.Meta
{
    public interface INmsResource
    {
    }

    public interface INmsResource<out TResourceId> : INmsResource where TResourceId : INmsResourceId
    {
        TResourceId Id { get; }
    }

    public interface INmsResourceId
    {
    }
}