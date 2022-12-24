using Demo.DataTier.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessTier.Services
{
    public interface IPostService
    {
        Task<List<Post>> GetPosts();
    }
}
