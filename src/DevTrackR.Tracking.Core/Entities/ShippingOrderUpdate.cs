namespace DevTrackR.Tracking.Core.Entities
{
    public class ShippingOrderUpdate
    {
        public ShippingOrderUpdate(string trackingCode, string description, bool isShippingCompleted)
        {
            Id = Guid.NewGuid();
            TrackingCode = trackingCode;
            Description = description;
            IsShippingCompleted = isShippingCompleted;

            UpdatedAt = DateTime.Now;
        }

        public Guid Id { get; private set; }
        public string TrackingCode { get; private set; }
        public string Description { get; private set; }
        public bool IsShippingCompleted { get; private set; }
        public DateTime UpdatedAt { get; private set; }
    }
}
