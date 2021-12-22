using System;

namespace NetCoreApp.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Call Save change fo db context
        /// </summary>
        void Commit();
    }
}