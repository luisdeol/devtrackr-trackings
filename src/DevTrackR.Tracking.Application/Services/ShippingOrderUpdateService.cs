using DevTrackR.Tracking.Application.Models.InputModels;
using DevTrackR.Tracking.Application.Models.ViewModels;
using DevTrackR.Tracking.Core.Repositories;

namespace DevTrackR.Tracking.Application.Services
{
    public class ShippingOrderUpdateService : IShippingOrderUpdateService
    {
        private readonly IShippingOrderUpdateRepository _repository;

        public ShippingOrderUpdateService(IShippingOrderUpdateRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUpdate(AddShippingOrderUpdateInputModel model)
        {
            var shippingOrderUpdate = model.ToEntity();

            await _repository.AddAsync(shippingOrderUpdate);
        }

        public async Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code)
        {
            var shippingOrderUpdates = await _repository.GetAllByCodeAsync(code);

            var viewModels = shippingOrderUpdates.Select(so => new ShippingOrderUpdateViewModel(so)).ToList();

            return viewModels;
        }
    }
}
