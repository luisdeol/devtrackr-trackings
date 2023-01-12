namespace DevTrackR.Tracking.Core.Events
{
    public class ShippingOrderCompletedEvent
    {
        public ShippingOrderCompletedEvent(string trackingCode)
        {
            TrackingCode = trackingCode;
        }
        
        public string TrackingCode { get; private set; }
    }
}