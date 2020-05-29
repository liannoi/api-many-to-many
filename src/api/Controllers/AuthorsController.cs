using System;
using System.Threading.Tasks;
using FluentValidation;
using ManyToMany.System.Core.Application.Storage.Authors;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.Get.AsList;
using ManyToMany.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Controllers
{
    public class AuthorsController : BaseController, IRestfulController<AuthorsListViewModel, AuthorLookupDto>
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<AuthorsListViewModel>> GetAll()
        {
            try
            {
                return Ok(await Mediator.Send(new GetAuthorsAsListQuery()));
            }
            catch (ValidationException e)
            {
                return BadRequest(e.Message);
            }
        }

        public Task<ActionResult<AuthorLookupDto>> Create<TCommand>(TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorLookupDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorLookupDto>> Update<TCommand>(int id, TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorLookupDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}