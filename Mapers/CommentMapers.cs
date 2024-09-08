using api.Dtos.Comment;
using api.Models;

namespace api.Mapers
{
    public static class CommentMapers
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id=commentModel.Id,
                Title=commentModel.Title,
                Content=commentModel.Content,
                CrearedOn=commentModel.CrearedOn,
                StockId=commentModel.StockId,
            };
        }
    
  public static Comment ToCommentFromCreate(this CreateCommentDto commentDto ,int stockId)
        {
            return new Comment
            {
                Title=commentDto.Title,
                Content=commentDto.Content,
                StockId=commentDto.StockId
            };
        }

         public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto)
        {
            return new Comment
            {
                Title=commentDto.Title,
                Content=commentDto.Content
            };
        }
      
    }

}