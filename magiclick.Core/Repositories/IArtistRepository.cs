using System.Collections.Generic;
using System.Threading.Tasks;
using magiclick.Core.Models;

namespace magiclick.Core.Repositories
{
    public interface IArtistRepository : IRepository<Artist>
    {
        Task<IEnumerable<Artist>> GetAllWithMusicsAsync();
        Task<Artist> GetWithMusicsByIdAsync(int id);
    }
}