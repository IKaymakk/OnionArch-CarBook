using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Inferfaces
{
    public interface ICommentRepository
    {
        Task<List<Comments>> GetCommentListByBlog(int blogid);
    }
}
