using System;
using System.Threading.Tasks;
using magiclick.Core.Repositories;

namespace magiclick.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IMusicRepository Musics { get; }
        IArtistRepository Artists { get; }
        Task<int> CommitAsync();
    }
}