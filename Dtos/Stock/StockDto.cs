
using System.Collections.Generic;
using api.Dtos.Comment;

namespace api.Dtos.Stock
{
    public class StockDto
    {
        //definimos los geter y seter
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; }= string.Empty;
        public decimal Purchase{ get; set; }    
        public decimal Dividend{ get; set; }          
        public decimal LastDiv{ get; set;}
        public string Industry { get; set; }=string.Empty;
        public long MarketCap{ get; set; }
        public List<CommentDto> Comments{ get; set; }

    }
}