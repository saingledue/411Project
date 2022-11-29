using AutoMapper;
using MudServer.Managers.Interfaces;
using MudServer.ViewModels;
using MudServer.Data;
using MudServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace MudServer.Managers
{
    public class CustomerManager : ICustomerManager
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public CustomerManager(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CustomerView> CreateCustomerAsync(CustomerView obj)
        {
            var Customer = _mapper.Map<CustomerView, Customer>(obj);
            var addedCustomer = await _context.Customers.AddAsync(Customer);
            await _context.SaveChangesAsync();
            return _mapper.Map<Customer, CustomerView>(addedCustomer.Entity);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            var CustomerDetails = await _context.Customers.FindAsync(id);
            if (CustomerDetails != null)
            {
                _context.Customers.Remove(CustomerDetails);
                return await _context.SaveChangesAsync();
            }
            return default;
        }

        public async Task<CustomerView> GetCustomerAsync(int id)
        {
            var CustomerData = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (CustomerData == null)
            {
                return new();
            }

            return _mapper.Map<Customer, CustomerView>(CustomerData);
        }

        public async Task<IEnumerable<CustomerView>> GetCustomersAsync()
        {
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerView>>(await _context.Customers.ToListAsync());
        }

        public async Task<CustomerView> UpdateCustomerAsync(CustomerView obj)
        {
            var CustomerDetails = await _context.Customers.FindAsync(obj.Id);
            var Customer = _mapper.Map<CustomerView, Customer>(obj, CustomerDetails!);

            var updatedCustomer = _context.Customers.Update(Customer);
            await _context.SaveChangesAsync();

            return _mapper.Map<Customer, CustomerView>(updatedCustomer.Entity);
        }
    }
}
