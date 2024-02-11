using System;
using System.Threading.Tasks;

namespace vIO
{
    public interface IStreamOverWriter<T> : IStreamWriter<T>
    {
        IStreamSyncOverWriter<T>? SyncOverWriter { get; }
        IStreamAsyncOverWriter<T>? AsyncOverWriter { get; }
    }
    
    public interface IStreamSyncOverWriter<T> : IStreamSyncWriter<T>
    {
        IStreamOverWriter<T> OverWriter { get; }
        int Skip(int count);
    }
    
    public interface IStreamAsyncOverWriter<T> : IStreamAsyncWriter<T>
    {
        IStreamOverWriter<T> OverWriter { get; }
        Task<int> Skip(int count);
    }
}