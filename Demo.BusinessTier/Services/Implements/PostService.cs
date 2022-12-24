using Demo.DataTier.Data;
using Demo.DataTier.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BusinessTier.Services.Implements
{
    public class PostService : IPostService
    {
        private readonly DemoDbContext context;
        public PostService(DemoDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Post>> GetPosts()
        {
            List<Post> posts = await context.Posts.ToListAsync();
            return posts;
        }

    }
}
