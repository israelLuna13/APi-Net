using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Helpers;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    //esta clase implementa una interfaz
    public class StockRepository : IStockRepository
    {

        //atraves de _context puedo interactuar con la base de datos
        private readonly ApplicationDBContext _context;
        public StockRepository(ApplicationDBContext context)
        {
            _context =context;
        }


        public async Task<Stock> CreateAsync(Stock stockModel)
        {
            await _context.Stock.AddAsync(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public async Task<Stock?> DeteleAsync(int id)
        {
            var stockModel = await _context.Stock.FirstOrDefaultAsync(x => x.Id == id);
            if(stockModel == null)
            {
                return null;
            }
             _context.Stock.Remove(stockModel);
            await _context.SaveChangesAsync();
            return stockModel;
        }

        public  async Task<List<Stock>> GetAllAsync(QueryObject query)
        {
            var stock =  _context.Stock.Include(c=>c.Comments).AsQueryable();
            if(!string.IsNullOrWhiteSpace(query.CompanyName))
            {
                 stock= stock.Where(x => x.CompanyName.Contains(query.CompanyName));
            }

            if(!string.IsNullOrWhiteSpace(query.Symbol)){
                stock=stock.Where(s=>s.Symbol.Contains(query.Symbol));
            }

            if(!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if(query.SortBy.Equals("Symbol", StringComparison.OrdinalIgnoreCase))
                {
                    stock = query.IsDecsending ? stock.OrderByDescending(s=> s.Symbol):stock.OrderBy(s=>s.Symbol);
                    
                }
            }

            var skipNumber = (query.PageNumber -1) * query.PageSize;
            
            return await stock.Skip(skipNumber).Take(query.PageSize).ToListAsync();
        }

        public async Task<Stock?> GetByIdAsync(int id)
        {
              return  await  _context.Stock.Include(c=>c.Comments).FirstOrDefaultAsync(i => i.Id == id);    
        }

        public Task<bool> StockExists(int id)
        {
            return _context.Stock.AnyAsync(s => s.Id == id);
        }

        public  async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto stockDto)
        {
            //obtenemos el elementos a actualizar
            var existingStock = await  _context.Stock.FirstOrDefaultAsync(x=> x.Id == id);
            if (existingStock == null)
            {
                return null;
            }
            //actualizamos cada caracteristica de ese elemento
            existingStock.Symbol= stockDto.Symbol;
            existingStock.CompanyName=stockDto.CompanyName;
            existingStock.Purchase=stockDto.Purchase;
            existingStock.Dividend=stockDto.Dividend;
            existingStock.LastDiv=stockDto.LastDiv;
            existingStock.Industry=stockDto.Industry;
            existingStock.MarketCap=stockDto.MarketCap;

            await _context.SaveChangesAsync();
            return existingStock;     
        }
    }
}