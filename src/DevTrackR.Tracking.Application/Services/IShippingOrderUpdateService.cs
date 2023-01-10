using DevTrackR.Tracking.Application.Models.InputModels;
using DevTrackR.Tracking.Application.Models.ViewModels;

namespace DevTrackR.Tracking.Application.Services
{
    public interface IShippingOrderUpdateService
    {
        Task AddUpdate(AddShippingOrderUpdateInputModel model);
        Task<List<ShippingOrderUpdateViewModel>> GetAllByCode(string code);
    }
}
