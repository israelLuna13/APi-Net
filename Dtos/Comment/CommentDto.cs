using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
                //definimos los geter y seter

        public int Id { get; set; }

        public string Title { get; set; }=string.Empty;

        public string Content { get; set; } = string.Empty;
        public DateTime CrearedOn { get; set; } = DateTime. Now;
        public int? StockId{ get; set; }

        }
}