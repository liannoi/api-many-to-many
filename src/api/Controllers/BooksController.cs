using System;
using System.Threading.Tasks;
using FluentValidation;
using ManyToMany.System.Core.Application.Storage.Books;
using ManyToMany.System.Core.Application.Storage.Books.Queries.Get.AsList;
using ManyToMany.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Controllers
{
    public class BooksController : BaseController, IRestfulController<BooksListViewModel, BookLookupDto>
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BooksListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetBooksAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        public Task<ActionResult<BookLookupDto>> Create<TCommand>(TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<BookLookupDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<BookLookupDto>> Update<TCommand>(int id, TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<BookLookupDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}