using DevTrackR.Tracking.Application.Models.InputModels;
using DevTrackR.Tracking.Application.Models.ViewModels;
using DevTrackR.Tracking.Core.Events;
using DevTrackR.Tracking.Core.Repositories;
using DevTrackR.Tracking.Infrastructure.Messaging;

namespace DevTrackR.Tracking.Application.Services
{
    public class ShippingOrderUpdateService : IShippingOrderUpdateService
    {
        private readonly IShippingOrderUpdateRepository _repository;
        private readonly IMessageBusService _messageBus;

        public ShippingOrderUpdateService(IShippingOrderUpdateRepository repository, IMessageBusService messageBus)
        {
            _messageBus = messageBus;
            _repository = repository;
        }

        public async Task AddUpdate(AddShippingOrderUpdateInputModel model)
        {
            var shippingOrderUpdate = model.ToEntity();

            await _repository.AddAsync(shippingOrderUpdate);

            var orderUpdatedEvent = new ShippingOrderUpdatedEvent(model.TrackingCode, model.ContactEmail, model.Description);

            _messageBus.Publish(orderUpdatedEvent, "shipping-order-updated");

            if (model.IsShippingCompleted) {
                var orderCompletedEvent = new ShippingOrderCompletedEvent(model.TrackingCode);

                _messageBus.Publish(orderCompletedEvent, "shipping-order-completed");
            }
        }

        public async Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code)
        {
            var shippingOrderUpdates = await _repository.GetAllByCodeAsync(code);

            var viewModels = shippingOrderUpdates.Select(so => new ShippingOrderUpdateViewModel(so)).ToList();

            return viewModels;
        }
    }
}
