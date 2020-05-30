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
    public class AuthorsController : BaseController, IRestfulController<AuthorsListViewModel, AuthorDto>
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

        public Task<ActionResult<AuthorDto>> Create<TCommand>(TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorDto>> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorDto>> Update<TCommand>(int id, TCommand command)
        {
            throw new NotImplementedException();
        }

        public Task<ActionResult<AuthorDto>> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}