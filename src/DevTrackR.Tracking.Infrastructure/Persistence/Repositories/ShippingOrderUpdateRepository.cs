using DevTrackR.Tracking.Core.Entities;
using DevTrackR.Tracking.Core.Repositories;
using MongoDB.Driver;

namespace DevTrackR.Tracking.Infrastructure.Persistence.Repositories
{
    public class ShippingOrderUpdateRepository : IShippingOrderUpdateRepository
    {
        private readonly IMongoCollection<ShippingOrderUpdate> _collection;
        public ShippingOrderUpdateRepository(IMongoDatabase database)
        {
            _collection = database.GetCollection<ShippingOrderUpdate>("shipping-order-updates");
        }

        public async Task AddAsync(ShippingOrderUpdate update)
        {
            await _collection.InsertOneAsync(update);
        }
        
        public async Task<List<ShippingOrderUpdate>> GetAllByCodeAsync(string shippingOrderCode)
        {
            return await _collection.Find(so => so.TrackingCode == shippingOrderCode).ToListAsync();
        }
    }
}
