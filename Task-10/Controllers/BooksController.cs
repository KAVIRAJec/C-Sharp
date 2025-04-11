using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task_10.Models;
using Task_10.Services;

namespace Task_10.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService service;
        public BooksController(IBookService service)
        {
            this.service = service;
        }

        [HttpPost]
        public async Task<JsonResult> Create(Book book)
        {
            var created = await service.CreateBook(book);
            return new JsonResult(created);
        }
        [HttpGet]
        public async Task<JsonResult> Get(int id)
        {
            var book = await service.GetByIdBook(id);
            if(book == null)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(book);
        }
        [HttpGet]
        public async Task<JsonResult> GetAll()
        {
            var books = await service.GetAllBook();
            return new JsonResult(books);
        }
        [HttpPut]
        public async Task<JsonResult> Update(int id, Book book)
        {
            var response = await service.UpdateBook(id, book);
            if(!response)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(int id)
        {
            var response = await service.DeleteBook(id);
            if(!response)
            {
                return new JsonResult(NotFound());
            }
            return new JsonResult(Ok());
        }
    }
}
