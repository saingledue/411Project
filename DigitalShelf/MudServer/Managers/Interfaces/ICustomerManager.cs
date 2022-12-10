using MudServer.ViewModels;

namespace MudServer.Managers.Interfaces
{
    public interface ICustomerManager
    {
        public Task<CustomerView> CreateCustomerAsync(CustomerView obj);
        public Task<CustomerView> GetCustomerAsync(int id);
        public Task<IEnumerable<CustomerView>> GetCustomersAsync();
        public Task<CustomerView> UpdateCustomerAsync(CustomerView obj);
        public Task<int> DeleteCustomerAsync(int id);
    }
}
