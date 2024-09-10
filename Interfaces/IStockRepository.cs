using System.Collections.Generic;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Helpers;
using api.Models;

namespace api.Interfaces
{
       //firma o declaracion de las acciones/funciones
    //la clase que implemente esta interfaz , tendra que implementar estos metodos y color lo necesario dentro de ellas
    public interface IStockRepository
    {
        Task<List<Stock>> GetAllAsync(QueryObject query);
        Task<Stock?>GetByIdAsync(int id);
        Task <Stock> CreateAsync(Stock stockModel);
        Task<Stock> UpdateAsync(int id, UpdateStockRequestDto stockDto);
        Task<Stock>DeteleAsync(int id);
        Task<bool>StockExists(int id);
    }
}