using DevTrackR.Tracking.Core.Entities;

namespace DevTrackR.Tracking.Application.Models.InputModels
{
    public class AddShippingOrderUpdateInputModel
    {
        public ShippingOrderUpdate ToEntity()
        {
            return new ShippingOrderUpdate(TrackingCode, Description, IsShippingCompleted);
        }

        public string TrackingCode { get; set; }
        public string Description { get; set; }
        public bool IsShippingCompleted { get; set; }
    }
}
