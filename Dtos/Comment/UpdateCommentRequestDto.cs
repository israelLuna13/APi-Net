using System.ComponentModel.DataAnnotations;
namespace api.Dtos.Comment
{
    //definimos los geter y seter

    public class UpdateCommentRequestDto
    {
        [Required]
        [MinLength(5,ErrorMessage ="Title must be 5 characters")]
        [MaxLength(15, ErrorMessage = "Title cannot be over 15 characters")]

        public string Title { get; set; }=string.Empty;
        [Required]
        [MinLength(5,ErrorMessage ="Contente must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Contente cannot be over 280 characters")]

        public string Content { get; set; } = string.Empty;

    }
}