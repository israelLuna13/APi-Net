
using System.ComponentModel.DataAnnotations;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        //definimos los geter y seter
        [Required]
        [MinLength(5,ErrorMessage ="Title must be 5 characters")]
        [MaxLength(40, ErrorMessage = "Title cannot be over 280 characters")]

         public string Title { get; set; }=string.Empty;
        [Required]
        [MinLength(5,ErrorMessage ="Content must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]

        public string Content { get; set; } = string.Empty;
        public int? StockId { get; internal set; }
    }
}