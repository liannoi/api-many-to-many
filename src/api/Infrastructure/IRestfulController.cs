using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ManyToMany.WebAPI.Infrastructure
{
    public interface IRestfulController<TListModel, TModel>
    {
        Task<ActionResult<TListModel>> GetAll();
        Task<ActionResult<TModel>> Create<TCommand>(TCommand command);
        Task<ActionResult<TModel>> GetById(int id);
        Task<ActionResult<TModel>> Update<TCommand>(int id, TCommand command);
        Task<ActionResult<TModel>> Delete(int id);
    }
}