using Microsoft.EntityFrameworkCore;
using Task_10.Data;
using Task_10.Models;

namespace Task_10.Services
{
    public class BookService: IBookService
    {
        private readonly DBContext dbContext;
        public BookService(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public async Task<Book> CreateBook(Book book)
        {
            dbContext.Books.Add(book);
            await dbContext.SaveChangesAsync();
            return book;
        }
        public async Task<Book?> GetByIdBook(int id) => await dbContext.Books.FindAsync(id);
        public async Task<List<Book>> GetAllBook() => await dbContext.Books.ToListAsync();
        public async Task<bool> UpdateBook(int id, Book updatedBook)
        {
            var book = await dbContext.Books.FindAsync(id);
            if(book == null) return false;

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.YearPublished = updatedBook.YearPublished;
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<bool> DeleteBook(int id)
        {
            var book = await dbContext.Books.FindAsync(id);
            if (book == null) return false;

            dbContext.Books.Remove(book);
            await dbContext.SaveChangesAsync();
            return true;
        }

    }
}
