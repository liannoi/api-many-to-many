using System.Threading.Tasks;
using ManyToMany.System.Core.Application.Storage.Authors.Commands.Create;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorDetail;
using ManyToMany.System.Core.Application.Storage.Authors.Queries.GetAuthorsList;
using ManyToMany.WebAPI.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Controllers
{
    public class AuthorsController : BaseController,
        IRestfulController<AuthorsListViewModel, CreateAuthorCommand, AuthorDto>
    {
        [HttpGet]
        public async Task<ActionResult<AuthorsListViewModel>> GetAll()
        {
            return Ok(await Mediator.Send(new GetAuthorsListQuery()));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> Create([FromBody] CreateAuthorCommand command)
        {
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetById(int id)
        {
            return Ok(await Mediator.Send(new GetAuthorDetailQuery {AuthorId = id}));
        }
    }
}