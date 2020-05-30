using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Infrastructure
{
    public interface IRestfulController<TListModel, in TCreateCommand, TModel>
    {
        Task<ActionResult<TListModel>> GetAll();
        Task<IActionResult> Create(TCreateCommand command);
        Task<ActionResult<TModel>> GetById(int id);
    }
}