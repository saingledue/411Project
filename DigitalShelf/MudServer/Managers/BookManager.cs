using AutoMapper;
using MudServer.Managers.Interfaces;
using MudServer.ViewModels;
using MudServer.Data;
using MudServer.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace MudServer.Managers
{

    public class BookManager : IBookManager
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public BookManager(ApplicationDbContext context, IMapper mapper, IUserManager userManager)
        {
            _context = context;
            _mapper = mapper;
            _userManager = userManager;
        }

        public string email;

        public async Task<BookView> CreateBookAsync(BookView obj)
        {
            var book = _mapper.Map<BookView, Book>(obj);
            book.UserId = _userManager.GetUserIdByEmail(email);
            var addedBook = await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return _mapper.Map<Book, BookView>(addedBook.Entity);
        }

        public async Task<int> DeleteBookAsync(int id)
        {
            var bookDetails = await _context.Books.FindAsync(id);
            if (bookDetails != null)
            {
                _context.Books.Remove(bookDetails);
                return await _context.SaveChangesAsync();
            }
            return default;
        }

        public async Task<BookView> GetBookAsync(int id)
        {
            var bookData = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (bookData == null)
            {
                return new();
            }

            return _mapper.Map<Book, BookView>(bookData);
        }

        public async Task<IEnumerable<BookView>> GetBooksAsync(string name)
        {
            email = name;
            int number = _userManager.GetUserIdByEmail(email);
            return _mapper.Map<IEnumerable<Book>, IEnumerable<BookView>>(await _context.Books.Where(x => x.UserId == number).ToListAsync());
        }

        public async Task<BookView> UpdateBookAsync(BookView obj)
        {
            var bookDetails = await _context.Books.FindAsync(obj.Id);
            var book = _mapper.Map<BookView, Book>(obj, bookDetails!);

            var updatedBook = _context.Books.Update(book);
            await _context.SaveChangesAsync();

            return _mapper.Map<Book, BookView>(updatedBook.Entity);
        }
    }
}
