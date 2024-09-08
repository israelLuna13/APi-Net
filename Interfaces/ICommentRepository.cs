using System.Collections.Generic;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    //firma o declaracion de las acciones/funciones
    //la clase que implemente esta interfaz , tendra que implementar estos metodos y color lo necesario dentro de ellas
    public interface ICommentRepository
    {
        Task<List<Comment>> GetAllAsync();
        Task<Comment?>GetByIdAsync(int id);
        Task<Comment>CreateAsync(Comment commentModel);
        Task<Comment>UpdateAsync(int id, Comment commentModel);
        Task<Comment>DeleteAsync(int id);

    }
}