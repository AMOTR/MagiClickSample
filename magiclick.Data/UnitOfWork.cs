using System.Threading.Tasks;
using magiclick.Core;
using magiclick.Core.Repositories;
using magiclick.Data.Repositories;

namespace magiclick.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly magiclickDbContext _context;
        private MusicRepository _musicRepository;
        private ArtistRepository _artistRepository;

        public UnitOfWork(magiclickDbContext context)
        {
            this._context = context;
        }

        public IArtistRepository Artists => _artistRepository = _artistRepository ?? new ArtistRepository(_context);

        public IMusicRepository Musics => _musicRepository = _musicRepository ?? new MusicRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}