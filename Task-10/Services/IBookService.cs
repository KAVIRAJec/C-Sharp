using Task_10.Models;

namespace Task_10.Services
{
    public interface IBookService
    {
        Task<Book> CreateBook(Book book);
        Task<Book?> GetByIdBook(int id);
        Task<List<Book>> GetAllBook();
        Task<bool> UpdateBook(int id, Book updatedBook);
        Task<bool> DeleteBook(int id);
    }
}
