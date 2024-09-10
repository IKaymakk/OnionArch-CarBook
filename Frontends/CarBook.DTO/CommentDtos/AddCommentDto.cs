using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.DTO.CommentDtos
{
    public class AddCommentDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
    }
}
