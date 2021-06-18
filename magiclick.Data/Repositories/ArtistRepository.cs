using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using magiclick.Core.Models;
using magiclick.Core.Repositories;

namespace magiclick.Data.Repositories
{
    public class ArtistRepository : Repository<Artist>, IArtistRepository
    {
        public ArtistRepository(magiclickDbContext context) 
            : base(context)
        { }
        public async Task<IEnumerable<Artist>> GetAllWithMusicsAsync()
        {
            return await magiclickDbContext.Artists
                .Include(a => a.Musics)
                .ToListAsync();
        }

        public Task<Artist> GetWithMusicsByIdAsync(int id)
        {
            return magiclickDbContext.Artists
                .Include(a => a.Musics)
                .SingleOrDefaultAsync(a => a.Id == id);
        }

        private magiclickDbContext magiclickDbContext
        {
            get { return Context as magiclickDbContext; }
        }
    }
}