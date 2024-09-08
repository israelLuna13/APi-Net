
namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        //definimos los geter y seter

         public string Title { get; set; }=string.Empty;
        public string Content { get; set; } = string.Empty;
        public int? StockId { get; internal set; }
    }
}