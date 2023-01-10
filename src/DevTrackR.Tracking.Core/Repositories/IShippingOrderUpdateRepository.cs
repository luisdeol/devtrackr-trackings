using DevTrackR.Tracking.Core.Entities;

namespace DevTrackR.Tracking.Core.Repositories
{
    public interface IShippingOrderUpdateRepository
    {
        Task AddAsync(ShippingOrderUpdate update);
        Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode);
    }
}
