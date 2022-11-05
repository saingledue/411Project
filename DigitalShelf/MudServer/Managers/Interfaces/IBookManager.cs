using MudServer.ViewModels;

namespace MudServer.Managers.Interfaces
{
    public interface IBookManager
    {
        public Task<BookView> CreateBookAsync(BookView obj);
        public Task<BookView> GetBookAsync(int id);
        public Task<IEnumerable<BookView>> GetBooksAsync(string email);
        public Task<BookView> UpdateBookAsync(BookView obj);
        public Task<int> DeleteBookAsync(int id);
    }
}
