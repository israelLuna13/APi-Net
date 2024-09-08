
using System.Linq;
using api.Dtos.Stock;
using api.Models;

namespace api.Mapers
{
    public static class StockMapers
    {
        public static StockDto ToStockDto( this Stock StockModel)
        {
            return new StockDto
            {
                Id = StockModel.Id,
                Symbol = StockModel.Symbol,
                CompanyName= StockModel.CompanyName,
                Purchase= StockModel.Purchase,
                Dividend= StockModel.Dividend,
                LastDiv= StockModel.LastDiv,
                Industry= StockModel.Industry,
                MarketCap= StockModel.MarketCap,
                Comments=StockModel.Comments.Select(c=>c.ToCommentDto()).ToList()
            };
        }
        public static Stock ToStockFromCreateDTO(this CreateStockRequestDto stockDto)
        {
            return new Stock
            {
                Symbol= stockDto.Symbol,
                CompanyName= stockDto.CompanyName,
                Purchase=stockDto.Purchase,
                Dividend= stockDto.Dividend,
                LastDiv= stockDto.LastDiv,
                Industry= stockDto.Industry,
                MarketCap= stockDto.MarketCap
            };
        }

    }
}