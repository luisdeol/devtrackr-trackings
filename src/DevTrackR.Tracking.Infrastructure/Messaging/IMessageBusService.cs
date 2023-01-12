namespace DevTrackR.Tracking.Infrastructure.Messaging
{
    public interface IMessageBusService
    {
        void Publish(object data, string routingKey);
    }
}