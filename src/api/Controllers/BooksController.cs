using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Storage.Books.Commands.Create;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBookDetail;
using ManyToMany.System.Core.Application.Storage.Books.Queries.GetBooksList;
using ManyToMany.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Controllers
{
    public class BooksController : BaseController, IRestfulController<BooksListViewModel, CreateBookCommand, BookDto>
    {
        [HttpGet]
        public async Task<ActionResult<BooksListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetBooksListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateBookCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetBookDetailQuery {BookId = id}));
        }

        /*public Task<ActionResult<BookDto>> Update<TCommand>(int id, TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<BookDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }*/
    }
}