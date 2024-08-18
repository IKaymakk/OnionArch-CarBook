using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface IAuthorRepository
    {
        Task<List<Blog>> GetBlogListByAuthor(int authorid);
    }
}
